param name string
param location string = resourceGroup().location

param tags object = {}

param topicType string
param endpointType string = 'WebHook'
param includedEventTypes array = []
@allowed([
  'EventGridSchema'
  'CustomEventSchema'
  'CloudEventSchemaV1_0'
])
param eventDeliverySchema string = 'CloudEventSchemaV1_0'

var eventgrid = {
  name: 'evtgrd-${name}-systemtopic'
  location: location
  tags: tags
  topicType: topicType
  subscriptions: [
    {
      name: 'evtgrd-${name}-subscription-{0}-{1}'
      endpointType: endpointType
      includedEventTypes: includedEventTypes
      eventDeliverySchema: eventDeliverySchema
    }
  ]
}

resource evtgrdtopic 'Microsoft.EventGrid/systemTopics@2023-06-01-preview' = {
  name: eventgrid.name
  location: eventgrid.location
  properties: {
    topicType: eventgrid.topicType
  }
}

resource evtgrdsubscription 'Microsoft.EventGrid/systemTopics/eventSubscriptions@2023-06-01-preview' = [for sub in eventgrid.subscriptions: {
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
