# Servidor MCP: Aplicación de Tareas

Este es un servidor MCP, alojado en [Azure Container Apps](https://learn.microsoft.com/azure/container-apps/overview), que gestiona elementos de lista de tareas.

## Requisitos Previos

- [SDK de .NET 9](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Visual Studio Code](https://code.visualstudio.com/) con
  - Extensión [C# Dev Kit](https://marketplace.visualstudio.com/items/?itemName=ms-dotnettools.csdevkit)
- [Azure CLI](https://learn.microsoft.com/cli/azure/install-azure-cli)
- [Azure Developer CLI](https://learn.microsoft.com/azure/developer/azure-developer-cli/install-azd)
- [Docker Desktop](https://docs.docker.com/get-started/get-docker/)

## Comenzando

- [Ejecutar servidor MCP ASP.NET Core localmente](#ejecutar-servidor-mcp-aspnet-core-localmente)
- [Ejecutar servidor MCP ASP.NET Core localmente en un contenedor](#ejecutar-servidor-mcp-aspnet-core-localmente-en-un-contenedor)
- [Ejecutar servidor MCP ASP.NET Core remotamente](#ejecutar-servidor-mcp-aspnet-core-remotamente)
- [Conectar servidor MCP a un host/cliente MCP](#conectar-servidor-mcp-a-un-hostcliente-mcp)
  - [VS Code + Modo Agente + Servidor MCP local](#vs-code--modo-agente--servidor-mcp-local)
  - [VS Code + Modo Agente + Servidor MCP local en contenedor](#vs-code--modo-agente--servidor-mcp-local-en-contenedor)
  - [VS Code + Modo Agente + Servidor MCP remoto](#vs-code--modo-agente--servidor-mcp-remoto)
  - [MCP Inspector + Servidor MCP local](#mcp-inspector--servidor-mcp-local)
  - [MCP Inspector + Servidor MCP local en contenedor](#mcp-inspector--servidor-mcp-local-en-contenedor)
  - [MCP Inspector + Servidor MCP remoto](#mcp-inspector--servidor-mcp-remoto)

### Ejecutar servidor MCP ASP.NET Core localmente

1. Obtener la raíz del repositorio.

    ```bash
    # bash/zsh
    REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
    ```

    ```powershell
    # PowerShell
    $REPOSITORY_ROOT = git rev-parse --show-toplevel
    ```

1. Ejecutar la aplicación del servidor MCP.

    ```bash
    cd $REPOSITORY_ROOT/todo-list
    dotnet run --project ./src/McpTodoServer.ContainerApp
    ```

### Ejecutar servidor MCP ASP.NET Core localmente en un contenedor

1. Obtener la raíz del repositorio.

    ```bash
    # bash/zsh
    REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
    ```

    ```powershell
    # PowerShell
    $REPOSITORY_ROOT = git rev-parse --show-toplevel
    ```

1. Construir la aplicación del servidor MCP como una imagen de contenedor.

    ```bash
    cd $REPOSITORY_ROOT/todo-list
    docker build -t mcp-todo-list:latest .
    ```

1. Ejecutar la aplicación del servidor MCP en un contenedor

    ```bash
    docker run -d -p 8080:8080 --name mcp-todo-list mcp-todo-list:latest
    ```

### Ejecutar servidor MCP ASP.NET Core remotamente

1. Iniciar sesión en Azure

    ```bash
    # Iniciar sesión con Azure Developer CLI
    azd auth login
    ```

1. Desplegar la aplicación del servidor MCP a Azure

    ```bash
    azd up
    ```

   Durante el aprovisionamiento y despliegue, se te pedirá que proporciones ID de suscripción, ubicación, nombre del entorno.

1. Después de que se complete el despliegue, obtén la información ejecutando los siguientes comandos:

   - FQDN de Azure Container Apps:

     ```bash
     azd env get-value AZURE_RESOURCE_MCP_TODO_LIST_FQDN
     ```

### Conectar servidor MCP a un host/cliente MCP

#### VS Code + Modo Agente + Servidor MCP local

1. Obtener la raíz del repositorio.

    ```bash
    # bash/zsh
    REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
    ```

    ```powershell
    # PowerShell
    $REPOSITORY_ROOT = git rev-parse --show-toplevel
    ```

1. Copiar `mcp.json` a la raíz del repositorio.

    ```bash
    mkdir -p $REPOSITORY_ROOT/.vscode
    cp $REPOSITORY_ROOT/todo-list/.vscode/mcp.json \
       $REPOSITORY_ROOT/.vscode/mcp.json
    ```

    ```powershell
    New-Item -Type Directory -Path $REPOSITORY_ROOT/.vscode -Force
    Copy-Item -Path $REPOSITORY_ROOT/todo-list/.vscode/mcp.json `
              -Destination $REPOSITORY_ROOT/.vscode/mcp.json -Force
    ```

1. Abrir la Paleta de Comandos escribiendo `F1` o `Ctrl`+`Shift`+`P` en Windows o `Cmd`+`Shift`+`P` en Mac OS, y buscar `MCP: List Servers`.
1. Elegir `mcp-todo-list-aca-local` y luego hacer clic en `Start Server`.
1. Introducir prompts. Estos son solo ejemplos:

    ```text
    - Muéstrame la lista de tareas
    - Agregar "reunión a las 11am"
    - Completar el elemento de tarea #1
    - Eliminar el elemento de tarea #2
    ```

1. Confirmar el resultado.

#### VS Code + Modo Agente + Servidor MCP local en contenedor

1. Obtener la raíz del repositorio.

    ```bash
    # bash/zsh
    REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
    ```

    ```powershell
    # PowerShell
    $REPOSITORY_ROOT = git rev-parse --show-toplevel
    ```

1. Copiar `mcp.json` a la raíz del repositorio.

    ```bash
    mkdir -p $REPOSITORY_ROOT/.vscode
    cp $REPOSITORY_ROOT/todo-list/.vscode/mcp.json \
       $REPOSITORY_ROOT/.vscode/mcp.json
    ```

    ```powershell
    New-Item -Type Directory -Path $REPOSITORY_ROOT/.vscode -Force
    Copy-Item -Path $REPOSITORY_ROOT/todo-list/.vscode/mcp.json `
              -Destination $REPOSITORY_ROOT/.vscode/mcp.json -Force
    ```

1. Abrir la Paleta de Comandos escribiendo `F1` o `Ctrl`+`Shift`+`P` en Windows o `Cmd`+`Shift`+`P` en Mac OS, y buscar `MCP: List Servers`.
1. Elegir `mcp-todo-list-aca-container` y luego hacer clic en `Start Server`.
1. Introducir prompts. Estos son solo ejemplos:

    ```text
    - Muéstrame la lista de tareas
    - Agregar "reunión a las 11am"
    - Completar el elemento de tarea #1
    - Eliminar el elemento de tarea #2
    ```

1. Confirmar el resultado.

#### VS Code + Modo Agente + Servidor MCP remoto

1. Abrir la Paleta de Comandos escribiendo `F1` o `Ctrl`+`Shift`+`P` en Windows o `Cmd`+`Shift`+`P` en Mac OS, y buscar `MCP: List Servers`.
1. Elegir `mcp-todo-list-aca-remote` y luego hacer clic en `Start Server`.
1. Introducir el FQDN de Azure Container Apps.
1. Introducir prompts. Estos son solo ejemplos:

    ```text
    - Muéstrame la lista de tareas
    - Agregar "reunión a las 11am"
    - Completar el elemento de tarea #1
    - Eliminar el elemento de tarea #2
    ```

1. Confirmar el resultado.

#### MCP Inspector + Servidor MCP local

1. Ejecutar MCP Inspector.

    ```bash
    npx @modelcontextprotocol/inspector node build/index.js
    ```

1. Abrir un navegador web y navegar a la aplicación web MCP Inspector desde la URL mostrada por la aplicación (ej. http://localhost:6274)
1. Establecer el tipo de transporte como `Streamable HTTP` 
1. Establecer la URL al endpoint Streamable HTTP de tu aplicación Function en ejecución y **Conectar**:

    ```text
    http://0.0.0.0:5242/mcp
    ```

1. Hacer clic en **List Tools**.
1. Hacer clic en una herramienta y **Run Tool** con valores apropiados.

#### MCP Inspector + Servidor MCP local en contenedor

1. Ejecutar MCP Inspector.

    ```bash
    npx @modelcontextprotocol/inspector node build/index.js
    ```

1. Abrir un navegador web y navegar a la aplicación web MCP Inspector desde la URL mostrada por la aplicación (ej. http://localhost:6274)
1. Establecer el tipo de transporte como `Streamable HTTP` 
1. Establecer la URL al endpoint Streamable HTTP de tu aplicación Function en ejecución y **Conectar**:

    ```text
    http://0.0.0.0:8080/mcp
    ```

1. Hacer clic en **List Tools**.
1. Hacer clic en una herramienta y **Run Tool** con valores apropiados.

#### MCP Inspector + Servidor MCP remoto

1. Ejecutar MCP Inspector.

    ```bash
    npx @modelcontextprotocol/inspector node build/index.js
    ```

1. Abrir un navegador web y navegar a la aplicación web MCP Inspector desde la URL mostrada por la aplicación (ej. http://0.0.0.0:6274)
1. Establecer el tipo de transporte como `Streamable HTTP` 
1. Establecer la URL al endpoint Streamable HTTP de tu aplicación Function en ejecución y **Conectar**:

    ```text
    https://<acaapp-server-fqdn>/mcp
    ```

1. Hacer clic en **List Tools**.
1. Hacer clic en una herramienta y **Run Tool** con valores apropiados.

---

Este documento ha sido localizado por [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot). Por lo tanto, puede contener errores. Si encuentras alguna traducción inapropiada o errónea, por favor crea un [issue](../../issues).