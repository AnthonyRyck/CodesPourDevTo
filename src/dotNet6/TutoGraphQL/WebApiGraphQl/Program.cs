using WebApiGraphQl.RequetesGraph;

var builder = WebApplication.CreateBuilder(args);

// Add Application Db Context options
builder.Services.AddSingleton<IDataAccess, DataAccess>();

// Creation de la base SQLite et ajout des donnees.
builder.Services.AddGraphQLServer()
				.AddQueryType<ElRequetor>();

var app = builder.Build();

app.MapGraphQL("/graphql");

app.Run();
