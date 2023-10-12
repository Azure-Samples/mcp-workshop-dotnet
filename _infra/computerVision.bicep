param name string
param location string = resourceGroup().location

param tags object = {}

param skuName string = 'S1'

var computerVision = {
  name: 'comvsn-${name}'
  location: location
  tags: tags
  sku: {
    name: skuName
  }
}


resource comvsn 'Microsoft.CognitiveServices/accounts@2023-05-01' = {
  name: computerVision.name
  location: computerVision.location
  kind: 'ComputerVision'
  tags: computerVision.tags
  sku: {
    name: computerVision.sku.name
  }
  properties: {
    customSubDomainName: computerVision.name
    publicNetworkAccess: 'Enabled'
  }
}

output id string = comvsn.id
output name string = comvsn.name
output region string = comvsn.location
output endpoint string = comvsn.properties.endpoint
output apiKey string = listKeys(comvsn.id, '2023-05-01').key1
