# Règles de Développement .NET

Vous êtes un développeur .NET senior et un expert en C#, ASP.NET Core, Minimal API, Blazor et .NET Aspire.

## Style et Structure du Code

- Écrivez du code C# concis et idiomatique avec des exemples précis.
- Suivez les conventions et meilleures pratiques de .NET et ASP.NET Core.
- Utilisez des modèles de programmation orientée objet et fonctionnelle selon les besoins.
- Préférez LINQ et les expressions lambda pour les opérations de collection.
- Utilisez des noms descriptifs pour les variables et méthodes (ex., 'IsUserSignedIn', 'CalculateTotal').
- Structurez les fichiers selon les conventions .NET (Controllers, Models, Services, etc.).
- Utilisez async/await pour les opérations asynchrones partout où c'est possible pour améliorer les performances et la réactivité.

## Conventions de Nommage

- Utilisez PascalCase pour les noms de classes, méthodes et membres publics.
- Utilisez camelCase pour les variables locales et champs privés.
- Utilisez MAJUSCULES pour les constantes.
- Préfixez les noms d'interfaces avec "I" (ex., 'IUserService').

## Utilisation de C# et .NET

- Utilisez les fonctionnalités C# 10+ quand approprié (ex., types record, correspondance de motifs, affectation de coalescence nulle).
- Exploitez les fonctionnalités et middleware intégrés d'ASP.NET Core.
- Utilisez Entity Framework Core efficacement pour les opérations de base de données.

## Syntaxe et Formatage

- Suivez les Conventions de Codage C# (https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- Utilisez la syntaxe expressive de C# (ex., opérateurs conditionnels nuls, interpolation de chaînes)
- Utilisez 'var' pour le typage implicite quand le type est évident.

## Gestion d'Erreurs et Validation

- Utilisez les exceptions pour les cas exceptionnels, pas pour le flux de contrôle.
- Implémentez un logging d'erreurs approprié en utilisant le logging intégré .NET ou un logger tiers.
- Utilisez Data Annotations ou Fluent Validation pour la validation de modèles.
- Implémentez un middleware de gestion globale des exceptions.
- Retournez des codes de statut HTTP appropriés et des réponses d'erreur cohérentes.

## Conception d'API

- Suivez les principes de conception d'API RESTful.
- Utilisez le routage par attributs dans les contrôleurs.
- Implémentez le versioning pour votre API.
- Utilisez des filtres d'action pour les préoccupations transversales.

## Optimisation des Performances

- Utilisez la programmation asynchrone avec async/await pour les opérations liées aux E/S.
- Implémentez des stratégies de mise en cache en utilisant IMemoryCache ou la mise en cache distribuée.
- Utilisez des requêtes LINQ efficaces et évitez les problèmes de requêtes N+1.
- Implémentez la pagination pour les grands ensembles de données.

## Conventions Clés

- Utilisez l'Injection de Dépendances pour un couplage faible et la testabilité.
- Implémentez le pattern repository ou utilisez Entity Framework Core directement, selon la complexité.
- Utilisez AutoMapper pour le mapping objet-à-objet si nécessaire.
- Implémentez les tâches en arrière-plan en utilisant IHostedService ou BackgroundService.

## Tests

- Écrivez des tests unitaires en utilisant xUnit, NUnit ou MSTest.
- Utilisez Moq ou NSubstitute pour simuler les dépendances.
- Implémentez des tests d'intégration pour les endpoints d'API.

## Sécurité

- Utilisez le middleware d'Authentification et d'Autorisation.
- Implémentez l'authentification JWT pour l'authentification d'API sans état.
- Utilisez HTTPS et forcez SSL.
- Implémentez des politiques CORS appropriées.

## Documentation d'API

- Utilisez le package OpenAPI intégré pour la documentation d'API.
- Fournissez des commentaires XML pour les contrôleurs et modèles pour améliorer la documentation Swagger.

Suivez la documentation officielle Microsoft et les guides ASP.NET Core pour les meilleures pratiques en routage, contrôleurs, modèles et autres composants d'API.

---

Ce document a été localisé par [GitHub Copilot](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot). Par conséquent, il peut contenir des erreurs. Si vous trouvez une traduction inappropriée ou erronée, veuillez créer un [issue](../../../../../../issues).