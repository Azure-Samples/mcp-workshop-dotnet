此项目使用 .NET 9 和 C# 13。

确保所有生成的代码都在 MyMonkeyApp 项目内，该项目可能是主文件夹内的子文件夹。

它在 GitHub 上的位置是 https://github.com/YOUR_USERNAME/YOUR_REPO_NAME

## 项目上下文
这是一个管理猴子物种数据并通过 MCP 服务器与 GitHub 集成的控制台应用程序。

## C# 编码标准
- 类名、方法名和属性使用 PascalCase
- 局部变量和参数使用 camelCase
- 使用清楚表明目的的描述性名称
- 为公共方法和类添加 XML 文档注释
- 当类型明显时，对局部变量使用 `var`
- 当提高可读性时，优先使用显式类型
- 异步操作使用 async/await
- 数据访问遵循仓储模式
- 使用 try-catch 块进行适当的异常处理
- 管理资源时实现 IDisposable
- 使用可为空引用类型以避免空引用异常
- 使用文件范围命名空间以实现更清洁的代码组织

## 命名约定
- 类：`MonkeyHelper`、`Monkey`、`Program`
- 方法：`GetMonkeys()`、`GetRandomMonkey()`、`GetMonkeyByName()`
- 属性：`Name`、`Location`、`Population`
- 变量：`selectedMonkey`、`monkeyCount`、`userInput`
- 常量：`MAX_MONKEYS`、`DEFAULT_POPULATION`

## 架构
- 带有交互式菜单的控制台应用程序
- 用于数据管理的静态辅助类
- 用于数据表示的模型类
- UI 和业务逻辑之间的关注点分离

---

本文档已由 [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot) 本地化。因此，可能包含错误。如果您发现任何不当或错误的翻译，请创建一个 [issue](../../../../../../issues)。