# 01: Desarrollo de Aplicación Monkey con MCP

En este paso, estás construyendo una aplicación de consola simple usando servidores MCP.

## Requisitos Previos

Consulta el documento [README](../README.md#requisitos-previos) para la preparación.

## Comenzando

- [Verificar Modo Agente de GitHub Copilot](#verificar-modo-agente-de-github-copilot)
- [Iniciar Servidor MCP – GitHub](#iniciar-servidor-mcp--github)
- [Preparar Instrucciones Personalizadas](#preparar-instrucciones-personalizadas)
- [Crear Aplicación de Consola](#crear-aplicación-de-consola)
- [Gestionar Repositorio de GitHub](#gestionar-repositorio-de-github)
- [Iniciar Servidor MCP – Monkey MCP](#iniciar-servidor-mcp--monkey-mcp)
- [Desarrollar Aplicación Monkey con GitHub Copilot y Servidores MCP](#desarrollar-aplicación-monkey-con-github-copilot-y-servidores-mcp)

## Verificar Modo Agente de GitHub Copilot

1. Haz clic en el icono de GitHub Copilot en la parte superior de GitHub Codespace o VS Code y abre la ventana de GitHub Copilot.

   ![Abrir GitHub Copilot Chat](../../../docs/images/setup-01.png)

1. Si se te pide iniciar sesión o registrarte, hazlo. Es gratuito.
1. Asegúrate de estar usando el Modo Agente de GitHub Copilot.

   ![Modo Agente de GitHub Copilot](../../../docs/images/setup-02.png)

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
    Empuja los cambios actuales a la rama `main` del repositorio.
    ```

1. Ingresa el siguiente prompt a GitHub Copilot para generar un issue en el repositorio.

    ```text
    Crea un nuevo issue de GitHub en mi repositorio titulado 'Implementar Aplicación de Consola Monkey' con los siguientes requisitos:
    
    - Crear una aplicación de consola C# que pueda listar todos los monos disponibles, obtener detalles de un mono específico por nombre, y elegir un mono aleatorio.
    - La aplicación debe usar una clase modelo Monkey e incluir arte ASCII para atractivo visual.
    - Agregar etiquetas apropiadas como 'enhancement' y 'good first issue'.
    - Agregar algunos detalles sobre cómo podríamos proceder a implementar esto y una lista de verificación de lo que necesitaremos hacer.
    ```

1. Asigna `@Copilot` al issue y observa lo que está sucediendo.

## Iniciar Servidor MCP &ndash; Monkey MCP

1. Abre la Paleta de Comandos presionando `F1` o `Ctrl`+`Shift`+`P` en Windows o `Cmd`+`Shift`+`P` en Mac OS, y busca `MCP: List Servers`.
1. Asegúrate de que el servidor MCP `github` esté funcionando.
1. Elige `monkeymcp` luego haz clic en `Start Server`.

## Desarrollar Aplicación Monkey con GitHub Copilot y Servidores MCP

1. Ingresa el siguiente prompt para obtener la lista de monos.

    ```text
    Obtén una lista de monos que estén disponibles y muéstralos en una tabla con sus detalles.
    ```

1. Ingresa el siguiente prompt para obtener una idea del modelo de datos para un mono.

    ```text
    ¿Cómo se vería un modelo de datos para esta estructura?
    ```

1. Ingresa el siguiente prompt para crear un archivo para la clase del modelo de datos.

    ```text
    Creemos un nuevo archivo para esta clase.
    ```

1. Ingresa el siguiente prompt para crear una clase `MonkeyHelper`.

    ```text
    Creemos una nueva clase llamada MonkeyHelper que sea estática. Debe gestionar una colección de datos de monos. Incluye métodos para obtener todos los monos, obtener un mono aleatorio, encontrar un mono por nombre, y rastrear el recuento de acceso cuando se elige un mono aleatorio. Los datos de los monos deben provenir del servidor Monkey MCP que acabamos de obtener.
    ```

1. Ingresa el siguiente prompt para actualizar la aplicación de consola.

    ```text
    Actualicemos la aplicación ahora para tener un menú bonito con las siguientes opciones que llamarán a ese `MonkeyHelper`.
    
    1. Listar todos los monos
    2. Obtener detalles de un mono específico por nombre
    3. Obtener un mono aleatorio
    4. Salir de la aplicación

    También muestra arte ASCII divertido de forma aleatoria.
    ```

1. Ingresa el siguiente prompt a GitHub Copilot para subir la aplicación de consola actualizada.

    ```text
    Empuja los cambios actuales a la rama `mymonkeyapp` del repositorio.
    Antes de enviar los cambios, asegúrate de que el directorio `workshop` esté incluido en el push.
    Con esta rama, crea una PR contra la rama `main` de tu repositorio, no del upstream.
    Conecta esta PR al issue creado anteriormente.
    Luego, fusiona esta PR y cierra el issue.
    ```

---

OK. Has completado el paso "Desarrollo de Aplicación Monkey con MCP". Continuemos con [PASO 02: Servidor MCP](./02-mcp-server.md).

---

Este documento ha sido localizado por [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot). Por lo tanto, puede contener errores. Si encuentras alguna traducción inapropiada o errónea, por favor crea un [issue](../../../../../issues).