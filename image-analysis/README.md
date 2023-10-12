# Image Analysis with Computer Vision

This sample [Azure Functions (isolated worker)](https://learn.microsoft.com/azure/azure-functions/dotnet-isolated-process-guide) app analyzes images uploaded on [Azure Blob Storage](https://learn.microsoft.com/azure/storage/blobs/storage-blobs-overview), using [Azure Computer Vision &ndash; Image Analysis Service](https://learn.microsoft.com/azure/ai-services/computer-vision/overview-image-analysis).

## Prerequisites

- [Azure Subscription](https://azure.microsoft.com/free)
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Azure Functions Core Tools](https://docs.microsoft.com/azure/azure-functions/functions-run-local) v4 &ndash; 4.0.5000 or later
- [Visual Studio](https://visualstudio.microsoft.com/vs) or [Visual Studio Code](https://code.visualstudio.com) with [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)
- [Azure Developer CLI](https://learn.microsoft.com/azure/developer/azure-developer-cli/overview)
- [Azure CLI](https://learn.microsoft.com/cli/azure/what-is-azure-cli)
- [GitHub CLI](https://docs.github.com/github-cli/github-cli/about-github-cli)
- [PowerShell](https://learn.microsoft.com/powershell/scripting/overview) v7 or later

## Getting Started

### Provision Resources to Azure

1. Fork this repository to your GitHub account and clone it to your local PC.
1. Run the commands below to set up a resource names:

   ```bash
   # PowerShell
   $AZURE_ENV_NAME="analysis$(Get-Random -Min 1000 -Max 9999)"
   $GITHUB_USERNAME="{{GITHUB_USERNAME}}"
   $GITHUB_REPOSITORY_NAME="{{GITHUB_REPOSITORY_NAME}}"

   # Bash
   AZURE_ENV_NAME="analysis$RANDOM"
   GITHUB_USERNAME="{{GITHUB_USERNAME}}"
   GITHUB_REPOSITORY_NAME="{{GITHUB_REPOSITORY_NAME}}"
   ```

   > **NOTE**: Replace `{{GITHUB_USERNAME}}` and `{{GITHUB_REPOSITORY_NAME}}` with your GitHub username and repository name. The repository name should be the same as the one you forked unless you changed it.

1. Run the commands below to provision Azure resources:

   ```bash
   azd auth login
   azd init -e $AZURE_ENV_NAME
   azd up
   ```

### Deploy Application to Azure

1. Run the commands below to deploy apps to Azure:

   ```bash
   az login
   gh auth login
   azd pipeline config

   # PowerShell
   $WORKFLOW_PAYLOAD = '{ "directory": "image-analysis" }'
   echo $WORKFLOW_PAYLOAD | gh workflow run "Azure Dev" --repo $GITHUB_USERNAME/$GITHUB_REPOSITORY_NAME --json

   # Bash
   WORKFLOW_PAYLOAD='{ "directory": "image-analysis" }'
   echo $WORKFLOW_PAYLOAD | gh workflow run "Azure Dev" --repo $GITHUB_USERNAME/$GITHUB_REPOSITORY_NAME --json
   ```

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
   pushd src/ImageAnalysis

   func start

   popd
   ```
