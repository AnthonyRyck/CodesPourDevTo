using WebApiGraphQl.RequetesGraph;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Application Db Context options
builder.Services.AddSingleton<IDataAccess, DataAccess>();

// Création de la base SQLite et ajout des données.
builder.Services.AddGraphQLServer()
				.AddQueryType<ElRequetor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.MapGraphQL("/graphql");

app.Run();
