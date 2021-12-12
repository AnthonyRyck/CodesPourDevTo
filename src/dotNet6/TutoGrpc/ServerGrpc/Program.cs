using GrpcServer.Services;


var builder = WebApplication.CreateBuilder(args);

// Ajout du service Grpc
builder.Services.AddGrpc();

var app = builder.Build();

app.MapGrpcService<NomDuService>();
app.MapGet("/", () => "C'est la loose...");

app.Run();
