using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.IdentityModel.Tokens;
using ServerGrpc;
using ServerGrpc.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;

JwtSecurityTokenHandler JwtTokenHandler = new JwtSecurityTokenHandler();
SymmetricSecurityKey SecurityKey = new SymmetricSecurityKey(Guid.NewGuid().ToByteArray());

var builder = WebApplication.CreateBuilder(args);

// Ajout du service Grpc
builder.Services.AddGrpc(options =>
{
    // Pour l'envoie de message sans limite de taille
    options.MaxSendMessageSize = null;
});
string pathCertifFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Certif", "tutogrpc.pfx");
builder.WebHost.ConfigureKestrel((context, options) =>
{
    options.Listen(IPAddress.Any, 5001, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http1AndHttp2AndHttp3;
        listenOptions.UseHttps(pathCertifFile, "PassCtrlAltSuppr");
    });
});

builder.Services.AddSingleton<IDataService, DataService>();

builder.Services.AddControllers();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(JwtBearerDefaults.AuthenticationScheme, policy =>
    {
        policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
        policy.RequireClaim(ClaimTypes.Name);
    });
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateActor = false,
                ValidateLifetime = true,
                IssuerSigningKey = SecurityKey
            };
    });

var app = builder.Build();
app.UseRouting();

// Ajout de l'authentification
app.UseAuthentication();
app.UseAuthorization();

app.MapGrpcService<UtilisateursService>();
app.MapGet("/", () => "C'est pour l'article sur gRPC sur www.ctrl-alt-suppr.dev");

// Pour le controler
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


// Création des utilisateurs dans la base de donnée
var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

    // Vrai si la base de données est créée, false si elle existait déjà.
    if (db.Database.EnsureCreated())
    {
        DataInitializer.InitData(roleManager, userManager).Wait();
    }
}

app.Run();


/// <summary>
/// Permet de générer le Token JWT
/// </summary>
string GenerateJwtToken(string name)
{
    if (string.IsNullOrEmpty(name))
    {
        throw new InvalidOperationException("Name is not specified.");
    }

    var claims = new[] { new Claim(ClaimTypes.Name, name) };
    var credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);
    var token = new JwtSecurityToken("ExampleServer", "ExampleClients", claims, expires: DateTime.Now.AddSeconds(60), signingCredentials: credentials);
    return JwtTokenHandler.WriteToken(token);
}
