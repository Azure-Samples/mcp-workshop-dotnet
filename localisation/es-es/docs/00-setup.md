# 00: Entorno de Desarrollo

En este paso, estás configurando el entorno de desarrollo para el taller.

## Requisitos Previos

Consulta el documento [README](../README.md#prerequisites) para la preparación.

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

1. Baja a la sección [Configurar Servidores MCP](#configurar-servidores-mcp).

**👇👇👇 Si prefieres usar VS Code en tu máquina local, sigue las instrucciones a continuación. La sección de abajo no aplica para quienes usan GitHub Codespaces. 👇👇👇**

## Usar Visual Studio Code

### Instalar PowerShell 👉 Para Usuarios de Windows

Si estás usando Windows, necesitas instalar PowerShell. Si ya tienes PowerShell instalado, puedes omitir este paso.

1. Ve al [sitio web oficial de PowerShell](https://docs.microsoft.com/powershell/scripting/install/installing-powershell) e instala la última versión.

### Instalar git CLI

Si ya tienes git CLI instalado, puedes omitir este paso.

1. Ve al [sitio web oficial de git](https://git-scm.com/downloads) e instala la última versión.

### Instalar GitHub CLI

Si ya tienes GitHub CLI instalado, puedes omitir este paso.

1. Ve al [sitio web oficial de GitHub CLI](https://cli.github.com/) e instala la última versión.

### Instalar Docker Desktop

Si ya tienes Docker Desktop instalado, puedes omitir este paso.

1. Ve al [sitio web oficial de Docker Desktop](https://docs.docker.com/get-started/get-docker/) e instala la última versión.

### Instalar Visual Studio Code

Si ya tienes Visual Studio Code instalado, puedes omitir este paso.

1. Ve al [sitio web oficial de Visual Studio Code](https://code.visualstudio.com/) e instala la última versión.

### Iniciar Visual Studio Code

1. Abre una terminal y ejecuta el siguiente comando para clonar este repositorio:

    ```bash
    git clone https://github.com/Azure-Samples/mcp-workshop-dotnet.git
    ```

1. Navega al directorio del repositorio:

    ```bash
    cd mcp-workshop-dotnet
    ```

1. Abre Visual Studio Code:

    ```bash
    code .
    ```

## Configurar Servidores MCP

En esta sección, estás configurando los servidores MCP para el taller.

1. Instala las extensiones necesarias de Visual Studio Code. Abre Visual Studio Code y ve a la vista de Extensiones (`Ctrl+Shift+X` o `Cmd+Shift+X`).

1. Busca e instala las siguientes extensiones:
   - **C# Dev Kit** - Para desarrollo .NET
   - **GitHub Copilot** - Para asistencia de IA

1. Una vez instaladas, reinicia Visual Studio Code.

1. Instala los paquetes npm necesarios ejecutando el siguiente comando en la terminal:

    ```bash
    npm install -g @modelcontextprotocol/inspector
    ```

## Verificar Modo Agente de GitHub Copilot

1. Haz clic en el icono de GitHub Copilot en la parte superior de GitHub Codespace o VS Code y abre la ventana de GitHub Copilot.

   ![Open GitHub Copilot Chat](../../../docs/images/setup-02.png)

1. Si se te pide iniciar sesión o registrarte, hazlo. Es gratuito.
1. Asegúrate de estar usando el Modo Agente de GitHub Copilot.

   ![GitHub Copilot Agent Mode](../../../docs/images/setup-03.png)

1. Selecciona el modelo como `GPT-4.1` o `Claude Sonnet 4`.

---

Perfecto. Has completado el paso "Entorno de Desarrollo". Ahora vamos al [PASO 01: Servidor MCP](./01-mcp-server.md).

---

Este documento ha sido localizado por [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot). Por lo tanto, puede contener errores. Si encuentras alguna traducción inapropiada o errónea, por favor crea un [issue](../../../issues).