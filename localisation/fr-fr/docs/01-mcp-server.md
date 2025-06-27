# 01 : Serveur MCP

Dans cette étape, vous construisez un serveur MCP pour la gestion de liste de tâches.

## Prérequis

Référez-vous au document [README](../README.md#prerequisites) pour la préparation.

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

   ![GitHub Copilot Agent Mode](../../../docs/images/setup-01.png)

1. Sélectionnez le modèle comme `GPT-4.1` ou `Claude Sonnet 4`.
1. Assurez-vous d'avoir configuré [Serveurs MCP](./00-setup.md#set-up-mcp-servers).

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
    J'aimerais développer une application de liste de tâches en utilisant ASP.NET Core. Suivez les instructions.

    - Utilisez context7.
    - Identifiez d'abord toutes les étapes que vous allez faire.
    - Votre répertoire de travail est `workshop/src/McpTodoServer.ContainerApp`.
    - L'application doit inclure des modèles pour la gestion des tâches avec les propriétés : ID, titre, description, statut complété, date de création et date de mise à jour.
    - Si nécessaire, ajoutez des packages NuGet compatibles avec .NET 9.
    - N'implémentez PAS les endpoints API pour la gestion de liste de tâches.
    - N'ajoutez PAS de données initiales.
    - Ne faites PAS référence au répertoire `complete`.
    - Ne faites PAS référence au répertoire `start`.
    ```

1. Cliquez sur le bouton ![the keep button image](https://img.shields.io/badge/keep-blue) de GitHub Copilot pour prendre les modifications.

1. Utilisez le prompt suivant pour ajouter la classe TodoTool.

    ```text
    J'aimerais ajouter la classe `TodoTool` à l'application. Suivez les instructions.

    - Utilisez context7.
    - Identifiez d'abord toutes les étapes que vous allez faire.
    - Votre répertoire de travail est `workshop/src/McpTodoServer.ContainerApp`.
    - La classe `TodoTool` doit contenir 5 méthodes - créer, lister, mettre à jour, compléter et supprimer.
    - N'enregistrez PAS de dépendance.
    ```

1. Cliquez sur le bouton ![the keep button image](https://img.shields.io/badge/keep-blue) de GitHub Copilot pour prendre les modifications.

1. Utilisez le prompt suivant pour construire l'application.

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

1. Ouvrez GitHub Copilot Chat en Mode Agent.
1. Utilisez le prompt suivant pour convertir l'application en serveur MCP.

    ```text
    J'aimerais convertir cette application en serveur MCP. Suivez les instructions.

    - Utilisez context7.
    - Identifiez d'abord toutes les étapes que vous allez faire.
    - Votre répertoire de travail est `workshop/src/McpTodoServer.ContainerApp`.
    - Ajoutez les packages NuGet nécessaires pour MCP.
    - Implémentez le serveur MCP qui peut gérer les requêtes de gestion de liste de tâches.
    - Les méthodes doivent inclure : lister les tâches, créer une tâche, mettre à jour une tâche, compléter une tâche et supprimer une tâche.
    - Assurez-vous que l'application se construit après la conversion.
    ```

1. Cliquez sur le bouton ![the keep button image](https://img.shields.io/badge/keep-blue) de GitHub Copilot pour prendre les modifications.

## Exécuter le Serveur MCP

1. Ouvrez un terminal et naviguez vers le répertoire de l'application.

    ```bash
    cd workshop/src/McpTodoServer.ContainerApp
    ```

1. Exécutez l'application.

    ```bash
    dotnet run
    ```

   Vous devriez voir une sortie similaire à celle-ci :

    ```bash
    info: Microsoft.Hosting.Lifetime[14]
          Now listening on: http://localhost:5242
    info: Microsoft.Hosting.Lifetime[0]
          Application started. Press Ctrl+C to shut down.
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