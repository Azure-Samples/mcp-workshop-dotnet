Este proyecto es .NET 9 y usa C# 13.

Asegúrate de que todo el código generado esté dentro del proyecto MyMonkeyApp, que puede ser una subcarpeta dentro de la carpeta principal.

Está en GitHub en https://github.com/YOUR_USERNAME/YOUR_REPO_NAME

## Contexto del Proyecto
Esta es una aplicación de consola que gestiona datos de especies de monos e se integra con GitHub a través de servidores MCP.

## Estándares de Codificación C#
- Usa PascalCase para nombres de clases, métodos y propiedades
- Usa camelCase para variables locales y parámetros
- Usa nombres descriptivos que indiquen claramente el propósito
- Agrega comentarios de documentación XML para métodos y clases públicos
- Usa `var` para variables locales cuando el tipo sea obvio
- Prefiere tipos explícitos cuando mejore la legibilidad
- Usa async/await para operaciones asíncronas
- Sigue el patrón repository para acceso a datos
- Usa manejo apropiado de excepciones con bloques try-catch
- Implementa IDisposable al gestionar recursos
- Usa tipos de referencia anulables para evitar excepciones de referencia nula
- usa namespaces con ámbito de archivo para organización de código más limpia

## Convenciones de Nomenclatura
- Clases: `MonkeyHelper`, `Monkey`, `Program`
- Métodos: `GetMonkeys()`, `GetRandomMonkey()`, `GetMonkeyByName()`
- Propiedades: `Name`, `Location`, `Population`
- Variables: `selectedMonkey`, `monkeyCount`, `userInput`
- Constantes: `MAX_MONKEYS`, `DEFAULT_POPULATION`

## Arquitectura
- Aplicación de consola con menú interactivo
- Clase auxiliar estática para gestión de datos
- Clases modelo para representación de datos
- Separación de responsabilidades entre UI y lógica de negocio

---

Este documento ha sido localizado por [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot). Por lo tanto, puede contener errores. Si encuentras alguna traducción inapropiada o errónea, por favor crea un [issue](../../../../../../issues).