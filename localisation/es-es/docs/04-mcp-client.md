# 04: Cliente MCP

En este paso, estás construyendo un cliente MCP para la gestión de lista de tareas.

## Requisitos Previos

Consulta el documento [README](../README.md#requisitos-previos) para la preparación.

## Comenzando

- [Preparar Token de Acceso Personal (PAT) de GitHub](#preparar-token-de-acceso-personal-pat-de-github)
- [Preparar Desarrollo del Cliente MCP](#preparar-desarrollo-del-cliente-mcp)
- [Implementar Cliente MCP](#implementar-cliente-mcp)
- [Ejecutar Aplicación del Servidor MCP](#ejecutar-aplicación-del-servidor-mcp)
- [Ejecutar Aplicación del Cliente MCP](#ejecutar-aplicación-del-cliente-mcp)
- [Limpiar Recursos](#limpiar-recursos)

## Preparar Token de Acceso Personal (PAT) de GitHub

Para el desarrollo de la aplicación cliente MCP, necesitas acceso a un modelo de IA. En este taller, se utiliza [OpenAI GPT-4.1-mini](https://github.com/marketplace/models/azure-openai/gpt-4-1-mini) de [GitHub Models](https://github.com/marketplace?type=models).

Para acceder a GitHub Models, debes tener el [Token de Acceso Personal (PAT) de GitHub](https://docs.github.com/authentication/keeping-your-account-and-data-secure/managing-your-personal-access-tokens).

Para obtener el PAT, ve a [Configuración de GitHub](https://github.com/settings/personal-access-tokens/new) y crea un nuevo PAT. Asegúrate de establecer los permisos como "solo lectura" en "Models".

## Preparar Desarrollo del Cliente MCP

En la [sesión anterior](./01-mcp-server.md), ya has copiado tanto la aplicación del servidor MCP como la del cliente. Sigamos usándola.

1. Asegúrate de que tienes la variable de entorno `$REPOSITORY_ROOT`.

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. Navega al directorio `workshop`.

    ```bash
    cd $REPOSITORY_ROOT/workshop
    ```

1. Agrega el PAT de GitHub a la aplicación cliente. Asegúrate de reemplazar `{{ GITHUB_PAT }}` con tu PAT de GitHub emitido desde la sección anterior.

    ```bash
    dotnet user-secrets --project ./src/McpTodoClient.BlazorApp set GitHubModels:Token "{{ GITHUB_PAT }}"
    ```

1. Ejecuta la aplicación.

    ```bash
    dotnet watch run --project ./src/McpTodoClient.BlazorApp
    ```

1. Verifica si la aplicación está funcionando ingresando prompts. Aquí hay un ejemplo:

    ```text
    ¿Por qué el cielo es tan azul?
    ```

1. Detén la aplicación escribiendo `CTRL`+`C`.

## Implementar Cliente MCP

1. Asegúrate de que estás en el directorio de la aplicación cliente MCP.

    ```bash
    cd $REPOSITORY_ROOT/workshop/src/McpTodoClient.BlazorApp
    ```

1. Agrega el paquete NuGet para el cliente MCP.

    ```bash
    dotnet add package ModelContextProtocol.AspNetCore --prerelease
    ```

1. Abre `Program.cs` y agrega directivas `using` adicionales con lo siguiente:

    ```csharp
    using System.ClientModel;
    using McpTodoClient.BlazorApp.Components;
    using Microsoft.Extensions.AI;
    
    // 👇👇👇 Agregar 👇👇👇
    using ModelContextProtocol.Client;
    using ModelContextProtocol.Protocol;
    // 👆👆👆 Agregar 👆👆👆
    
    using OpenAI;
    ```

1. En el mismo `Program.cs`, encuentra la línea `var app = builder.Build();` y agrega las siguientes líneas de código justo arriba de ella.

    ```csharp
    builder.Services.AddChatClient(chatClient)
                    .UseFunctionInvocation()
                    .UseLogging();
    
    // 👇👇👇 Agregar 👇👇👇
    builder.Services.AddSingleton<IMcpClient>(sp =>
    {
        var loggerFactory = sp.GetRequiredService<ILoggerFactory>();
    
        var uri = new Uri("http://localhost:5242");
    
        var clientTransportOptions = new SseClientTransportOptions()
        {
            Endpoint = new Uri($"{uri.AbsoluteUri.TrimEnd('/')}/mcp")
        };
        var clientTransport = new SseClientTransport(clientTransportOptions, loggerFactory);
    
        var clientOptions = new McpClientOptions()
        {
            ClientInfo = new Implementation()
            {
                Name = "MCP Todo Client",
                Version = "1.0.0",
            }
        };
    
        return McpClientFactory.CreateAsync(clientTransport, clientOptions, loggerFactory).GetAwaiter().GetResult();
    });
    // 👆👆👆 Agregar 👆👆👆
    
    var app = builder.Build();
    ```

1. Abre `Components/Pages/Chat/Chat.razor` y agrega directivas `@using` adicionales.

    ```razor
    @page "/"
    
    @using System.ComponentModel
    
    @* 👇👇👇 Agregar 👇👇👇 *@
    @using ModelContextProtocol.Client
    @* 👆👆👆 Agregar 👆👆👆 *@
    
    @inject IChatClient ChatClient
    ```

1. En el mismo `Components/Pages/Chat/Chat.razor`, agrega `IMcpClient` como otra dependencia.

    ```razor
    @inject IChatClient ChatClient
    
    @* 👇👇👇 Agregar 👇👇👇 *@
    @inject IMcpClient McpClient
    @* 👆👆👆 Agregar 👆👆👆 *@
    
    @implements IDisposable
    ```

1. En el mismo `Components/Pages/Chat/Chat.razor`, agrega un campo privado en el bloque de código `@code { ... }`.

    ```csharp
    private readonly ChatOptions chatOptions = new();
    
    // 👇👇👇 Agregar 👇👇👇
    private IEnumerable<McpClientTool> tools = null!;
    // 👆👆👆 Agregar 👆👆👆
    
    private readonly List<ChatMessage> messages = new();
    ```

1. En el mismo `Components/Pages/Chat/Chat.razor`, reemplaza `OnInitialized()` con `OnInitializedAsync()`.

    ```csharp
    // Antes
    protected override void OnInitialized()
    {
        messages.Add(new(ChatRole.System, SystemPrompt));
    }
    
    // Después
    protected override async Task OnInitializedAsync()
    {
        messages.Add(new(ChatRole.System, SystemPrompt));
        tools = await McpClient.ListToolsAsync();
        chatOptions.Tools = [.. tools];
    }
    ```

## Ejecutar Aplicación del Servidor MCP

1. Asegúrate de que estás en el directorio `workshop`.

    ```bash
    cd $REPOSITORY_ROOT/workshop
    ```

1. Ejecuta la aplicación del servidor MCP.

    ```bash
    dotnet run --project ./src/McpTodoServer.ContainerApp
    ```

## Ejecutar Aplicación del Cliente MCP

1. Asegúrate de que estás en el directorio `workshop`.

    ```bash
    cd $REPOSITORY_ROOT/workshop
    ```

1. Ejecuta la aplicación del cliente MCP.

    ```bash
    dotnet watch run --project ./src/McpTodoClient.BlazorApp
    ```

1. Cuando se abra un navegador web, ingresa prompts sobre elementos de la lista de tareas. Aquí hay algunos ejemplos:

    ```text
    Dime la lista de tareas pendientes.
    Reserva las 9am para una reunión.
    Reserva las 12pm para almorzar.
    La reunión de las 9am terminó.
    Cambia la hora del almuerzo a la 1pm.
    Reserva otra reunión a la 1pm.
    Cancela la reunión de la 1pm.
    ```

👉 **DESAFÍO**: Reemplaza el Servidor MCP con un contenedor o servidor remoto creado en la [sesión anterior](./02-mcp-remote-server.md).

## Limpiar Recursos

1. Elimina todas las imágenes de contenedor utilizadas.

    ```bash
    docker rmi mcp-todo-http:latest --force
    ```

1. Elimina todos los recursos desplegados en Azure.

    ```bash
    azd down --force --purge
    ```

---

¡Felicitaciones! 🎉 ¡Has completado todas las sesiones del taller exitosamente!

---

Este documento ha sido localizado por [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot). Por lo tanto, puede contener errores. Si encuentras alguna traducción inapropiada o errónea, por favor crea un [issue](../../../../../issues).
