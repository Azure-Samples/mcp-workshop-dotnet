# 02: Servidor MCP

En este paso, estás construyendo un servidor MCP para la gestión de lista de tareas.

## Requisitos Previos

Consulta el documento [README](../README.md#requisitos-previos) para la preparación.

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

   ![GitHub Copilot Agent Mode](../../../docs/images/setup-02.png)

1. Selecciona el modelo como `GPT-4.1` o `Claude Sonnet 4`.
1. Asegúrate de haber configurado [Servidores MCP](./00-setup.md#configurar-servidores-mcp).

## Iniciar Servidores MCP &ndash; Awesome Copilot

1. Abre la Paleta de Comandos escribiendo `F1` o `Ctrl`+`Shift`+`P` en Windows o `Cmd`+`Shift`+`P` en Mac OS, y busca `MCP: List Servers`.
1. Detén los servidores MCP `github` y `monkeymcp` si aún están en ejecución.
1. Elige `awesome-copilot` y luego haz clic en `Start Server`.

## Configurar Modo Beast

1. Ingresa el siguiente prompt para buscar el prompt del modo beast.

    ```text
    Show me the list of copilot instructions for beast chatmode. It should be general purpose.
    ```

   Debería devolver un resultado similar a `4.1 Beast Chat Mode`. Si no es así, búscalo de nuevo.

1. Ingresa el siguiente prompt para guardar el modo de chat beast.

    ```text
    Save it under the `.github/chatmodes` directory.
    ```

1. Elige el modo `4.1-Beast` en lugar del modo `Agent`. Cambiará automáticamente el LLM a `GPT 4.1`.

1. Establece la variable de entorno `$REPOSITORY_ROOT`.

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. Copia la configuración del espacio de trabajo.

    ```bash
    # bash/zsh
    cp $REPOSITORY_ROOT/docs/.vscode/settings.json \
       $REPOSITORY_ROOT/.vscode/settings.json
    ```

    ```powershell
    # PowerShell
    Copy-Item -Path $REPOSITORY_ROOT/docs/.vscode/settings.json `
              -Destination $REPOSITORY_ROOT/.vscode/settings.json -Force
    ```

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
    cp $REPOSITORY_ROOT/docs/.github/todoapp-instructions.md \
       $REPOSITORY_ROOT/.github/copilot-instructions.md
    ```

    ```powershell
    # PowerShell
    Copy-Item -Path $REPOSITORY_ROOT/docs/.github/todoapp-instructions.md `
              -Destination $REPOSITORY_ROOT/.github/copilot-instructions.md -Force
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
1. Asegúrate de que los servidores MCP `microsoft.docs.mcp` y `sequentialthinking` estén en funcionamiento.
1. Usa el prompt como el siguiente para implementar la lógica de gestión de lista de tareas.

    ```text
    Me gustaría implementar una lógica de gestión de lista de tareas en la aplicación ASP.NET Core Minimal API. Sigue las instrucciones a continuación para el desarrollo de la aplicación.
    
    - Usa context7.
    - Identifica todos los pasos primero, que vas a hacer.
    - Tu directorio de trabajo es `workshop/src/McpTodoServer.ContainerApp`.
    - Usa SQLite como base de datos y debe usar la función en memoria.
    - Usa EntityFramework Core para transacciones de base de datos.
    - Inicializa la base de datos al inicio de la aplicación.
    - El elemento de tarea solo contiene columnas `ID`, `Text` e `IsCompleted`.
    - La gestión de lista de tareas tiene 5 características - crear, listar, actualizar, completar y eliminar.
    - Si es necesario, agrega paquetes NuGet que sean compatibles con .NET 9.
    - NO implementes endpoints de API para la gestión de lista de tareas.
    - NO agregues datos iniciales.
    - NO hagas referencia al directorio `complete`.
    - NO hagas referencia al directorio `start`.
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

## Remover Lógica de API

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
    cd $REPOSITORY_ROOT/workshop/src/McpTodoServer.ContainerApp
    ```

1. Abre `Program.cs` y remueve todo lo siguiente:

   ```csharp
   // 👇👇👇 Remover 👇👇👇
   // Add services to the container.
   // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
   builder.Services.AddOpenApi();
   // 👆👆👆 Remover 👆👆👆
   ```

   ```csharp
   // 👇👇👇 Remover 👇👇👇
   // Configure the HTTP request pipeline.
   if (app.Environment.IsDevelopment())
   {
       app.MapOpenApi();
   }
   // 👆👆👆 Remover 👆👆👆
   ```

   ```csharp
   // 👇👇👇 Remover 👇👇👇
   var summaries = new[]
   {
       "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
   };
   // 👆👆👆 Remover 👆👆👆
   ```

   ```csharp
   // 👇👇👇 Remover 👇👇👇
   app.MapGet("/weatherforecast", () =>
   {
       var forecast =  Enumerable.Range(1, 5).Select(index =>
           new WeatherForecast
           (
               DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
               Random.Shared.Next(-20, 55),
               summaries[Random.Shared.Next(summaries.Length)]
           ))
           .ToArray();
       return forecast;
   })
   .WithName("GetWeatherForecast");
   // 👆👆👆 Remover 👆👆👆
   ```

   ```csharp
   // 👇👇👇 Remover 👇👇👇
   record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
   {
       public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
   }
   // 👆👆👆 Remover 👆👆👆
   ```

1. Remover el paquete NuGet.

    ```bash
    dotnet remove package Microsoft.AspNetCore.OpenApi
    ```

## Convertir a Servidor MCP

1. Agregar paquete NuGet para el servidor MCP.

    ```bash
    dotnet add package ModelContextProtocol.AspNetCore --prerelease
    ```

1. Abre `Program.cs`, busca `var app = builder.Build();` y agrega el siguiente fragmento de código justo encima de la línea:

    ```csharp
    // 👇👇👇 Agregar 👇👇👇
    builder.Services.AddMcpServer()
                    .WithHttpTransport(o => o.Stateless = true)
                    .WithToolsFromAssembly();
    // 👆👆👆 Agregar 👆👆👆
    
    var app = builder.Build();
    ```

1. En el mismo `Program.cs`, busca `app.Run();` y agrega el siguiente fragmento de código justo encima de la línea:

    ```csharp
    // 👇👇👇 Agregar 👇👇👇
    app.MapMcp("/mcp");
    // 👆👆👆 Agregar 👆👆👆
    
    app.Run();
    ```

1. Abre `TodoTool.cs` y agrega decoradores como se muestra a continuación.

   > **NOTA**: Los nombres de los métodos pueden ser diferentes dependiendo de cómo los genere GitHub Copilot.

    ```csharp
    // 👇👇👇 Agregar 👇👇👇
    [McpServerToolType]
    // 👆👆👆 Agregar 👆👆👆
    public class TodoTool
    
    ...
    
        // 👇👇👇 Agregar 👇👇👇
        [McpServerTool(Name = "add_todo_item", Title = "Add a to-do item")]
        [Description("Adds a to-do item to database.")]
        // 👆👆👆 Agregar 👆👆👆
        public async Task<TodoItem> CreateAsync(string text)
    
    ...
    
        // 👇👇👇 Agregar 👇👇👇
        [McpServerTool(Name = "get_todo_items", Title = "Get a list of to-do items")]
        [Description("Gets a list of to-do items from database.")]
        // 👆👆👆 Agregar 👆👆👆
        public async Task<List<TodoItem>> ListAsync()
    
    ...
    
        // 👇👇👇 Agregar 👇👇👇
        [McpServerTool(Name = "update_todo_item", Title = "Update a to-do item")]
        [Description("Updates a to-do item in the database.")]
        // 👆👆👆 Agregar 👆👆👆
        public async Task<TodoItem?> UpdateAsync(int id, string text)
    
    ...
    
        // 👇👇👇 Agregar 👇👇👇
        [McpServerTool(Name = "complete_todo_item", Title = "Complete a to-do item")]
        [Description("Completes a to-do item in the database.")]
        // 👆👆👆 Agregar 👆👆👆
        public async Task<TodoItem?> CompleteAsync(int id)
    
    ...
    
        // 👇👇👇 Agregar 👇👇👇
        [McpServerTool(Name = "delete_todo_item", Title = "Delete a to-do item")]
        [Description("Deletes a to-do item from the database.")]
        // 👆👆👆 Agregar 👆👆👆
        public async Task<bool> DeleteAsync(int id)
    
    ...
    ```

1. En el mismo `TodoTool.cs`, agrega directivas `using` adicionales:

   > **NOTA**: El espacio de nombres puede ser diferente dependiendo de cómo los genere GitHub Copilot.

    ```csharp
    // 👇👇👇 Agregar 👇👇👇
    using ModelContextProtocol.Server;
    using System.ComponentModel;
    // 👆👆👆 Agregar 👆👆👆
    
    namespace McpTodoServer.ContainerApp.Tools;
    ```

1. Construir la aplicación.

    ```bash
    dotnet build
    ```

## Ejecutar Servidor MCP

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
    cd $REPOSITORY_ROOT/workshop/src/McpTodoServer.ContainerApp
    ```

1. Ejecuta la aplicación del servidor MCP.

    ```bash
    dotnet run
    ```

1. Abre la Paleta de Comandos presionando `F1` o `Ctrl`+`Shift`+`P` en Windows o `Cmd`+`Shift`+`P` en Mac OS, y busca `MCP: Add Server...`.
1. Elige `HTTP (HTTP or Server-Sent Events)`.
1. Ingresa `http://localhost:5242/mcp` como la URL del servidor.
1. Ingresa `mcp-todo` como ID del servidor.
1. Elige `Workspace settings` como la ubicación para guardar la configuración de MCP.
1. Abre `.vscode/mcp.json` y verifica que el servidor MCP fue agregado.

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
        // 👇👇👇 Agregado 👇👇👇
        "mcp-todo": {
            "url": "http://localhost:5242/mcp"
        }
        // 👆👆👆 Agregado 👆👆👆
      }
    }
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