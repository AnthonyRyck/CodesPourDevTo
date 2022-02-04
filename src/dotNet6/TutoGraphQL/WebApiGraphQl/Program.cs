using WebApiGraphQl.RequetesGraph;

var builder = WebApplication.CreateBuilder(args);

// Service pour "gerer" les donnees
builder.Services.AddSingleton<IDataAccess, DataAccess>();

builder.Services.AddGraphQLServer()
				.AddQueryType<ElRequetor>()
				.AddSorting();

var app = builder.Build();

app.MapGraphQL("/");

app.Run();
