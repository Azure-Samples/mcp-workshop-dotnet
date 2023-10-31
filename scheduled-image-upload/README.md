# Scheduled Image Upload

This sample [Azure Functions (isolated worker)](https://learn.microsoft.com/azure/azure-functions/dotnet-isolated-process-guide) app uploads images to [Azure Blob Storage](https://learn.microsoft.com/azure/storage/blobs/storage-blobs-overview) for every 5 seconds.

## Prerequisites

- Refer to the [README](../README.md#prerequisites) doc.

## Getting Started

### Provision Resources to Azure

1. Fork this repository to your GitHub account and clone it to your local PC.
1. Run the commands below to set up a resource names:

   ```bash
   # PowerShell
   $AZURE_ENV_NAME="resize$(Get-Random -Min 1000 -Max 9999)"
   $GITHUB_USERNAME="{{GITHUB_USERNAME}}"
   $GITHUB_REPOSITORY_NAME="{{GITHUB_REPOSITORY_NAME}}"

   # Bash
   AZURE_ENV_NAME="resize$RANDOM"
   GITHUB_USERNAME="{{GITHUB_USERNAME}}"
   GITHUB_REPOSITORY_NAME="{{GITHUB_REPOSITORY_NAME}}"
   ```

   > **NOTE**: Replace `{{GITHUB_USERNAME}}` and `{{GITHUB_REPOSITORY_NAME}}` with your GitHub username and repository name. The repository name should be the same as the one you forked unless you changed it.

1. Run the commands below to provision Azure resources:

   ```bash
   azd auth login
   azd init -e $AZURE_ENV_NAME
   azd provision
   ```

### Deploy Application to Azure

1. Run the command below to deploy apps to Azure:

   ```bash
   azd deploy
   ```

1. Alternatively, you can run the commands below to deploy apps to Azure through GitHub Actions:

   ```bash
   az login
   gh auth login
   azd pipeline config

   # PowerShell
   $WORKFLOW_PAYLOAD = '{ "directory": "scheduled-image-upload", "azure-env-name": "{{AZURE_ENV_NAME}}" }'
   echo $WORKFLOW_PAYLOAD | gh workflow run "Azure Dev" --repo $GITHUB_USERNAME/$GITHUB_REPOSITORY_NAME --json

   # Bash
   WORKFLOW_PAYLOAD='{ "directory": "scheduled-image-upload", "azure-env-name": "{{AZURE_ENV_NAME}}" }'
   echo $WORKFLOW_PAYLOAD | gh workflow run "Azure Dev" --repo $GITHUB_USERNAME/$GITHUB_REPOSITORY_NAME --json
   ```

   > **NOTE**: Replace `{{AZURE_ENV_NAME}}` with the actual value of `$AZURE_ENV_NAME`. If you want to directly use the `$AZURE_ENV_NAME` variable, use string interpolation with double-quotes, instead of single-quotes.

### Deprovision Resources from Azure

1. To avoid unexpected billing shock, run the commands below to deprovision Azure resources:

   ```bash
   azd down --force --purge --no-prompt
   ```

### Local Development

1. Run the following command to prepare `local.settings.json`.

   ```bash
   # PowerShell
   ./infra/Set-LocalSettingsJson.ps1 -AzureEnvName $AZURE_ENV_NAME

   # Bash
   pwsh ./infra/Set-LocalSettingsJson.ps1 -AzureEnvName $AZURE_ENV_NAME
   ```

1. Run the following command to start the app.

   ```bash
   pushd src/ImageUpload

   func start

   popd
   ```

#### Local Debugging in Visual Studio

1. Hit the <kbd>F5</kbd> key to start debugging.

#### Local Debugging in Visual Studio Code

1. Hit the <kbd>F5</kbd> key to start debugging.
1. Choose `scheduled-image-upload/src/ImageUpload` to run the function app.
