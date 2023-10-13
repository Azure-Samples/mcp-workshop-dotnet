param name string
param location string = resourceGroup().location

param tags object = {}

param topicType string
param source string
param subscriptions array = [
  {
    name: 'evtgrd-${name}-subscription-{0}-{1}'
    endpointType: 'WebHook'
    includedEventTypes: []
    eventDeliverySchema: 'CloudEventSchemaV1_0'
  }
]

var eventgrid = {
  name: 'evtgrd-${name}-systemtopic'
  location: location
  tags: tags
  topicType: topicType
  source: source
  subscriptions: subscriptions
}

resource evtgrdtopic 'Microsoft.EventGrid/systemTopics@2023-06-01-preview' = {
  name: eventgrid.name
  location: eventgrid.location
  properties: {
    source: eventgrid.source
    topicType: eventgrid.topicType
  }
}

resource evtgrdsubscriptionwebhook 'Microsoft.EventGrid/systemTopics/eventSubscriptions@2023-06-01-preview' = [for sub in eventgrid.subscriptions: if (sub.endpointType == 'WebHook') {
  name: format(sub.name, sub.endpointType, sub.eventDeliverySchema)
  parent: evtgrdtopic
  properties: {
    destination: {
      endpointType: sub.endpointType
    }
    filter: {
      includedEventTypes: sub.includedEventTypes
    }
    eventDeliverySchema: sub.eventDeliverySchema
  }
}]

resource evtgrdsubscriptionfunction 'Microsoft.EventGrid/systemTopics/eventSubscriptions@2023-06-01-preview' = [for sub in eventgrid.subscriptions: if (sub.endpointType == 'AzureFunction') {
  name: format(sub.name, sub.endpointType, sub.eventDeliverySchema)
  parent: evtgrdtopic
  properties: {
    destination: {
      endpointType: sub.endpointType
    }
    filter: {
      includedEventTypes: sub.includedEventTypes
    }
    eventDeliverySchema: sub.eventDeliverySchema
  }
}]
