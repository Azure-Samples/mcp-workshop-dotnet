param name string
param location string = resourceGroup().location

param tags object = {}

param skuName string = 'Standard_LRS'
param blobName string = 'default'
param blobContainerName string = 'container'

var storage = {
  name: 'st${name}'
  location: location
  tags: tags
  sku: {
    name: skuName
  }
  blob: {
    name: blobName
    container: {
      name: blobContainerName
    }
  }
}

resource st 'Microsoft.Storage/storageAccounts@2023-01-01' = {
  name: storage.name
  location: storage.location
  kind: 'StorageV2'
  tags: storage.tags
  sku: {
    name: storage.sku.name
  }
  properties: {
    supportsHttpsTrafficOnly: true
    allowBlobPublicAccess: true
    allowSharedKeyAccess: true
  }
}

resource stblob 'Microsoft.Storage/storageAccounts/blobServices@2023-01-01' = {
  name: storage.blob.name
  parent: st
  properties: {
    deleteRetentionPolicy: {
      enabled: false
    }
  }
}

resource stblobcontainer 'Microsoft.Storage/storageAccounts/blobServices/containers@2023-01-01' = {
  name: storage.blob.container.name
  parent: stblob
  properties: {
    immutableStorageWithVersioning: {
      enabled: false
    }
    defaultEncryptionScope: '$account-encryption-key'
    denyEncryptionScopeOverride: false
    publicAccess: 'Blob'
  }
}

output id string = st.id
output name string = st.name
output connectionString string = 'DefaultEndpointsProtocol=https;AccountName=${st.name};EndpointSuffix=${environment().suffixes.storage};AccountKey=${listKeys(st.id, '2023-01-01').keys[0].value}'
