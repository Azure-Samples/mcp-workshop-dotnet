# 01 : Développement d'Application Monkey avec MCP

Dans cette étape, vous construisez une application console simple utilisant des serveurs MCP.

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

   ![Ouvrir GitHub Copilot Chat](./images/setup-01.png)

1. Si on vous demande de vous connecter ou de vous inscrire, faites-le. C'est gratuit.
1. Assurez-vous d'utiliser le Mode Agent GitHub Copilot.

   ![Mode Agent GitHub Copilot](./images/setup-02.png)

1. Sélectionnez le modèle `GPT-4.1` ou `Claude Sonnet 4`.
1. Assurez-vous d'avoir configuré les [Serveurs MCP](./00-setup.md#configurer-les-serveurs-mcp).

## Démarrer le Serveur MCP &ndash; GitHub

1. Ouvrez la Palette de Commandes en tapant `F1` ou `Ctrl`+`Shift`+`P` sur Windows ou `Cmd`+`Shift`+`P` sur Mac OS, et recherchez `MCP: List Servers`.
1. Choisissez `github` puis cliquez sur `Start Server`. Il se peut qu'on vous demande de vous connecter à GitHub pour utiliser ce serveur MCP.

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
    cp $REPOSITORY_ROOT/docs/.github/monkeyapp-instructions.md \
       $REPOSITORY_ROOT/.github/copilot-instructions.md
    ```

    ```powershell
    # PowerShell
    Copy-Item -Path $REPOSITORY_ROOT/docs/.github/monkeyapp-instructions.md `
              -Destination $REPOSITORY_ROOT/.github/copilot-instructions.md -Force
    ```

1. Ouvrez `.github/copilot-instructions.md` et remplacez `https://github.com/YOUR_USERNAME/YOUR_REPO_NAME` par le vôtre. Par exemple, `https://github.com/octocat/monkey-app`.

## Créer une Application Console

1. Créez une application console sous le répertoire `workshop`.

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

## Gérer le Dépôt GitHub

1. Entrez le prompt suivant à GitHub Copilot pour pousser l'application console créée.

    ```text
    Push the current changes to the `main` branch of the repository.
    ```

1. Entrez le prompt suivant à GitHub Copilot pour générer un issue sur le dépôt.

    ```text
    Create a new GitHub issue in my repository titled 'Implement Monkey Console Application' with the following requirements:
    
    - Create a C# console app that can list all available monkeys, get details for a specific monkey by name, and pick a random monkey.
    - The app should use a Monkey model class and include ASCII art for visual appeal.
    - Add appropriate labels like 'enhancement' and 'good first issue'.
    - Add some details about how we may go about implementing this and a checklist for what we will need to do.
    ```

1. Assignez `@Copilot` à l'issue et observez ce qui se passe.

## Démarrer le Serveur MCP &ndash; Monkey MCP

1. Ouvrez la Palette de Commandes en tapant `F1` ou `Ctrl`+`Shift`+`P` sur Windows ou `Cmd`+`Shift`+`P` sur Mac OS, et recherchez `MCP: List Servers`.
1. Assurez-vous que le serveur MCP `github` fonctionne.
1. Choisissez `monkeymcp` puis cliquez sur `Start Server`.

## Développer l'Application Monkey avec GitHub Copilot et les Serveurs MCP

1. Entrez le prompt suivant pour obtenir la liste des singes.

    ```text
    Get me a list of monkeys that are available and display them in a table with their details.
    ```

1. Entrez le prompt suivant pour obtenir une idée du modèle de données pour un singe.

    ```text
    What would a data model look like for this structure?
    ```

1. Entrez le prompt suivant pour créer un fichier pour la classe du modèle de données.

    ```text
    Let's create a new file for this class.
    ```

1. Entrez le prompt suivant pour créer une classe `MonkeyHelper`.

    ```text
    Let's create a new class called MonkeyHelper that is static. It should manage a collection of monkey data. Include methods to get all monkeys, get a random monkey, find a monkey by name, and track access count to when a random monkey is picked. The data for the monkeys should come from the Monkey MCP server that we just got.
    ```

1. Entrez le prompt suivant pour mettre à jour l'application console.

    ```text
    Let's update the app now to have a nice menu with the following options that will call into that `MonkeyHelper`.
    
    1. List all monkeys
    2. Get details for a specific monkey by name
    3. Get a random monkey
    4. Exit app

    Also display some funny ASCII art randomly.
    ```

1. Entrez le prompt suivant à GitHub Copilot pour pousser l'application console mise à jour.

    ```text
    Push the current changes to the `mymonkeyapp` branch of the repository.
    With this branch, create a PR against the `main` branch.
    Connect this PR to the issue created before.
    Then, merge this PR and close the issue.
    ```

---

OK. Vous avez terminé l'étape "Développement d'Application Monkey avec MCP". Passons à [ÉTAPE 02 : Serveur MCP](./02-mcp-server.md).