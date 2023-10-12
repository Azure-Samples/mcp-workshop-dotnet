param name string
param location string = resourceGroup().location

param tags object = {}

param skuName string = 'PerGB2018'

var workspace = {
  name: 'wrkspc-${name}'
  location: location
  tags: tags
  sku: {
    name: skuName
  }
}

resource wrkspc 'Microsoft.OperationalInsights/workspaces@2022-10-01' = {
  name: workspace.name
  location: workspace.location
  tags: workspace.tags
  properties: {
    sku: {
      name: workspace.sku.name
    }
    retentionInDays: 30
    workspaceCapping: {
      dailyQuotaGb: -1
    }
    publicNetworkAccessForIngestion: 'Enabled'
    publicNetworkAccessForQuery: 'Enabled'
  }
}

output id string = wrkspc.id
output name string = wrkspc.name
