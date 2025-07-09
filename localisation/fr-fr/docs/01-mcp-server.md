# 01 : Serveur MCP

Dans cette étape, vous construisez un serveur MCP pour la gestion de liste de tâches.

## Prérequis

Référez-vous au document [README](../README.md#prérequis) pour la préparation.

## Commencer

- [Vérifier le Mode Agent GitHub Copilot](#vérifier-le-mode-agent-github-copilot)
- [Préparer les Instructions Personnalisées](#préparer-les-instructions-personnalisées)
- [Préparer le Développement du Serveur MCP](#préparer-le-développement-du-serveur-mcp)
- [Développer la Logique de Gestion de Liste de Tâches](#développer-la-logique-de-gestion-de-liste-de-tâches)
- [Supprimer la Logique API](#supprimer-la-logique-api)
- [Convertir en Serveur MCP](#convertir-en-serveur-mcp)
- [Exécuter le Serveur MCP](#exécuter-le-serveur-mcp)
- [Tester le Serveur MCP](#tester-le-serveur-mcp)

## Vérifier le Mode Agent GitHub Copilot

1. Cliquez sur l'icône GitHub Copilot en haut de GitHub Codespace ou VS Code et ouvrez la fenêtre GitHub Copilot.

   ![Open GitHub Copilot Chat](../../../docs/images/setup-01.png)

1. Si on vous demande de vous connecter ou de vous inscrire, faites-le. C'est gratuit.
1. Assurez-vous d'utiliser le Mode Agent GitHub Copilot.

   ![GitHub Copilot Agent Mode](../../../docs/images/setup-02.png)

1. Sélectionnez le modèle comme `GPT-4.1` ou `Claude Sonnet 4`.
1. Assurez-vous d'avoir configuré [Serveurs MCP](./00-setup.md#configurer-les-serveurs-mcp).

## Préparer les Instructions Personnalisées

1. Définissez la variable d'environnement `$REPOSITORY_ROOT`.

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. Copiez les instructions personnalisées.

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

## Préparer le Développement du Serveur MCP

Dans le répertoire `start`, une application ASP.NET Core Minimal API est déjà échafaudée. Vous l'utiliserez comme point de départ.

1. Assurez-vous d'avoir la variable d'environnement `$REPOSITORY_ROOT`.

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. Copiez l'application échafaudée vers `workshop` depuis `start`.

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

## Développer la Logique de Gestion de Liste de Tâches

1. Assurez-vous d'utiliser le Mode Agent GitHub Copilot avec le modèle `Claude Sonnet 4` ou `GPT-4.1`.
1. Assurez-vous que le serveur MCP `context7` fonctionne.
1. Utilisez le prompt suivant pour implémenter la logique de gestion de liste de tâches.

    ```text
    J'aimerais implémenter une logique de gestion de liste de tâches dans l'application ASP.NET Core Minimal API. Suivez les instructions ci-dessous pour le développement de l'application.
    
    - Utilisez context7.
    - Identifiez d'abord toutes les étapes que vous allez faire.
    - Votre répertoire de travail est `workshop/src/McpTodoServer.ContainerApp`.
    - Utilisez SQLite comme base de données et utilisez la fonctionnalité en mémoire.
    - Utilisez EntityFramework Core pour les transactions de base de données.
    - Initialisez la base de données au démarrage de l'application.
    - L'élément de tâche ne contient que les colonnes `ID`, `Text` et `IsCompleted`.
    - La gestion de liste de tâches a 5 fonctionnalités - créer, lister, mettre à jour, compléter et supprimer.
    - Si nécessaire, ajoutez des packages NuGet compatibles avec .NET 9.
    - N'implémentez PAS les endpoints API pour la gestion de liste de tâches.
    - N'ajoutez PAS de données initiales.
    - Ne faites PAS référence au répertoire `complete`.
    - Ne faites PAS référence au répertoire `start`.
    ```

1. Cliquez sur le bouton ![the keep button image](https://img.shields.io/badge/keep-blue) de GitHub Copilot pour prendre les modifications.
1. Utilisez le prompt suivant pour vérifier le résultat du développement.

    ```text
    J'aimerais construire l'application. Suivez les instructions.

    - Utilisez context7.
    - Construisez l'application et vérifiez si elle se construit correctement.
    - Si la construction échoue, analysez les problèmes et corrigez-les.
    ```

   > **NOTE** :
   >
   > - Jusqu'à ce que la construction réussisse, itérez cette étape.
   > - Si la construction continue d'échouer, vérifiez les messages d'erreur et demandez à GitHub Copilot Agent de les résoudre.

1. Cliquez sur le bouton ![the keep button image](https://img.shields.io/badge/keep-blue) de GitHub Copilot pour prendre les modifications.
1. Utilisez le prompt suivant pour vérifier le résultat du développement.

    ```text
    J'aimerais ajouter la classe `TodoTool` à l'application. Suivez les instructions.

    - Utilisez context7.
    - Identifiez d'abord toutes les étapes que vous allez faire.
    - Votre répertoire de travail est `workshop/src/McpTodoServer.ContainerApp`.
    - La classe `TodoTool` doit contenir 5 méthodes - créer, lister, mettre à jour, compléter et supprimer.
    - N'enregistrez PAS de dépendance.
    ```

## Supprimer la Logique API

1. Assurez-vous d'avoir la variable d'environnement `$REPOSITORY_ROOT`.

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. Naviguez vers le projet d'application.

    ```bash
    cd $REPOSITORY_ROOT/workshop/src/McpTodoServer.ContainerApp
    ```

1. Ouvrez `Program.cs` et supprimez tout ce qui suit :

   ```csharp
   // 👇👇👇 Supprimer 👇👇👇
   // Add services to the container.
   // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
   builder.Services.AddOpenApi();
   // 👆👆👆 Supprimer 👆👆👆
   ```

   ```csharp
   // 👇👇👇 Supprimer 👇👇👇
   // Configure the HTTP request pipeline.
   if (app.Environment.IsDevelopment())
   {
       app.MapOpenApi();
   }
   // 👆👆👆 Supprimer 👆👆👆
   ```

   ```csharp
   // 👇👇👇 Supprimer 👇👇👇
   var summaries = new[]
   {
       "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
   };
   // 👆👆👆 Supprimer 👆👆👆
   ```

   ```csharp
   // 👇👇👇 Supprimer 👇👇👇
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
   // 👆👆👆 Supprimer 👆👆👆
   ```

   ```csharp
   // 👇👇👇 Supprimer 👇👇👇
   record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
   {
       public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
   }
   // 👆👆👆 Supprimer 👆👆👆
   ```

1. Supprimer le paquet NuGet.

    ```bash
    dotnet remove package Microsoft.AspNetCore.OpenApi
    ```

## Convertir en Serveur MCP

1. Ajouter le paquet NuGet pour le serveur MCP.

    ```bash
    dotnet add package ModelContextProtocol.AspNetCore --prerelease
    ```

1. Ouvrez `Program.cs`, trouvez `var app = builder.Build();` et ajoutez le fragment de code suivant juste au-dessus de la ligne :

    ```csharp
    // 👇👇👇 Ajouter 👇👇👇
    builder.Services.AddMcpServer()
                    .WithHttpTransport(o => o.Stateless = true)
                    .WithToolsFromAssembly();
    // 👆👆👆 Ajouter 👆👆👆
    
    var app = builder.Build();
    ```

1. Dans le même `Program.cs`, trouvez `app.Run();` et ajoutez le fragment de code suivant juste au-dessus de la ligne :

    ```csharp
    // 👇👇👇 Ajouter 👇👇👇
    app.MapMcp("/mcp");
    // 👆👆👆 Ajouter 👆👆👆
    
    app.Run();
    ```

1. Ouvrez `TodoTool.cs` et ajoutez des décorateurs comme ci-dessous.

   > **NOTE** : Les noms de méthodes peuvent être différents selon la façon dont GitHub Copilot les génère.

    ```csharp
    // 👇👇👇 Ajouter 👇👇👇
    [McpServerToolType]
    // 👆👆👆 Ajouter 👆👆👆
    public class TodoTool
    
    ...
    
        // 👇👇👇 Ajouter 👇👇👇
        [McpServerTool(Name = "add_todo_item", Title = "Add a to-do item")]
        [Description("Adds a to-do item to database.")]
        // 👆👆👆 Ajouter 👆👆👆
        public async Task<TodoItem> CreateAsync(string text)
    
    ...
    
        // 👇👇👇 Ajouter 👇👇👇
        [McpServerTool(Name = "get_todo_items", Title = "Get a list of to-do items")]
        [Description("Gets a list of to-do items from database.")]
        // 👆👆👆 Ajouter 👆👆👆
        public async Task<List<TodoItem>> ListAsync()
    
    ...
    
        // 👇👇👇 Ajouter 👇👇👇
        [McpServerTool(Name = "update_todo_item", Title = "Update a to-do item")]
        [Description("Updates a to-do item in the database.")]
        // 👆👆👆 Ajouter 👆👆👆
        public async Task<TodoItem?> UpdateAsync(int id, string text)
    
    ...
    
        // 👇👇👇 Ajouter 👇👇👇
        [McpServerTool(Name = "complete_todo_item", Title = "Complete a to-do item")]
        [Description("Completes a to-do item in the database.")]
        // 👆👆👆 Ajouter 👆👆👆
        public async Task<TodoItem?> CompleteAsync(int id)
    
    ...
    
        // 👇👇👇 Ajouter 👇👇👇
        [McpServerTool(Name = "delete_todo_item", Title = "Delete a to-do item")]
        [Description("Deletes a to-do item from the database.")]
        // 👆👆👆 Ajouter 👆👆👆
        public async Task<bool> DeleteAsync(int id)
    
    ...
    ```

1. Dans le même `TodoTool.cs`, ajoutez des directives `using` supplémentaires :

   > **NOTE** : L'espace de noms peut être différent selon la façon dont GitHub Copilot les génère.

    ```csharp
    // 👇👇👇 Ajouter 👇👇👇
    using ModelContextProtocol.Server;
    using System.ComponentModel;
    // 👆👆👆 Ajouter 👆👆👆
    
    namespace McpTodoServer.ContainerApp.Tools;
    ```

1. Construire l'application.

    ```bash
    dotnet build
    ```

## Exécuter le Serveur MCP

1. Assurez-vous d'avoir la variable d'environnement `$REPOSITORY_ROOT`.

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. Naviguez vers le projet d'application.

    ```bash
    cd $REPOSITORY_ROOT/workshop/src/McpTodoServer.ContainerApp
    ```

1. Exécutez l'application serveur MCP.

    ```bash
    dotnet run
    ```

1. Ouvrez la Palette de Commandes en appuyant sur `F1` ou `Ctrl`+`Shift`+`P` sur Windows ou `Cmd`+`Shift`+`P` sur Mac OS, et recherchez `MCP: Add Server...`.
1. Choisissez `HTTP (HTTP or Server-Sent Events)`.
1. Entrez `http://localhost:5242` comme URL du serveur.
1. Entrez `mcp-todo-local` comme ID du serveur.
1. Choisissez `Workspace settings` comme emplacement pour sauvegarder les paramètres MCP.
1. Ouvrez `.vscode/mcp.json` et vérifiez que le serveur MCP a été ajouté.

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
        // 👇👇👇 Ajouté 👇👇👇
        "mcp-todo-local": {
            "url": "http://localhost:5242/mcp"
        }
        // 👆👆👆 Ajouté 👆👆👆
      }
    }
    ```

## Tester le Serveur MCP

1. Ouvrez GitHub Copilot Chat en Mode Agent.
1. Entrez l'un des prompts ci-dessous :

    ```text
    Montrez-moi la liste de tâches.
    Ajouter "déjeuner à 12h".
    Marquer le déjeuner comme terminé.
    Ajouter "réunion à 15h".
    Changer la réunion à 15h30.
    Annuler la réunion.
    ```

1. Si une erreur se produit, demandez à GitHub Copilot de la corriger :

    ```text
    J'ai eu une erreur "xxx". Veuillez trouver le problème et le corriger.
    ```

---

Parfait. Vous avez terminé l'étape "Développement du Serveur MCP". Passons maintenant à [ÉTAPE 02 : Serveur MCP Distant](./02-mcp-remote-server.md).

---

Ce document a été localisé par [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot). Par conséquent, il peut contenir des erreurs. Si vous trouvez une traduction inappropriée ou erronée, veuillez créer un [issue](../../../../../issues).