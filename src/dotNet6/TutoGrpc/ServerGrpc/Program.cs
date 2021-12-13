//using GrpcServer.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IDataService, DataService>();

// Ajout du service Grpc
builder.Services.AddGrpc();

var app = builder.Build();

//app.MapGrpcService<Dat>();
app.MapGet("/", () => "C'est la loose...");

app.Run();
