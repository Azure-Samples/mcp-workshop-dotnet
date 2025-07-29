# 01: Desarrollo de Aplicación Monkey con MCP

En este paso, estás construyendo una aplicación de consola simple usando servidores MCP.

## Requisitos Previos

Consulta el documento [README](../README.md#requisitos-previos) para la preparación.

## Comenzando

- [Verificar Modo Agente de GitHub Copilot](#verificar-modo-agente-de-github-copilot)
- [Preparar Instrucciones Personalizadas](#preparar-instrucciones-personalizadas)
- [Preparar Desarrollo del Servidor MCP](#preparar-desarrollo-del-servidor-mcp)
- [Desarrollar Lógica de Gestión de Lista de Tareas](#desarrollar-lógica-de-gestión-de-lista-de-tareas)
- [Eliminar Lógica de API](#eliminar-lógica-de-api)
- [Convertir a Servidor MCP](#convertir-a-servidor-mcp)
- [Ejecutar Servidor MCP](#ejecutar-servidor-mcp)
- [Probar Servidor MCP](#probar-servidor-mcp)

## Verificar Modo Agente de GitHub Copilot

1. Haz clic en el icono de GitHub Copilot en la parte superior de GitHub Codespace o VS Code y abre la ventana de GitHub Copilot.

   ![Abrir GitHub Copilot Chat](./images/setup-01.png)

1. Si se te pide iniciar sesión o registrarte, hazlo. Es gratuito.
1. Asegúrate de estar usando el Modo Agente de GitHub Copilot.

   ![Modo Agente de GitHub Copilot](./images/setup-02.png)

1. Selecciona el modelo para `GPT-4.1` o `Claude Sonnet 4`.
1. Asegúrate de haber configurado [Servidores MCP](./00-setup.md#configurar-servidores-mcp).

## Iniciar Servidor MCP &ndash; GitHub

1. Abre la Paleta de Comandos presionando `F1` o `Ctrl`+`Shift`+`P` en Windows o `Cmd`+`Shift`+`P` en Mac OS, y busca `MCP: List Servers`.
1. Elige `github` luego haz clic en `Start Server`. Es posible que se te pida iniciar sesión en GitHub para usar este servidor MCP.

## Preparar Instrucciones Personalizadas

1. Establece la variable de entorno de `$REPOSITORY_ROOT`.

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. Copia las instrucciones personalizadas.

    ```bash
    # bash/zsh
    cp $REPOSITORY_ROOT/docs/.github/monkeyapp-instructions.md \
       $REPOSITORY_ROOT/.github/copilot-instructions.md
    ```

    ```powershell
    # PowerShell
    Copy-Item -Path $REPOSITORY_ROOT/docs/.github/monkeyapp-instructions.md `
              -Destination $REPOSITORY_ROOT/.github/copilot-instructions.md -Force
    ```

1. Abre `.github/copilot-instructions.md` y reemplaza `https://github.com/YOUR_USERNAME/YOUR_REPO_NAME` con el tuyo. Por ejemplo, `https://github.com/octocat/monkey-app`.

## Crear Aplicación de Consola

1. Crea una aplicación de consola bajo el directorio `workshop`.

    ```bash
    # bash/zsh
    mkdir -p $REPOSITORY_ROOT/workshop
    cd $REPOSITORY_ROOT/workshop
    dotnet new console -n MyMonkeyApp
    ```

    ```powershell
    # PowerShell
    New-Item -Type Directory -Path $REPOSITORY_ROOT/workshop -Force
    cd $REPOSITORY_ROOT/workshop
    dotnet new console -n MyMonkeyApp
    ```

## Gestionar Repositorio de GitHub

1. Ingresa el siguiente prompt a GitHub Copilot para subir la aplicación de consola creada.

    ```text
    Push the current changes to the `main` branch of the repository.
    ```

1. Ingresa el siguiente prompt a GitHub Copilot para generar un issue en el repositorio.

    ```text
    Create a new GitHub issue in my repository titled 'Implement Monkey Console Application' with the following requirements:
    
    - Create a C# console app that can list all available monkeys, get details for a specific monkey by name, and pick a random monkey.
    - The app should use a Monkey model class and include ASCII art for visual appeal.
    - Add appropriate labels like 'enhancement' and 'good first issue'.
    - Add some details about how we may go about implementing this and a checklist for what we will need to do.
    ```

1. Asigna `@Copilot` al issue y observa lo que está sucediendo.

## Iniciar Servidor MCP &ndash; Monkey MCP

1. Abre la Paleta de Comandos presionando `F1` o `Ctrl`+`Shift`+`P` en Windows o `Cmd`+`Shift`+`P` en Mac OS, y busca `MCP: List Servers`.
1. Asegúrate de que el servidor MCP `github` esté funcionando.
1. Elige `monkeymcp` luego haz clic en `Start Server`.

## Desarrollar Aplicación Monkey con GitHub Copilot y Servidores MCP

1. Ingresa el siguiente prompt para obtener la lista de monos.

    ```text
    Get me a list of monkeys that are available and display them in a table with their details.
    ```

1. Ingresa el siguiente prompt para obtener una idea del modelo de datos para un mono.

    ```text
    What would a data model look like for this structure?
    ```

1. Ingresa el siguiente prompt para crear un archivo para la clase del modelo de datos.

    ```text
    Let's create a new file for this class.
    ```

1. Ingresa el siguiente prompt para crear una clase `MonkeyHelper`.

    ```text
    Let's create a new class called MonkeyHelper that is static. It should manage a collection of monkey data. Include methods to get all monkeys, get a random monkey, find a monkey by name, and track access count to when a random monkey is picked. The data for the monkeys should come from the Monkey MCP server that we just got.
    ```

1. Ingresa el siguiente prompt para actualizar la aplicación de consola.

    ```text
    Let's update the app now to have a nice menu with the following options that will call into that `MonkeyHelper`.
    
    1. List all monkeys
    2. Get details for a specific monkey by name
    3. Get a random monkey
    4. Exit app

    Also display some funny ASCII art randomly.
    ```

1. Ingresa el siguiente prompt a GitHub Copilot para subir la aplicación de consola actualizada.

    ```text
    Push the current changes to the `mymonkeyapp` branch of the repository.
    With this branch, create a PR against the `main` branch.
    Connect this PR to the issue created before.
    Then, merge this PR and close the issue.
    ```

---

OK. Has completado el paso "Desarrollo de Aplicación Monkey con MCP". Continuemos con [PASO 02: Servidor MCP](./02-mcp-server.md).