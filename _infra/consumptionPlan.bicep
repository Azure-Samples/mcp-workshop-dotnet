param name string
param location string = resourceGroup().location

param tags object = {}

param isLinux bool = false

var consumption = {
  name: 'csplan-${name}'
  location: location
  tags: tags
  isLinux: isLinux
}

resource csplan 'Microsoft.Web/serverfarms@2022-09-01' = {
  name: consumption.name
  location: consumption.location
  kind: 'functionApp'
  tags: consumption.tags
  sku: {
    name: 'Y1'
    tier: 'Dynamic'
  }
  properties: {
    reserved: consumption.isLinux
  }
}

output id string = csplan.id
output name string = csplan.name
