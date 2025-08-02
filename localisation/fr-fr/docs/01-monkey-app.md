# 01: Développement d'application Monkey avec MCP

Dans cette étape, vous construisez une application console simple en utilisant les serveurs MCP.

## Prérequis

Consultez la documentation [README](../README.md#prérequis) pour la préparation.

## Commencer

- [Vérifier le mode Agent GitHub Copilot](#vérifier-le-mode-agent-github-copilot)
- [Démarrer le serveur MCP – GitHub](#démarrer-le-serveur-mcp--github)
- [Préparer les instructions personnalisées](#préparer-les-instructions-personnalisées)
- [Créer une application console](#créer-une-application-console)
- [Gérer le dépôt GitHub](#gérer-le-dépôt-github)
- [Démarrer le serveur MCP – Monkey MCP](#démarrer-le-serveur-mcp--monkey-mcp)
- [Développer l'application Monkey avec GitHub Copilot et les serveurs MCP](#développer-lapplication-monkey-avec-github-copilot-et-les-serveurs-mcp)

## Vérifier le mode Agent GitHub Copilot

1. Cliquez sur l'icône GitHub Copilot en haut de GitHub Codespace ou VS Code et ouvrez la fenêtre GitHub Copilot.

   ![Ouvrir GitHub Copilot Chat](../../../docs/images/setup-01.png)

1. Si on vous demande de vous connecter ou de vous inscrire, faites-le. C'est gratuit.
1. Assurez-vous d'utiliser le mode Agent GitHub Copilot.

   ![Mode Agent GitHub Copilot](../../../docs/images/setup-02.png)

1. Sélectionnez le modèle `GPT-4.1` ou `Claude Sonnet 4`.
1. Assurez-vous d'avoir configuré les [serveurs MCP](./00-setup.md#configurer-les-serveurs-mcp).

## Démarrer le serveur MCP &ndash; GitHub

1. Ouvrez la palette de commandes en tapant `F1` ou `Ctrl`+`Shift`+`P` sur Windows ou `Cmd`+`Shift`+`P` sur Mac OS, et recherchez `MCP: List Servers`.
1. Choisissez `github` puis cliquez sur `Start Server`. Il se peut qu'on vous demande de vous connecter à GitHub pour utiliser ce serveur MCP.

## Préparer les instructions personnalisées

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

## Créer une application console

1. Créez une application console dans le répertoire `workshop`.

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

## Gérer le dépôt GitHub

1. Entrez le prompt suivant à GitHub Copilot pour pousser l'application console créée.

    ```text
    Poussez les changements actuels vers la branche `main` du dépôt.
    ```

1. Entrez le prompt suivant à GitHub Copilot pour générer un problème sur le dépôt.

    ```text
    Créez un nouveau problème GitHub dans mon dépôt intitulé 'Implémenter l'application console Monkey' avec les exigences suivantes :
    
    - Créer une application console C# qui peut lister tous les singes disponibles, obtenir les détails d'un singe spécifique par nom, et choisir un singe aléatoire.
    - L'application doit utiliser une classe modèle Monkey et inclure de l'art ASCII pour l'attrait visuel.
    - Ajouter des étiquettes appropriées comme 'enhancement' et 'good first issue'.
    - Ajouter quelques détails sur la façon dont nous pourrions procéder à l'implémentation et une liste de contrôle de ce que nous devrons faire.
    ```

1. Assignez `@Copilot` au problème et observez ce qui se passe.

## Démarrer le serveur MCP &ndash; Monkey MCP

1. Ouvrez la palette de commandes en tapant `F1` ou `Ctrl`+`Shift`+`P` sur Windows ou `Cmd`+`Shift`+`P` sur Mac OS, et recherchez `MCP: List Servers`.
1. Assurez-vous que le serveur MCP `github` est en marche.
1. Choisissez `monkeymcp` puis cliquez sur `Start Server`.

## Développer l'application Monkey avec GitHub Copilot et les serveurs MCP

1. Entrez le prompt suivant pour obtenir la liste des singes.

    ```text
    Obtenez-moi une liste des singes qui sont disponibles et affichez-les dans un tableau avec leurs détails.
    ```

1. Entrez le prompt suivant pour avoir une idée du modèle de données pour un singe.

    ```text
    À quoi ressemblerait un modèle de données pour cette structure ?
    ```

1. Entrez le prompt suivant pour créer un fichier pour la classe du modèle de données.

    ```text
    Créons un nouveau fichier pour cette classe.
    ```

1. Entrez le prompt suivant pour créer une classe `MonkeyHelper`.

    ```text
    Créons une nouvelle classe appelée MonkeyHelper qui est statique. Elle devrait gérer une collection de données de singes. Incluez des méthodes pour obtenir tous les singes, obtenir un singe aléatoire, trouver un singe par nom, et suivre le nombre d'accès quand un singe aléatoire est choisi. Les données pour les singes devraient provenir du serveur Monkey MCP que nous venons d'obtenir.
    ```

1. Entrez le prompt suivant pour mettre à jour l'application console.

    ```text
    Mettons à jour l'application maintenant pour avoir un joli menu avec les options suivantes qui appelleront ce `MonkeyHelper`.
    
    1. Lister tous les singes
    2. Obtenir les détails d'un singe spécifique par nom
    3. Obtenir un singe aléatoire
    4. Quitter l'application

    Affichez également de l'art ASCII amusant de manière aléatoire.
    ```

1. Entrez le prompt suivant à GitHub Copilot pour pousser l'application console mise à jour.

    ```text
    Poussez les changements actuels vers la branche `mymonkeyapp` du dépôt.
    Avant de pousser les modifications, assurez-vous que le répertoire `workshop` est inclus dans le push.
    Avec cette branche, créez une PR contre la branche `main` de votre dépôt, pas de l'upstream.
    Connectez cette PR au problème créé précédemment.
    Ensuite, fusionnez cette PR et fermez le problème.
    ```

---

OK. Vous avez terminé l'étape "Développement d'application Monkey avec MCP". Passons à [ÉTAPE 02: Serveur MCP](./02-mcp-server.md).

---

Ce document a été localisé par [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot). Par conséquent, il peut contenir des erreurs. Si vous trouvez une traduction inappropriée ou erronée, veuillez créer un [issue](../../../../../issues).