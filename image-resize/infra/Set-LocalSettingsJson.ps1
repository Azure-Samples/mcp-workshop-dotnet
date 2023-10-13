# Sets the local.settings.json file for the Azure Function App
Param(
    [string]
    [Parameter(Mandatory=$false)]
    $Directory = "image-resize",

    [string]
    [Parameter(Mandatory=$false)]
    $AzureEnvName = "",

    [switch]
    [Parameter(Mandatory=$false)]
    $Help
)

function Show-Usage {
    Write-Output "    This sets the local.settings.json file for the Azure Function App

    Usage: $(Split-Path $MyInvocation.ScriptName -Leaf) ``
            [-Directory <directory>] ``
            [-AzureEnvName <azure env name>] ``

            [-Help]

    Options:
        -Directory     app directory name. Default is `image-resize`.
        -AzureEnvName  Azure environment name.

        -Help:          Show this message.
"

    Exit 0
}

# Show usage
$needHelp = ($Help -eq $true) -or ($Directory -eq "") -or ($AzureEnvName -eq "")
if ($needHelp -eq $true) {
    Show-Usage
    Exit 0
}

$capitalised = [CultureInfo]::GetCultureInfo("en-AU").TextInfo.ToTitleCase($Directory.Replace("-", " ")).Replace(" ", "")

$localSettings = Get-Content -Path "./src/$capitalised/local.settings.sample.json" | ConvertFrom-Json

$rgName = "rg-$AzureEnvName"

$storageConnection = az storage account show-connection-string -g $rgName -n $stName --query "connectionString" -o tsv

$localSettings.Values.StorageConnection = $storageConnection

$localSettings | ConvertTo-Json -Depth 100 | Out-File -FilePath "./src/$capitalised/local.settings.json" -Encoding utf8 -Force
