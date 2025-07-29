Ce projet utilise .NET 9 et C# 13.

Assurez-vous que tout le code généré se trouve dans le projet MyMonkeyApp, qui peut être un sous-dossier à l'intérieur du dossier principal.

Il est sur GitHub à https://github.com/YOUR_USERNAME/YOUR_REPO_NAME

## Contexte du Projet
Il s'agit d'une application console qui gère les données des espèces de singes et s'intègre avec GitHub via les serveurs MCP.

## Normes de Codage C#
- Utilisez PascalCase pour les noms de classes, méthodes et propriétés
- Utilisez camelCase pour les variables locales et paramètres
- Utilisez des noms descriptifs qui indiquent clairement le but
- Ajoutez des commentaires de documentation XML pour les méthodes et classes publiques
- Utilisez `var` pour les variables locales quand le type est évident
- Préférez les types explicites quand cela améliore la lisibilité
- Utilisez async/await pour les opérations asynchrones
- Suivez le modèle repository pour l'accès aux données
- Utilisez une gestion appropriée des exceptions avec des blocs try-catch
- Implémentez IDisposable lors de la gestion des ressources
- Utilisez les types de référence nullable pour éviter les exceptions de référence nulle
- utilisez les espaces de noms à portée de fichier pour une organisation de code plus propre

## Conventions de Nommage
- Classes : `MonkeyHelper`, `Monkey`, `Program`
- Méthodes : `GetMonkeys()`, `GetRandomMonkey()`, `GetMonkeyByName()`
- Propriétés : `Name`, `Location`, `Population`
- Variables : `selectedMonkey`, `monkeyCount`, `userInput`
- Constantes : `MAX_MONKEYS`, `DEFAULT_POPULATION`

## Architecture
- Application console avec menu interactif
- Classe d'aide statique pour la gestion des données
- Classes de modèle pour la représentation des données
- Séparation des préoccupations entre UI et logique métier

---

Ce document a été localisé par [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot). Par conséquent, il peut contenir des erreurs. Si vous trouvez une traduction inappropriée ou erronée, veuillez créer un [issue](../../../../../../issues).