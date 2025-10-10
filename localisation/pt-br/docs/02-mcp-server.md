# 02: Servidor MCP

Neste passo, você está construindo um servidor MCP para gerenciamento de lista de tarefas.

## Pré-requisitos

Consulte o documento [README](../README.md#pré-requisitos) para preparação.

## Começando

- [Verificar Modo Agente GitHub Copilot](#verificar-modo-agente-github-copilot)
- [Preparar Instruções Personalizadas](#preparar-instruções-personalizadas)
- [Preparar Desenvolvimento do Servidor MCP](#preparar-desenvolvimento-do-servidor-mcp)
- [Desenvolver Lógica de Gerenciamento de Lista de Tarefas](#desenvolver-lógica-de-gerenciamento-de-lista-de-tarefas)
- [Remover Lógica de API](#remover-lógica-de-api)
- [Converter para Servidor MCP](#converter-para-servidor-mcp)
- [Executar Servidor MCP](#executar-servidor-mcp)
- [Testar Servidor MCP](#testar-servidor-mcp)

## Verificar Modo Agente GitHub Copilot

1. Clique no ícone do GitHub Copilot no topo do GitHub Codespace ou VS Code e abra a janela do GitHub Copilot.

   ![Open GitHub Copilot Chat](../../../docs/images/setup-01.png)

1. Se for solicitado para fazer login ou se inscrever, faça-o. É gratuito.
1. Certifique-se de estar usando o Modo Agente do GitHub Copilot.

   ![GitHub Copilot Agent Mode](../../../docs/images/setup-02.png)

1. Selecione o modelo como `GPT-4.1` ou `Claude Sonnet 4`.
1. Certifique-se de ter configurado [Servidores MCP](./00-setup.md#configurar-servidores-mcp).

## Iniciar Servidores MCP &ndash; Awesome Copilot

1. Abra a Paleta de Comandos digitando `F1` ou `Ctrl`+`Shift`+`P` no Windows ou `Cmd`+`Shift`+`P` no Mac OS, e pesquise `MCP: List Servers`.
1. Pare os servidores MCP `github` e `monkeymcp` se ainda estiverem em execução.
1. Escolha `awesome-copilot` e clique em `Start Server`.

## Configurar Modo Beast

1. Digite o seguinte prompt para pesquisar o prompt do modo beast.

    ```text
    Show me the list of copilot instructions for beast chatmode. It should be general purpose.
    ```

   Deve retornar um resultado semelhante a `4.1 Beast Chat Mode`. Caso contrário, pesquise novamente.

1. Digite o seguinte prompt para salvar o modo de chat beast.

    ```text
    Save it under the `.github/chatmodes` directory.
    ```

1. Escolha o modo `4.1-Beast` em vez do modo `Agent`. Ele mudará automaticamente o LLM para `GPT 4.1`.

1. Defina a variável de ambiente `$REPOSITORY_ROOT`.

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. Copie as configurações do espaço de trabalho.

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

## Preparar Instruções Personalizadas

1. Defina a variável de ambiente `$REPOSITORY_ROOT`.

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. Copie as instruções personalizadas.

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

## Preparar Desenvolvimento do Servidor MCP

No diretório `start`, uma aplicação ASP.NET Core Minimal API já está estruturada. Você a usará como ponto de partida.

1. Certifique-se de ter a variável de ambiente `$REPOSITORY_ROOT`.

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. Copie a aplicação estruturada para `workshop` a partir de `start`.

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

## Desenvolver Lógica de Gerenciamento de Lista de Tarefas

1. Certifique-se de estar usando o Modo Agente do GitHub Copilot com o modelo `Claude Sonnet 4` ou `GPT-4.1`.
1. Certifique-se de que os servidores MCP `microsoft.docs.mcp` e `sequentialthinking` estejam em execução.
1. Use o prompt como abaixo para implementar a lógica de gerenciamento de lista de tarefas.

    ```text
    Gostaria de implementar uma lógica de gerenciamento de lista de tarefas na aplicação ASP.NET Core Minimal API. Siga as instruções abaixo para o desenvolvimento da aplicação.
    
    - Use context7.
    - Identifique primeiro todos os passos que você vai fazer.
    - Seu diretório de trabalho é `workshop/src/McpTodoServer.ContainerApp`.
    - Use SQLite como banco de dados e deve usar o recurso em memória.
    - Use EntityFramework Core para transações de banco de dados.
    - Inicialize o banco de dados no início da aplicação.
    - O item de tarefa contém apenas as colunas `ID`, `Text` e `IsCompleted`.
    - O gerenciamento de lista de tarefas tem 5 recursos - criar, listar, atualizar, completar e excluir.
    - Se necessário, adicione pacotes NuGet compatíveis com .NET 9.
    - NÃO implemente endpoints de API para gerenciamento de lista de tarefas.
    - NÃO adicione dados iniciais.
    - NÃO referencie o diretório `complete`.
    - NÃO referencie o diretório `start`.
    ```

1. Clique no botão ![the keep button image](https://img.shields.io/badge/keep-blue) do GitHub Copilot para aceitar as mudanças.
1. Use o prompt como abaixo para verificar o resultado do desenvolvimento.

    ```text
    Gostaria de construir a aplicação. Siga as instruções.

    - Use context7.
    - Construa a aplicação e verifique se ela constrói corretamente.
    - Se a construção falhar, analise os problemas e corrija-os.
    ```

   > **NOTA**:
   >
   > - Até que a construção seja bem-sucedida, itere este passo.
   > - Se a construção continuar falhando, verifique as mensagens de erro e peça ao GitHub Copilot Agent para resolvê-los.

1. Clique no botão ![the keep button image](https://img.shields.io/badge/keep-blue) do GitHub Copilot para aceitar as mudanças.
1. Use o prompt como abaixo para verificar o resultado do desenvolvimento.

    ```text
    Gostaria de adicionar a classe `TodoTool` à aplicação. Siga as instruções.

    - Use context7.
    - Identifique primeiro todos os passos que você vai fazer.
    - Seu diretório de trabalho é `workshop/src/McpTodoServer.ContainerApp`.
    - A classe `TodoTool` deve conter 5 métodos - criar, listar, atualizar, completar e excluir.
    - NÃO registre dependência.
    ```

## Remover Lógica de API

1. Certifique-se de ter a variável de ambiente `$REPOSITORY_ROOT`.

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. Navegue para o projeto da aplicação.

    ```bash
    cd $REPOSITORY_ROOT/workshop/src/McpTodoServer.ContainerApp
    ```

1. Abra `Program.cs` e remova tudo o seguinte:

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

1. Remover o pacote NuGet.

    ```bash
    dotnet remove package Microsoft.AspNetCore.OpenApi
    ```

## Converter para Servidor MCP

1. Adicionar pacote NuGet para o servidor MCP.

    ```bash
    dotnet add package ModelContextProtocol.AspNetCore --prerelease
    ```

1. Abra `Program.cs`, encontre `var app = builder.Build();` e adicione o seguinte trecho de código logo acima da linha:

    ```csharp
    // 👇👇👇 Adicionar 👇👇👇
    builder.Services.AddMcpServer()
                    .WithHttpTransport(o => o.Stateless = true)
                    .WithToolsFromAssembly();
    // 👆👆👆 Adicionar 👆👆👆
    
    var app = builder.Build();
    ```

1. No mesmo `Program.cs`, encontre `app.Run();` e adicione o seguinte trecho de código logo acima da linha:

    ```csharp
    // 👇👇👇 Adicionar 👇👇👇
    app.MapMcp("/mcp");
    // 👆👆👆 Adicionar 👆👆👆
    
    app.Run();
    ```

1. Abra `TodoTool.cs` e adicione decoradores como mostrado abaixo.

   > **NOTA**: Os nomes dos métodos podem ser diferentes dependendo de como o GitHub Copilot os gera.

    ```csharp
    // 👇👇👇 Adicionar 👇👇👇
    [McpServerToolType]
    // 👆👆👆 Adicionar 👆👆👆
    public class TodoTool
    
    ...
    
        // 👇👇👇 Adicionar 👇👇👇
        [McpServerTool(Name = "add_todo_item", Title = "Add a to-do item")]
        [Description("Adds a to-do item to database.")]
        // 👆👆👆 Adicionar 👆👆👆
        public async Task<TodoItem> CreateAsync(string text)
    
    ...
    
        // 👇👇👇 Adicionar 👇👇👇
        [McpServerTool(Name = "get_todo_items", Title = "Get a list of to-do items")]
        [Description("Gets a list of to-do items from database.")]
        // 👆👆👆 Adicionar 👆👆👆
        public async Task<List<TodoItem>> ListAsync()
    
    ...
    
        // 👇👇👇 Adicionar 👇👇👇
        [McpServerTool(Name = "update_todo_item", Title = "Update a to-do item")]
        [Description("Updates a to-do item in the database.")]
        // 👆👆👆 Adicionar 👆👆👆
        public async Task<TodoItem?> UpdateAsync(int id, string text)
    
    ...
    
        // 👇👇👇 Adicionar 👇👇👇
        [McpServerTool(Name = "complete_todo_item", Title = "Complete a to-do item")]
        [Description("Completes a to-do item in the database.")]
        // 👆👆👆 Adicionar 👆👆👆
        public async Task<TodoItem?> CompleteAsync(int id)
    
    ...
    
        // 👇👇👇 Adicionar 👇👇👇
        [McpServerTool(Name = "delete_todo_item", Title = "Delete a to-do item")]
        [Description("Deletes a to-do item from the database.")]
        // 👆👆👆 Adicionar 👆👆👆
        public async Task<bool> DeleteAsync(int id)
    
    ...
    ```

1. No mesmo `TodoTool.cs`, adicione diretivas `using` extras:

   > **NOTA**: O namespace pode ser diferente dependendo de como o GitHub Copilot os gera.

    ```csharp
    // 👇👇👇 Adicionar 👇👇👇
    using ModelContextProtocol.Server;
    using System.ComponentModel;
    // 👆👆👆 Adicionar 👆👆👆
    
    namespace McpTodoServer.ContainerApp.Tools;
    ```

1. Construir a aplicação.

    ```bash
    dotnet build
    ```

## Executar Servidor MCP

1. Certifique-se de ter a variável de ambiente `$REPOSITORY_ROOT`.

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. Navegue para o projeto da aplicação.

    ```bash
    cd $REPOSITORY_ROOT/workshop/src/McpTodoServer.ContainerApp
    ```

1. Execute a aplicação do servidor MCP.

    ```bash
    dotnet run
    ```

1. Abra a Paleta de Comandos pressionando `F1` ou `Ctrl`+`Shift`+`P` no Windows ou `Cmd`+`Shift`+`P` no Mac OS, e procure por `MCP: Add Server...`.
1. Escolha `HTTP (HTTP or Server-Sent Events)`.
1. Digite `http://localhost:5242/mcp` como URL do servidor.
1. Digite `mcp-todo` como ID do servidor.
1. Escolha `Workspace settings` como local para salvar as configurações MCP.
1. Abra `.vscode/mcp.json` e veja o servidor MCP adicionado.

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
        // 👇👇👇 Adicionado 👇👇👇
        "mcp-todo": {
            "url": "http://localhost:5242/mcp"
        }
        // 👆👆👆 Adicionado 👆👆👆
      }
    }
    ```

## Testar Servidor MCP

1. Abra o GitHub Copilot Chat como Modo Agente.
1. Digite um dos prompts abaixo:

    ```text
    Mostre-me a lista de tarefas.
    Adicionar "almoço às 12h".
    Marcar almoço como completado.
    Adicionar "reunião às 15h".
    Alterar a reunião para 15h30.
    Cancelar a reunião.
    ```

1. Se ocorrer um erro, peça ao GitHub Copilot para corrigi-lo:

    ```text
    Recebi um erro "xxx". Por favor, encontre o problema e corrija-o.
    ```

---

Ótimo. Você completou a etapa "Desenvolvimento do Servidor MCP". Agora vamos para o [PASSO 02: Servidor MCP Remoto](./02-mcp-remote-server.md).

---

Este documento foi localizado pelo [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot). Portanto, pode conter erros. Se você encontrar alguma tradução inadequada ou erro, por favor, crie um [issue](../../../../../issues).