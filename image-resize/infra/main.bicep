targetScope = 'subscription'

param name string
param location string

// tags that should be applied to all resources.
var tags = {
  // Tag all resources with the environment name.
  'azd-env-name': name
}

var blobContainers = [
  {
    name: 'images'
  }
  {
    name: 'thumbnails'
  }
]

resource rg 'Microsoft.Resources/resourceGroups@2021-04-01' = {
  name: 'rg-${name}'
  location: location
  tags: tags
}

module st '../../_infra/storageAccount.bicep' = {
  name: 'StorageAccount'
  scope: rg
  params: {
    name: name
    location: location
    tags: tags
    blobContainers: blobContainers
  }
}

module wrkspc '../../_infra/logAnalyticsWorkspace.bicep' = {
  name: 'LogAnalyticsWorkspace'
  scope: rg
  params: {
    name: name
    location: location
    tags: tags
  }
}

module appins '../../_infra/applicationInsights.bicep' = {
  name: 'ApplicationInsights'
  scope: rg
  params: {
    name: name
    location: location
    workspaceId: wrkspc.outputs.id
    tags: tags
  }
}

module csplan '../../_infra/consumptionPlan.bicep' = {
  name: 'ConsumptionPlan'
  scope: rg
  params: {
    name: name
    location: location
    tags: tags
  }
}

module fncapp '../../_infra/functionApp.bicep' = {
  name: 'FunctionApp'
  scope: rg
  params: {
    name: name
    location: location
    tags: tags
    storageAccountConnectionString: st.outputs.connectionString
    appInsightsInstrumentationKey: appins.outputs.instrumentationKey
    appInsightsConnectionString: appins.outputs.connectionString
    consumptionPlanId: csplan.outputs.id
    isLinux: false
    dotnetVersion: '8.0'
    appEnvSettings: [
      {
        name: 'StorageConnection'
        value: st.outputs.connectionString
      }
      {
        name: 'ThumbnailWidth'
        value: 250
      }
      {
        name: 'ThumbnailContainerName'
        value: 'thumbnails'
      }
    ]
  }
}

module evtgrd '../../_infra/eventGridSystemTopic.bicep' = {
  name: 'EventGridSystemTopic'
  scope: rg
  params: {
    name: name
    location: location
    tags: tags
    topicType: 'Microsoft.Storage.StorageAccounts'
    source: st.outputs.id
    subscriptions: [
      {
        name: 'evtgrd-${name}-subscription-{0}-{1}'
        endpointType: 'WebHook'
        includedEventTypes: [
          'Microsoft.Storage.BlobCreated'
          'Microsoft.Storage.BlobDeleted'
        ]
        eventDeliverySchema: 'CloudEventSchemaV1_0'
      }
    ]
  }
}
