param name string
param location string = resourceGroup().location

param tags object = {}

param workspaceId string

var workspace = {
  id: workspaceId
}

var appInsights = {
  name: 'appins-${name}'
  location: location
  tags: tags
}

resource appins 'Microsoft.Insights/components@2020-02-02' = {
  name: appInsights.name
  location: appInsights.location
  kind: 'web'
  tags: appInsights.tags
  properties: {
    Application_Type: 'web'
    Flow_Type: 'Bluefield'
    IngestionMode: 'LogAnalytics'
    Request_Source: 'rest'
    WorkspaceResourceId: workspace.id
  }
}

output id string = appins.id
output name string = appins.name
output instrumentationKey string = appins.properties.InstrumentationKey
output connectionString string = appins.properties.ConnectionString
