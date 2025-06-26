# 01: Servidor MCP

En este paso, estás construyendo un servidor MCP para la gestión de lista de tareas.

## Requisitos Previos

Consulta el documento [README](../README.md#prerequisites) para la preparación.

## Comenzando

- [Verificar Modo Agente de GitHub Copilot](#verificar-modo-agente-de-github-copilot)
- [Preparar Instrucciones Personalizadas](#preparar-instrucciones-personalizadas)
- [Preparar Desarrollo del Servidor MCP](#preparar-desarrollo-del-servidor-mcp)
- [Desarrollar Lógica de Gestión de Lista de Tareas](#desarrollar-lógica-de-gestión-de-lista-de-tareas)
- [Remover Lógica de API](#remover-lógica-de-api)
- [Convertir a Servidor MCP](#convertir-a-servidor-mcp)
- [Ejecutar Servidor MCP](#ejecutar-servidor-mcp)
- [Probar Servidor MCP](#probar-servidor-mcp)

## Verificar Modo Agente de GitHub Copilot

1. Haz clic en el icono de GitHub Copilot en la parte superior de GitHub Codespace o VS Code y abre la ventana de GitHub Copilot.

   ![Open GitHub Copilot Chat](../../../docs/images/setup-01.png)

1. Si se te pide iniciar sesión o registrarte, hazlo. Es gratuito.
1. Asegúrate de estar usando el Modo Agente de GitHub Copilot.

   ![GitHub Copilot Agent Mode](../../../docs/images/setup-01.png)

1. Selecciona el modelo como `GPT-4.1` o `Claude Sonnet 4`.
1. Asegúrate de haber configurado [Servidores MCP](./00-setup.md#set-up-mcp-servers).

## Preparar Instrucciones Personalizadas

1. Establece la variable de entorno `$REPOSITORY_ROOT`.

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
    cp -r $REPOSITORY_ROOT/docs/.github/. \
          $REPOSITORY_ROOT/.github/
    ```

    ```powershell
    # PowerShell
    Copy-Item -Path $REPOSITORY_ROOT/docs/.github/* `
              -Destination $REPOSITORY_ROOT/.github/ -Recurse -Force
    ```

## Preparar Desarrollo del Servidor MCP

En el directorio `start`, ya hay una aplicación ASP.NET Core Minimal API estructurada. La usarás como punto de partida.

1. Asegúrate de tener la variable de entorno `$REPOSITORY_ROOT`.

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. Copia la aplicación estructurada a `workshop` desde `start`.

    ```bash
    # bash/zsh
    mkdir -p $REPOSITORY_ROOT/workshop
    cp -r $REPOSITORY_ROOT/start/. \
          $REPOSITORY_ROOT/workshop/
    ```

    ```powershell
    # PowerShell
    New-Item -Type Directory -Path $REPOSITORY_ROOT/workshop -Force
    Copy-Item -Path $REPOSITORY_ROOT/start/* `
              -Destination $REPOSITORY_ROOT/workshop/ -Recurse -Force
    ```

## Desarrollar Lógica de Gestión de Lista de Tareas

1. Asegúrate de estar usando el Modo Agente de GitHub Copilot con el modelo `Claude Sonnet 4` o `GPT-4.1`.
1. Asegúrate de que el servidor MCP `context7` esté funcionando.
1. Usa el prompt como el siguiente para implementar la lógica de gestión de lista de tareas.

    ```text
    Me gustaría desarrollar una aplicación de lista de tareas usando ASP.NET Core. Sigue las instrucciones.

    - Usa context7.
    - Identifica todos los pasos primero, que vas a hacer.
    - Tu directorio de trabajo es `workshop/src/McpTodoServer.ContainerApp`.
    - La aplicación debe incluir modelos para gestión de tareas con las propiedades: ID, título, descripción, estado completado, fecha de creación y fecha de actualización.
    - Si es necesario, agrega paquetes NuGet que sean compatibles con .NET 9.
    - NO implementes endpoints de API para la gestión de lista de tareas.
    - NO agregues datos iniciales.
    - NO hagas referencia al directorio `complete`.
    - NO hagas referencia al directorio `start`.
    ```

1. Haz clic en el botón ![the keep button image](https://img.shields.io/badge/keep-blue) de GitHub Copilot para tomar los cambios.
1. Usa el prompt como el siguiente para verificar el resultado del desarrollo.

    ```text
    Me gustaría agregar la clase `TodoTool` a la aplicación. Sigue las instrucciones.

    - Usa context7.
    - Identifica todos los pasos primero, que vas a hacer.
    - Tu directorio de trabajo es `workshop/src/McpTodoServer.ContainerApp`.
    - La clase `TodoTool` debe contener 5 métodos - crear, listar, actualizar, completar y eliminar.
    - NO registres dependencia.
    ```

1. Haz clic en el botón ![the keep button image](https://img.shields.io/badge/keep-blue) de GitHub Copilot para tomar los cambios.
1. Usa el prompt como el siguiente para verificar el resultado del desarrollo.

    ```text
    Me gustaría construir la aplicación. Sigue las instrucciones.

    - Usa context7.
    - Construye la aplicación y verifica si se construye correctamente.
    - Si la construcción falla, analiza los problemas y corrígelos.
    ```

   > **NOTA**:
   >
   > - Hasta que la construcción tenga éxito, itera este paso.
   > - Si la construcción sigue fallando, revisa los mensajes de error y pregúntales a GitHub Copilot Agent para resolverlos.

## Remover Lógica de API

1. Abre GitHub Copilot Chat como Modo Agente.
1. Usa el prompt como el siguiente para remover la lógica de API.

    ```text
    Me gustaría remover toda la lógica de API de la aplicación. Sigue las instrucciones.

    - Usa context7.
    - Identifica todos los pasos primero, que vas a hacer.
    - Tu directorio de trabajo es `workshop/src/McpTodoServer.ContainerApp`.
    - Remueve todos los endpoints de API pero mantén los modelos y clases de herramientas.
    - Asegúrate de que la aplicación aún se construya después de remover la lógica de API.
    ```

1. Haz clic en el botón ![the keep button image](https://img.shields.io/badge/keep-blue) de GitHub Copilot para tomar los cambios.

## Convertir a Servidor MCP

1. Abre GitHub Copilot Chat como Modo Agente.
1. Usa el prompt como el siguiente para convertir la aplicación a un servidor MCP.

    ```text
    Me gustaría convertir esta aplicación a un servidor MCP. Sigue las instrucciones.

    - Usa context7.
    - Identifica todos los pasos primero, que vas a hacer.
    - Tu directorio de trabajo es `workshop/src/McpTodoServer.ContainerApp`.
    - Agrega los paquetes NuGet necesarios para MCP.
    - Implementa el servidor MCP que puede manejar solicitudes de gestión de lista de tareas.
    - Los métodos deben incluir: listar tareas, crear tarea, actualizar tarea, completar tarea y eliminar tarea.
    - Asegúrate de que la aplicación se construya después de la conversión.
    ```

1. Haz clic en el botón ![the keep button image](https://img.shields.io/badge/keep-blue) de GitHub Copilot para tomar los cambios.

## Ejecutar Servidor MCP

1. Abre un terminal y navega al directorio de la aplicación.

    ```bash
    cd workshop/src/McpTodoServer.ContainerApp
    ```

1. Ejecuta la aplicación.

    ```bash
    dotnet run
    ```

   Deberías ver una salida similar a la siguiente:

    ```bash
    info: Microsoft.Hosting.Lifetime[14]
          Now listening on: http://localhost:5242
    info: Microsoft.Hosting.Lifetime[0]
          Application started. Press Ctrl+C to shut down.
    ```

## Probar Servidor MCP

1. Abre GitHub Copilot Chat como Modo Agente.
1. Introduce uno de los prompts a continuación:

    ```text
    Muéstrame la lista de tareas.
    Agregar "almuerzo a las 12pm".
    Marcar almuerzo como completado.
    Agregar "reunión a las 3pm".
    Cambiar la reunión a las 3:30pm.
    Cancelar la reunión.
    ```

1. Si ocurre un error, pide a GitHub Copilot que lo corrija:

    ```text
    Obtuve un error "xxx". Por favor encuentra el problema y corrígelo.
    ```

---

Perfecto. Has completado el paso "Desarrollo del Servidor MCP". Ahora vamos al [PASO 02: Servidor MCP Remoto](./02-mcp-remote-server.md).

---

Este documento ha sido localizado por [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot). Por lo tanto, puede contener errores. Si encuentras alguna traducción inapropiada o errónea, por favor crea un [issue](../../../../../issues).