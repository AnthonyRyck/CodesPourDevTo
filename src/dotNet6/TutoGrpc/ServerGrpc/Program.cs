using Microsoft.AspNetCore.Server.Kestrel.Core;
using ServerGrpc.Services;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel((context, options) =>
{
    options.Listen(IPAddress.Any, 5001, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http1AndHttp2AndHttp3;
    });
});

builder.Services.AddSingleton<IDataService, DataService>();

// Ajout du service Grpc
builder.Services.AddGrpc(options =>
{
    // Pour l'envoie de message sans limite de taille
    options.MaxSendMessageSize = null;
});

builder.Services.AddControllers();

var app = builder.Build();
app.UseRouting();

app.MapGrpcService<UtilisateursService>();
app.MapGet("/", () => "C'est pour l'article sur gRPC sur www.ctrl-alt-suppr.dev");

// Pour le controler
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();