## Install additional apt packages
sudo apt-get update && \
    sudo apt upgrade -y && \
    sudo apt-get install -y dos2unix libsecret-1-0 xdg-utils && \
    sudo apt clean -y && \
    sudo rm -rf /var/lib/apt/lists/*

## Configure git
git config --global pull.rebase false
git config --global core.autocrlf input

## Enable local HTTPS for .NET
dotnet dev-certs https --trust

## AZURE BICEP CLI ##
# Uncomment the below to install Azure Bicep CLI.
az bicep install

## AZURE DEV CLI ##
# Uncomment the below to install Azure Dev CLI. Make sure you have installed Azure CLI and GitHub CLI
curl -fsSL https://aka.ms/install-azd.sh | bash

## AZURE FUNCTIONS CORE TOOLS ##
# Uncomment the below to install Azure Functions Core Tools. Make sure you have installed node.js
npm i -g azure-functions-core-tools@4 --unsafe-perm true

## Azurite ##
# Uncomment the below to install Azurite. Make sure you have installed node.js
npm install -g azurite
