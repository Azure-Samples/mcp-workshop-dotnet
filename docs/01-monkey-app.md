# 01: Monkey App Development with MCP

In this step, you're building a simple console app using MCP servers.

## Prerequisites

Refer to the [README](../README.md#prerequisites) doc for preparation.

## Getting Started

- [Check GitHub Copilot Agent Mode](#check-github-copilot-agent-mode)
- [Start MCP Server – GitHub](#start-mcp-server--github)
- [Prepare Custom Instructions](#prepare-custom-instructions)
- [Scaffold Console App](#scaffold-console-app)
- [Manage GitHub Repository](#manage-github-repository)
- [Start MCP Server – Monkey MCP](#start-mcp-server--monkey-mcp)
- [Develop Monkey App with GitHub Copilot and MCP Servers](#develop-monkey-app-with-github-copilot-and-mcp-servers)

## Check GitHub Copilot Agent Mode

1. Click the GitHub Copilot icon on the top of GitHub Codespace or VS Code and open GitHub Copilot window.

   ![Open GitHub Copilot Chat](./images/setup-01.png)

1. If you're asked to login or sign up, do it. It's free of charge.
1. Make sure you're using GitHub Copilot Agent Mode.

   ![GitHub Copilot Agent Mode](./images/setup-02.png)

1. Select model to either `GPT-4.1` or `Claude Sonnet 4`.
1. Make sure that you've configured [MCP Servers](./00-setup.md#set-up-mcp-servers).

## Start MCP Server &ndash; GitHub

1. Open Command Palette by typing `F1` or `Ctrl`+`Shift`+`P` on Windows or `Cmd`+`Shift`+`P` on Mac OS, and search `MCP: List Servers`.
1. Choose `github` then click `Start Server`. You might be asked to login to GitHub to use this MCP server.

## Prepare Custom Instructions

1. Set the environment variable of `$REPOSITORY_ROOT`.

   ```bash
   # bash/zsh
   REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
   ```

   ```powershell
   # PowerShell
   $REPOSITORY_ROOT = git rev-parse --show-toplevel
   ```

1. Copy custom instructions.

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

1. Open `.github/copilot-instructions.md` and replace `https://github.com/YOUR_USERNAME/YOUR_REPO_NAME` with yours. For example, `https://github.com/octocat/monkey-app`.

## Scaffold Console App

1. Create a console app under the `workshop` directory.

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

## Manage GitHub Repository

1. Enter the following prompt to GitHub Copilot to push the scaffolded console app.

    ```text
    Push the current changes to the `main` branch of the repository.
    ```

1. Enter the following prompt to GitHub Copilot to generate an issue on the repository.

    ```text
    Create a new GitHub issue in my repository titled 'Implement Monkey Console Application' with the following requirements:
    
    - Create a C# console app that can list all available monkeys, get details for a specific monkey by name, and pick a random monkey.
    - The app should use a Monkey model class and include ASCII art for visual appeal.
    - Add appropriate labels like 'enhancement' and 'good first issue'.
    - Add some details about how we may go about implementing this and a checklist for what we will need to do.
    ```

1. Assign `@Copilot` to the issue and watch what is happening.

## Start MCP Server &ndash; Monkey MCP

1. Open Command Palette by typing `F1` or `Ctrl`+`Shift`+`P` on Windows or `Cmd`+`Shift`+`P` on Mac OS, and search `MCP: List Servers`.
1. Make sure the `github` MCP server is up and running.
1. Choose `monkeymcp` then click `Start Server`.

## Develop Monkey App with GitHub Copilot and MCP Servers

1. Enter the following prompt to get the list of monkeys.

    ```text
    Get me a list of monkeys that are available and display them in a table with their details.
    ```

1. Enter the following prompt to get an idea of data model for a monkey.

    ```text
    What would a data model look like for this structure?
    ```

1. Enter the following prompt to create a file for the data model class.

    ```text
    Let's create a new file for this class.
    ```

1. Enter the following prompt to create a `MonkeyHelper` class.

    ```text
    Let's create a new class called MonkeyHelper that is static. It should manage a collection of monkey data. Include methods to get all monkeys, get a random monkey, find a monkey by name, and track access count to when a random monkey is picked. The data for the monkeys should come from the Monkey MCP server that we just got.
    ```

1. Enter the following prompt to update the console app.

    ```text
    Let's update the app now to have a nice menu with the following options that will call into that `MonkeyHelper`.
    
    1. List all monkeys
    2. Get details for a specific monkey by name
    3. Get a random monkey
    4. Exit app

    Also display some funny ASCII art randomly.
    ```

1. Enter the following prompt to GitHub Copilot to push the updated console app.

    ```text
    Push the current changes to the `mymonkeyapp` branch of the repository.
    With this branch, create a PR against the `main` branch of your repository, not the upstream one.
    Connect this PR to the issue created before.
    Then, merge this PR and close the issue.
    ```

---

OK. You've completed the "Monkey App Development with MCP" step. Let's move onto [STEP 02: MCP Server](./02-mcp-server.md).
