# 03: Servidor MCP Remoto

En este paso, estás desplegando el servidor MCP a Azure.

## Requisitos Previos

Consulta el documento [README](../README.md#requisitos-previos) para la preparación.

## Comenzando

- [Contenerizar Servidor MCP con `Dockerfile`](#contenerizar-servidor-mcp-con-dockerfile)
- [Desplegar Servidor MCP a Azure con `azd`](#desplegar-servidor-mcp-a-azure-con-azd)

## Contenerizar Servidor MCP con `Dockerfile`

En la [sesión anterior](./02-mcp-server.md), ya has creado una aplicación de servidor MCP. Sigamos usándola.

1. Asegúrate de que Docker Desktop esté funcionando.
1. Asegúrate de tener la variable de entorno `$REPOSITORY_ROOT`.

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. Navega al proyecto de la aplicación.

    ```bash
    cd $REPOSITORY_ROOT/workshop
    ```

1. Crea un `Dockerfile`.

    ```bash
    # bash/zsh
    touch Dockerfile
    ```

    ```powershell
    # PowerShell
    New-Item -Type File -Path Dockerfile -Force
    ```

1. Abre `Dockerfile`, agrega las líneas de código a continuación y guárdalo.

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

1. Construye una imagen de contenedor.

    ```bash
    docker build -f Dockerfile -t mcp-todo-http:latest .
    ```

1. Ejecuta la imagen del contenedor.

    ```bash
    docker run -d -p 8080:8080 mcp-todo-http:latest
    ```

1. Abre `.vscode/mcp.json` y reemplaza la URL del servidor MCP con el servidor MCP contenerizado.

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
          // Antes
          "url": "http://localhost:5242/mcp"

          // Después
          "url": "http://localhost:8080/mcp"
        }
      }
    }
    ```

1. Inicia el servidor MCP, `mcp-todo`, y pruébalo siguiendo [este documento](./02-mcp-server.md#probar-servidor-mcp).
1. Una vez que la prueba termine, detén el contenedor y elimínalo.

    ```bash
    docker stop $(docker ps -q --filter ancestor=mcp-todo-http)
    docker rm $(docker ps -a -q --filter ancestor=mcp-todo-http)
    ```

## Desplegar Servidor MCP a Azure con `azd`

1. Asegúrate de haber iniciado sesión en Azure.

    ```bash
    azd auth login --check-status
    ```

   Si no has iniciado sesión aún, ejecuta `azd auth login` con tu cuenta de Azure.

1. Asegúrate de tener la variable de entorno `$REPOSITORY_ROOT`.

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. Navega al proyecto de la aplicación.

    ```bash
    cd $REPOSITORY_ROOT/workshop
    ```

1. Inicializa la plantilla `azd`.

    ```bash
    azd init
    ```

   Hace varias preguntas. Selecciona las opciones siguientes:

   - `? How do you want to initialize your app?` 👉 `> Scan current directory`
   - `? Select an option` 👉 `> Confirm and continue initializing my app`

   Luego, crea el archivo `azure.yaml`.

1. Abre el archivo `azure.yaml` y actualízalo con las siguientes líneas de código.

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

            # 👇👇👇 Agregar 👇👇👇
            docker:
                path: ../../Dockerfile
                context: ../../
                remoteBuild: true
            # 👆👆👆 Agregar 👆👆👆

    resources:
        mcptodoserver-containerapp:
            type: host.containerapp
            port: 8080
    ```

1. Despliega el servidor MCP.

    ```bash
    azd up
    ```

   Hace varias preguntas:

   - `? Enter a unique environment name` 👉 Ingresa cualquier nombre. Por ejemplo, `mcp-todo-http-123456`
   - `? Select an Azure Subscription to use` 👉 Elige tu suscripción de Azure a usar.
   - `? Enter a value for the 'location' infrastructure parameter` 👉 Elige la ubicación para desplegar el servidor MCP.

1. Una vez completado, puedes encontrar la URL del servidor MCP en la terminal, que se ve como `https://mcptodoserver-containerapp.cherryblossom-xyz1234q.koreacentral.azurecontainerapps.io/`. Toma nota de esta URL.
1. Abre `.vscode/mcp.json` y reemplaza la URL del servidor MCP con el servidor MCP desplegado. `{{azure-container-apps-url}}` debe ser reemplazado con la URL tomada del paso anterior.

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
          // Antes
          "url": "http://localhost:8080/mcp"

          // Después
          "url": "http://{{azure-container-apps-url}}/mcp"
        }
      }
    }
    ```

1. Inicia el servidor MCP, `mcp-todo`, y pruébalo siguiendo [este documento](./02-mcp-server.md#probar-servidor-mcp).

---

Perfecto. Has completado el paso "Despliegue del Servidor MCP Remoto". Ahora vamos al [PASO 04: Cliente MCP](./04-mcp-client.md).

---

Este documento ha sido localizado por [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot). Por lo tanto, puede contener errores. Si encuentras alguna traducción inapropiada o errónea, por favor crea un [issue](../../../../../issues).
