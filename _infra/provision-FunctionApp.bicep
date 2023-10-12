param name string
param location string = resourceGroup().location

param tags object = {}

param blobContainerName string = 'container'
param isLinux bool = false
param dotnetVersion string = '8.0'
param appEnvSettings array = [
  {
    name: ''
    value: ''
  }
]

module st './storageAccount.bicep' = {
  name: 'FunctionApp_StorageAccount'
  params: {
    name: name
    location: location
    tags: tags
    blobContainerName: blobContainerName
  }
}

module wrkspc './logAnalyticsWorkspace.bicep' = {
  name: 'FunctionApp_LogAnalyticsWorkspace'
  params: {
    name: name
    location: location
    tags: tags
  }
}

module appins './applicationInsights.bicep' = {
  name: 'FunctionApp_ApplicationInsights'
  params: {
    name: name
    location: location
    workspaceId: wrkspc.outputs.id
    tags: tags
  }
}

module csplan './consumptionPlan.bicep' = {
  name: 'FunctionApp_ConsumptionPlan'
  params: {
    name: name
    location: location
    tags: tags
  }
}

module fncapp './functionApp.bicep' = {
  name: 'FunctionApp_FunctionApp'
  params: {
    name: name
    location: location
    tags: tags
    storageAccountConnectionString: st.outputs.connectionString
    appInsightsInstrumentationKey: appins.outputs.instrumentationKey
    appInsightsConnectionString: appins.outputs.connectionString
    consumptionPlanId: csplan.outputs.id
    isLinux: isLinux
    dotnetVersion: dotnetVersion
    appEnvSettings: concat(appEnvSettings, [
      {
        name: 'StorageConnection'
        value: st.outputs.connectionString
      }
      {
        name: 'StorageAccountName'
        value: st.outputs.name
      }
    ])
  }
}
