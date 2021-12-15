using ServerGrpc.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IDataService, DataService>();

// Ajout du service Grpc
builder.Services.AddGrpc(options =>
{
    options.MaxSendMessageSize = null;
});

builder.Services.AddControllers();

var app = builder.Build();

app.MapGrpcService<UtilisateursService>();
app.MapGet("/", () => "C'est la loose...");

// Pour le controler
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.Run();
