param name string
param location string = resourceGroup().location

param tags object = {}

@secure()
param storageAccountConnectionString string

@secure()
param appInsightsInstrumentationKey string
@secure()
param appInsightsConnectionString string

param consumptionPlanId string

param isLinux bool = false
param dotnetVersion string = '8.0'
param appEnvSettings array = [
  {
    name: ''
    value: ''
  }
]

var storage = {
  connectionString: storageAccountConnectionString
}

var appInsights = {
  instrumentationKey: appInsightsInstrumentationKey
  connectionString: appInsightsConnectionString
}

var consumptionPlan = {
  id: consumptionPlanId
}

var functionApp = {
  name: 'fncapp-${name}'
  location: location
  tags: tags
  kind: isLinux ? 'functionapp,linux' : 'functionapp'
  isLinux: isLinux
  siteConfig: {
    netFrameworkVersion: isLinux ? null : 'v${dotnetVersion}'
    linuxFxVersion: isLinux ? 'DOTNET-ISOLATED|${dotnetVersion}' : null
  }
}

var commonSettings = [
  {
    name: 'APPINSIGHTS_INSTRUMENTATIONKEY'
    value: appInsights.instrumentationKey
  }
  {
    name: 'APPLICATIONINSIGHTS_CONNECTION_STRING'
    value: appInsights.connectionString
  }
  {
    name: 'AzureWebJobsStorage'
    value: storage.connectionString
  }
  {
    name: 'FUNCTION_APP_EDIT_MODE'
    value: 'readonly'
  }
  {
    name: 'FUNCTIONS_EXTENSION_VERSION'
    value: '~4'
  }
  {
    name: 'FUNCTIONS_WORKER_RUNTIME'
    value: 'dotnet-isolated'
  }
  {
    name: 'WEBSITE_CONTENTAZUREFILECONNECTIONSTRING'
    value: storage.connectionString
  }
  {
    name: 'WEBSITE_CONTENTSHARE'
    value: functionApp.name
  }
]

var appSettings = concat(commonSettings, appEnvSettings)

resource fncapp 'Microsoft.Web/sites@2022-09-01' = {
  name: functionApp.name
  location: functionApp.location
  kind: functionApp.kind
  tags: functionApp.tags
  properties: {
    serverFarmId: consumptionPlan.id
    httpsOnly: true
    reserved: functionApp.isLinux
    siteConfig: {
      netFrameworkVersion: functionApp.siteConfig.netFrameworkVersion
      linuxFxVersion: functionApp.siteConfig.linuxFxVersion
      appSettings: appSettings
    }
  }
}

var policies = [
  {
    name: 'scm'
    allow: false
  }
  {
    name: 'ftp'
    allow: false
  }
]

resource fncappPolicies 'Microsoft.Web/sites/basicPublishingCredentialsPolicies@2022-09-01' = [for policy in policies: {
  name: policy.name
  parent: fncapp
  properties: {
    allow: policy.allow
  }
}]

output id string = fncapp.id
output name string = fncapp.name
