# 00: Entorno de Desarrollo

En este paso, estás configurando el entorno de desarrollo para el taller.

## Requisitos Previos

Consulta el documento [README](../README.md#requisitos-previos) para la preparación.

## Comenzando

- [Usar GitHub Codespaces](#usar-github-codespaces)
- [Usar Visual Studio Code](#usar-visual-studio-code)
  - [Instalar PowerShell 👉 Para Usuarios de Windows](#instalar-powershell--para-usuarios-de-windows)
  - [Instalar git CLI](#instalar-git-cli)
  - [Instalar GitHub CLI](#instalar-github-cli)
  - [Instalar Docker Desktop](#instalar-docker-desktop)
  - [Instalar Visual Studio Code](#instalar-visual-studio-code)
  - [Iniciar Visual Studio Code](#iniciar-visual-studio-code)
- [Configurar Servidores MCP](#configurar-servidores-mcp)
- [Verificar Modo Agente de GitHub Copilot](#verificar-modo-agente-de-github-copilot)

## Usar GitHub Codespaces

1. Haz clic en este enlace 👉 [![Open in GitHub Codespaces](https://github.com/codespaces/badge.svg)](https://codespaces.new/Azure-Samples/mcp-workshop-dotnet)

1. Una vez que la instancia de GitHub Codespace esté lista, abre una terminal y ejecuta los siguientes comandos para verificar que todo lo que necesitas haya sido instalado correctamente.

    ```bash
    # Node.js
    node --version
    npm --version
    ```

    ```bash
    # .NET SDK
    dotnet --list-sdks
    ```

    ```bash
    # PowerShell
    pwsh --version
    ```

1. Verifica el estado de tu repositorio.

    ```bash
    git remote -v
    ```

   Deberías ver la siguiente salida:

    ```bash
    origin  https://github.com/Azure-Samples/mcp-workshop-dotnet.git (fetch)
    origin  https://github.com/Azure-Samples/mcp-workshop-dotnet.git (push)
    ```

   Si ves algo diferente de lo anterior, elimina la instancia de GitHub Codespace y vuelve a crearla.

1. Ejecuta el siguiente comando para hacer fork de este repositorio a tu cuenta de GitHub.

    ```bash
    git remote -v > remote.txt
    git add . && git commit -m "Add remote.txt for forking"
    ```

   Podrías ver un mensaje como el siguiente:

    ```text
    You don't have write access to the Azure-Samples/mcp-workshop-dotnet repository, so you cannot push changes to it.
    To obtain write access we will point this codespace at your fork of Azure-Samples/mcp-workshop-dotnet, creating that fork if it doesn't exist.

    Would you like to proceed?
    ```

   Ingresa `y`, y automáticamente hará fork de este repositorio a tu cuenta de GitHub.

1. Verifica el repositorio remoto nuevamente.

    ```bash
    git remote -v
    ```

   Deberías poder ver tanto `origin` como `upstream`.

    ```text
    origin  https://github.com/<your GitHub ID>/mcp-workshop-dotnet.git (fetch)
    origin  https://github.com/<your GitHub ID>/mcp-workshop-dotnet.git (push)
    upstream        https://github.com/Azure-Samples/mcp-workshop-dotnet (fetch)
    upstream        https://github.com/Azure-Samples/mcp-workshop-dotnet (push)
    ```

1. Baja a la sección [Configurar Servidores MCP](#configurar-servidores-mcp).

**👇👇👇 Si prefieres usar VS Code en tu máquina local, sigue las instrucciones a continuación. La sección de abajo no aplica para quienes usan GitHub Codespaces. 👇👇👇**

## Usar Visual Studio Code

### Instalar PowerShell 👉 Para Usuarios de Windows

1. Verifica si ya tienes PowerShell instalado.

    ```bash
    # Bash/Zsh
    which pwsh
    ```

    ```bash
    # PowerShell
    Get-Command pwsh
    ```

   Si no ves la ruta del comando `pwsh`, significa que aún no has instalado PowerShell. Visita la [página de instalación de PowerShell](https://learn.microsoft.com/powershell/scripting/install/installing-powershell) y sigue las instrucciones.

1. Verifica la versión de tu PowerShell.

    ```bash
    pwsh --version
    ```

   Se recomienda la versión `7.5.0` o superior. Si tu versión es inferior, visita la [página de instalación de PowerShell](https://learn.microsoft.com/powershell/scripting/install/installing-powershell) y sigue las instrucciones.

### Instalar node.js

1. Verifica si ya tienes node.js instalado.

    ```bash
    # Bash/Zsh
    which node
    ```

    ```bash
    # PowerShell
    Get-Command node
    ```

   Si no ves la ruta del comando `node`, significa que aún no has instalado node.js. Visita la [página de descarga de node.js](https://nodejs.org/en/download) y sigue las instrucciones.

1. Verifica la versión de tu node.js.

    ```bash
    node --version
    ```

   Se recomienda la versión `22.17.x` (LTS más reciente). Si tu versión es inferior, visita la [página de descarga de node.js](https://nodejs.org/en/download) y sigue las instrucciones.

### Instalar git CLI

1. Verifica si ya tienes git CLI instalado.

    ```bash
    # Bash/Zsh
    which git
    ```

    ```bash
    # PowerShell
    Get-Command git
    ```

   Si no ves la ruta del comando `git`, significa que aún no has instalado git CLI. Visita la [página de instalación de git CLI](https://git-scm.com/downloads) y sigue las instrucciones.

1. Verifica la versión de tu git CLI.

    ```bash
    git --version
    ```

   Se recomienda la versión `2.39.0` o superior. Si tu versión es inferior, visita la [página de instalación de git CLI](https://git-scm.com/downloads) y sigue las instrucciones.

### Instalar GitHub CLI

1. Verifica si ya tienes GitHub CLI instalado.

    ```bash
    # Bash/Zsh
    which gh
    ```

    ```bash
    # PowerShell
    Get-Command gh
    ```

   Si no ves la ruta del comando `gh`, significa que aún no has instalado GitHub CLI. Visita la [página de instalación de GitHub CLI](https://cli.github.com/) y sigue las instrucciones.

1. Verifica la versión de tu GitHub CLI.

    ```bash
    gh --version
    ```

   Se recomienda la versión `2.65.0` o superior. Si tu versión es inferior, visita la [página de instalación de GitHub CLI](https://cli.github.com/) y sigue las instrucciones.

1. Verifica si has iniciado sesión en GitHub.

    ```bash
    gh auth status
    ```

   Si aún no has iniciado sesión, ejecuta `gh auth login` e inicia sesión.

### Instalar Docker Desktop

1. Verifica si ya tienes Docker Desktop instalado.

    ```bash
    # Bash/Zsh
    which docker
    ```

    ```bash
    # PowerShell
    Get-Command docker
    ```

   Si no ves la ruta del comando `docker`, significa que aún no has instalado Docker Desktop. Visita la [página de instalación de Docker Desktop](https://docs.docker.com/get-started/introduction/get-docker-desktop/) y sigue las instrucciones.

1. Verifica la versión de tu Docker CLI.

    ```bash
    docker --version
    ```

   Se recomienda la versión `28.0.4` o superior. Si tu versión es inferior, visita la [página de instalación de Docker Desktop](https://docs.docker.com/get-started/introduction/get-docker-desktop/) y sigue las instrucciones.

### Instalar Visual Studio Code

1. Verifica si ya tienes VS Code instalado.

    ```bash
    # Bash/Zsh
    which code
    ```

    ```bash
    # PowerShell
    Get-Command code
    ```

   Si no ves la ruta del comando `code`, significa que aún no has instalado VS Code. Visita la [página de instalación de Visual Studio Code](https://code.visualstudio.com/) y sigue las instrucciones.

1. Verifica la versión de tu VS Code.

    ```bash
    code --version
    ```

   Se recomienda la versión `1.99.0` o superior. Si tu versión es inferior, visita la [página de instalación de Visual Studio Code](https://code.visualstudio.com/) y sigue las instrucciones.

   > **NOTA**: Es posible que no puedas ejecutar el comando `code`. En este caso, sigue [este documento](https://code.visualstudio.com/docs/setup/mac#_launching-from-the-command-line) para la configuración.

### Iniciar Visual Studio Code

1. Crea un directorio de trabajo.
1. Ejecuta el comando para hacer fork de este repositorio y clonarlo en tu máquina local.

    ```bash
    gh repo fork Azure-Samples/mcp-workshop-dotnet --clone
    ```

1. Navega al directorio clonado.

    ```bash
    cd mcp-workshop-dotnet
    ```

1. Ejecuta VS Code desde la terminal.

    ```bash
    code .
    ```

1. Abre una nueva terminal dentro de VS Code y ejecuta el siguiente comando para verificar el estado de tu repositorio.

    ```bash
    git remote -v
    ```

   Deberías ver la siguiente salida. Si ves `Azure-Samples` en el `origin`, deberías clonarlo nuevamente desde tu repositorio forkeado.

    ```bash
    origin  https://github.com/<your GitHub ID>/mcp-workshop-dotnet.git (fetch)
    origin  https://github.com/<your GitHub ID>/mcp-workshop-dotnet.git (push)
    upstream        https://github.com/Azure-Samples/mcp-workshop-dotnet.git (fetch)
    upstream        https://github.com/Azure-Samples/mcp-workshop-dotnet.git (push)
    ```

1. Verifica si ambas extensiones han sido instaladas: [GitHub Copilot](https://marketplace.visualstudio.com/items?itemName=GitHub.copilot) y [GitHub Copilot Chat](https://marketplace.visualstudio.com/items?itemName=GitHub.copilot-chat).

    ```bash
    # Bash/Zsh
    code --list-extensions | grep github.copilot
    ```

    ```powershell
    # PowerShell
    code --list-extensions | Select-String "github.copilot"
    ```

   Si no ves nada, significa que aún no has instalado esas extensiones. Ejecuta el siguiente comando para instalar las extensiones.

    ```bash
    code --install-extension "github.copilot" --force && code --install-extension "github.copilot-chat" --force
    ```

## Configurar Servidores MCP

1. Establece la variable de entorno `$REPOSITORY_ROOT`.

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. Copia la configuración del servidor MCP.

    ```bash
    # bash/zsh
    mkdir -p $REPOSITORY_ROOT/.vscode
    cp -r $REPOSITORY_ROOT/docs/.vscode/. \
          $REPOSITORY_ROOT/.vscode/
    ```

    ```powershell
    # PowerShell
    New-Item -ItemType Directory -Path $REPOSITORY_ROOT/.vscode -Force
    Copy-Item -Path $REPOSITORY_ROOT/docs/.vscode/* `
              -Destination $REPOSITORY_ROOT/.vscode/ -Recurse -Force
    ```

## Verificar Modo Agente de GitHub Copilot

1. Haz clic en el icono de GitHub Copilot en la parte superior de GitHub Codespace o VS Code y abre la ventana de GitHub Copilot.

   ![Open GitHub Copilot Chat](../../../docs/images/setup-01.png)

1. Si se te pide iniciar sesión o registrarte, hazlo. Es gratuito.
1. Asegúrate de estar usando el Modo Agente de GitHub Copilot.

   ![GitHub Copilot Agent Mode](../../../docs/images/setup-02.png)

1. Selecciona el modelo como `GPT-4.1` o `Claude Sonnet 4`.

---

Perfecto. Has completado el paso "Entorno de Desarrollo". Ahora vamos al [PASO 01: Servidor MCP](./01-mcp-server.md).

---

Este documento ha sido localizado por [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot). Por lo tanto, puede contener errores. Si encuentras alguna traducción inapropiada o errónea, por favor crea un [issue](../../../../../issues).