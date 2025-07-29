# 03 : Serveur MCP Distant

Dans cette étape, vous déployez le serveur MCP sur Azure.

## Prérequis

Référez-vous au document [README](../README.md#prérequis) pour la préparation.

## Commencer

- [Conteneuriser le Serveur MCP avec `Dockerfile`](#conteneuriser-le-serveur-mcp-avec-dockerfile)
- [Déployer le Serveur MCP sur Azure avec `azd`](#déployer-le-serveur-mcp-sur-azure-avec-azd)

## Conteneuriser le Serveur MCP avec `Dockerfile`

Dans la [session précédente](./01-mcp-server.md), vous avez déjà créé une application serveur MCP. Continuons à l'utiliser.

1. Assurez-vous que Docker Desktop est en cours d'exécution.
1. Assurez-vous d'avoir la variable d'environnement `$REPOSITORY_ROOT`.

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. Naviguez vers le projet d'application.

    ```bash
    cd $REPOSITORY_ROOT/workshop
    ```

1. Créez un `Dockerfile`.

    ```bash
    # bash/zsh
    touch Dockerfile
    ```

    ```powershell
    # PowerShell
    New-Item -Type File -Path Dockerfile -Force
    ```

1. Ouvrez `Dockerfile`, ajoutez les lignes de code ci-dessous et sauvegardez-le.

    ```dockerfile
    # syntax=docker/dockerfile:1
    
    FROM mcr.microsoft.com/dotnet/sdk:9.0-alpine AS build
    
    COPY . /source
    
    WORKDIR /source/src/McpTodoServer.ContainerApp
    
    RUN dotnet publish -c Release -o /app
    
    FROM mcr.microsoft.com/dotnet/aspnet:9.0-alpine AS final
    
    WORKDIR /app
    
    COPY --from=build /app .
    
    USER $APP_UID
    
    ENTRYPOINT ["dotnet", "McpTodoServer.ContainerApp.dll"]
    ```

1. Construisez une image de conteneur.

    ```bash
    docker build -f Dockerfile -t mcp-todo-http:latest .
    ```

1. Exécutez l'image du conteneur.

    ```bash
    docker run -d -p 8080:8080 mcp-todo-http:latest
    ```

1. Ouvrez `.vscode/mcp.json` et remplacez l'URL du serveur MCP par le serveur MCP conteneurisé.

    ```jsonc
    {
      "servers": {
        "context7": {
          "command": "npx",
          "args": [
            "-y",
            "@upstash/context7-mcp"
          ]
        },
        "mcp-todo": {
          // Avant
          "url": "http://localhost:5242/mcp"

          // Après
          "url": "http://localhost:8080/mcp"
        }
        // 👆👆👆 Ajouter 👆👆👆
      }
    }
    ```

1. Démarrez le serveur MCP, `mcp-todo`, et testez-le en suivant [ce document](./01-mcp-server.md#tester-le-serveur-mcp).
1. Une fois le test terminé, arrêtez le conteneur et supprimez-le.

    ```bash
    docker stop $(docker ps -q --filter ancestor=mcp-todo-http)
    docker rm $(docker ps -a -q --filter ancestor=mcp-todo-http)
    ```

## Déployer le Serveur MCP sur Azure avec `azd`

1. Assurez-vous d'être connecté à Azure.

    ```bash
    azd auth login --check-status
    ```

   Si vous ne vous êtes pas encore connecté, exécutez `azd auth login` avec votre compte Azure.

1. Assurez-vous d'avoir la variable d'environnement `$REPOSITORY_ROOT`.

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. Naviguez vers le projet d'application.

    ```bash
    cd $REPOSITORY_ROOT/workshop
    ```

1. Initialisez le modèle `azd`.

    ```bash
    azd init
    ```

   Il pose plusieurs questions. Sélectionnez les options suivantes :

   - `? How do you want to initialize your app?` 👉 `> Scan current directory`
   - `? Select an option` 👉 `> Confirm and continue initializing my app`

   Ensuite, il crée le fichier `azure.yaml`.

1. Ouvrez le fichier `azure.yaml` et mettez-le à jour avec les lignes de code suivantes.

    ```yml
    # yaml-language-server: $schema=https://raw.githubusercontent.com/Azure/azure-dev/main/schemas/v1.0/azure.yaml.json
    
    name: workshop
    metadata:
        template: azd-init@1.17.2
    services:
        mcptodoserver-containerapp:
            project: src/McpTodoServer.ContainerApp
            host: containerapp
            language: dotnet

            # 👇👇👇 Ajouter 👇👇👇
            docker:
                path: ../../Dockerfile
                context: ../../
                remoteBuild: true
            # 👆👆👆 Ajouter 👆👆👆

    resources:
        mcptodoserver-containerapp:
            type: host.containerapp
            port: 8080
    ```

1. Déployez le serveur MCP.

    ```bash
    azd up
    ```

   Il pose plusieurs questions :

   - `? Enter a unique environment name` 👉 Entrez n'importe quel nom. Par exemple, `mcp-todo-http-123456`
   - `? Select an Azure Subscription to use` 👉 Choisissez votre abonnement Azure à utiliser.
   - `? Enter a value for the 'location' infrastructure parameter` 👉 Choisissez l'emplacement pour déployer le serveur MCP.

1. Une fois terminé, vous pouvez trouver l'URL du serveur MCP dans le terminal, qui ressemble à `https://mcptodoserver-containerapp.cherryblossom-xyz1234q.koreacentral.azurecontainerapps.io/`. Prenez note de cette URL.
1. Ouvrez `.vscode/mcp.json` et remplacez l'URL du serveur MCP par le serveur MCP déployé. `{{azure-container-apps-url}}` doit être remplacé par l'URL obtenue à l'étape précédente.

    ```jsonc
    {
      "servers": {
        "context7": {
          "command": "npx",
          "args": [
            "-y",
            "@upstash/context7-mcp"
          ]
        },
        "mcp-todo": {
          // Avant
          "url": "http://localhost:8080/mcp"

          // Après
          "url": "http://{{azure-container-apps-url}}/mcp"
        }
      }
    }
    ```

1. Démarrez le serveur MCP, `mcp-todo`, et testez-le en suivant [ce document](./01-mcp-server.md#tester-le-serveur-mcp).

---

Parfait. Vous avez terminé l'étape "Déploiement du Serveur MCP Distant". Passons maintenant à [ÉTAPE 03 : Client MCP](./03-mcp-client.md).

---

Ce document a été localisé par [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot). Par conséquent, il peut contenir des erreurs. Si vous trouvez une traduction inappropriée ou erronée, veuillez créer un [issue](../../../../../issues).
