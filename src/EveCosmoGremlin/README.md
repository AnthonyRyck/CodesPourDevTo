C'est un projet console qui permet d'injecter les données des systèmes solaires et des connexions entre ces systèmes, du jeu EveOnline dans une base de donnée Gremlin.  
Dans la class ```Loader```, il faut reseigner les informations du compte Azure COSMOS Gremlin.

```csharp
private static string hostname = "ACCOUNT_NAME.gremlin.cosmos.azure.com";
private static int port = 443;
private static string authKey = "YOUR_PRIMARY_KEY";
private static string database = "DB_NAME";
private static string collection = "GRAPH_NAME";
```

Les fichiers de données se trouve sur : https://github.com/AnthonyRyck/CodesPourDevTo/tree/master/src/Files/EveOnline
