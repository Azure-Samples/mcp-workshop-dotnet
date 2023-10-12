targetScope = 'subscription'

param name string
param location string

// tags that should be applied to all resources.
var tags = {
  // Tag all resources with the environment name.
  'azd-env-name': name
}

resource rg 'Microsoft.Resources/resourceGroups@2021-04-01' = {
  name: 'rg-${name}'
  location: location
  tags: tags
}

module cogsvc '../../_infra/provision-CognitiveServices.bicep' = {
  name: 'CognitiveServices'
  scope: rg
  params: {
    name: name
    location: location
    tags: tags
  }
}

module fncapp '../../_infra/provision-FunctionApp.bicep' = {
  name: 'FunctionApp'
  scope: rg
  params: {
    name: name
    location: location
    tags: tags
    blobContainerName: 'images'
    isLinux: false
    dotnetVersion: '8.0'
    appEnvSettings: [
      {
        name: 'ComputerVisionKey'
        value: cogsvc.outputs.apiKey
      }
      {
        name: 'ComputerVisionEndPoint'
        value: cogsvc.outputs.endpoint
      }
    ]
  }
}
