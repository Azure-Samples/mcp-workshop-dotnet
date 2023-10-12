param name string
param location string = resourceGroup().location

param tags object = {}

module comvsn './computerVision.bicep' = {
  name: 'CognitiveServices_ComputerVision'
  params: {
    name: name
    location: location
    tags: tags
  }
}

output name string = comvsn.outputs.name
output endpoint string = comvsn.outputs.endpoint
output apiKey string = comvsn.outputs.apiKey
