sudo apt-get update && \
    sudo apt upgrade -y && \
    sudo apt-get install -y dos2unix libsecret-1-0 xdg-utils && \
    sudo apt clean -y && \
    sudo rm -rf /var/lib/apt/lists/*

echo Configure git
git config --global pull.rebase false
git config --global core.autocrlf input

echo Install .NET dev certs
dotnet dev-certs https --trust

echo Uninstall old .NET Aspire workload
dotnet workload uninstall aspire

echo Install .NET Aspire Template
dotnet new install Aspire.ProjectTemplates

echo Install .NET AI Template
dotnet new install Microsoft.Extensions.AI.Templates      

echo Install Azure Bicep
az bicep install

echo Done!
