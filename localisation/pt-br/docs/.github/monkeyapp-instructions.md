Este projeto é .NET 9 e usa C# 13.

Certifique-se de que todo o código gerado esteja dentro do projeto MyMonkeyApp, que pode ser uma subpasta dentro da pasta principal.

Está no GitHub em https://github.com/YOUR_USERNAME/YOUR_REPO_NAME

## Contexto do Projeto
Esta é uma aplicação de console que gerencia dados de espécies de macacos e se integra com o GitHub através de servidores MCP.

## Padrões de Codificação C#
- Use PascalCase para nomes de classes, métodos e propriedades
- Use camelCase para variáveis locais e parâmetros
- Use nomes descritivos que indiquem claramente o propósito
- Adicione comentários de documentação XML para métodos e classes públicos
- Use `var` para variáveis locais quando o tipo for óbvio
- Prefira tipos explícitos quando melhorar a legibilidade
- Use async/await para operações assíncronas
- Siga o padrão repository para acesso a dados
- Use tratamento adequado de exceções com blocos try-catch
- Implemente IDisposable ao gerenciar recursos
- Use tipos de referência anuláveis para evitar exceções de referência nula
- use namespaces com escopo de arquivo para organização de código mais limpa

## Convenções de Nomenclatura
- Classes: `MonkeyHelper`, `Monkey`, `Program`
- Métodos: `GetMonkeys()`, `GetRandomMonkey()`, `GetMonkeyByName()`
- Propriedades: `Name`, `Location`, `Population`
- Variáveis: `selectedMonkey`, `monkeyCount`, `userInput`
- Constantes: `MAX_MONKEYS`, `DEFAULT_POPULATION`

## Arquitetura
- Aplicação de console com menu interativo
- Classe auxiliar estática para gerenciamento de dados
- Classes de modelo para representação de dados
- Separação de responsabilidades entre UI e lógica de negócio

---

Este documento foi localizado pelo [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot). Portanto, pode conter erros. Se você encontrar alguma tradução inadequada ou errônea, por favor crie um [issue](../../../../../../issues).