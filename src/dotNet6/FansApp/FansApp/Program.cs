using FansApp.CustomMiddleware;
using FansApp.Data;
using FansApp.Hubs;
using FansApp.Services;
using FansApp.ViewModel;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Options;
using System.Globalization;
using Toolbelt.Blazor.Extensions.DependencyInjection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

#region Startup / ConfigureServices

// Présent dans Configurebuilder.Services (avant... .Net5)

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddTransient<IHubService, HubService>();

// Un service pour simuler l'accès à une base de données, ou un service API
builder.Services.AddSingleton<IAccessDatabase, FakeAccessDatabase>();

// ViewModel pour le FanClub
builder.Services.AddScoped<IFanClubViewModel, FanClubViewModel>();

// ViewModel pour un Fan
builder.Services.AddScoped<IFanViewModel, FanViewModel>();

// Service pour remettre à zéro
builder.Services.AddHostedService<ResetHostedService>();

// Titanic Model
builder.Services.AddScoped<ITitanicViewModel, TitanicViewModel>();

// ViewModel pour la page Index, avec HotKeys
builder.Services.AddScoped<IIndexViewModel, IndexViewModel>();

// Service pour la localization
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
	// Définition de la liste de langue pris en charge.
	var supportedCultures = new List<CultureInfo>()
									{
										 new CultureInfo("en-US"),
										 new CultureInfo("fr-FR")
									};

	// Langue par défaut
	options.DefaultRequestCulture = new RequestCulture("en-US");

	options.SupportedCultures = supportedCultures;
	options.SupportedUICultures = supportedCultures;
});

// Service pour SignalR
builder.Services.AddSignalR();
builder.Services.AddResponseCompression(opts =>
{
	opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
		new[] { "application/octet-stream" });
});

// Service pour Info utilisateur
builder.Services.AddSingleton<ICounterUser, CounterUser>();

// Service pour le Middleware
builder.Services.AddScoped<IMiddleViewModel, MiddleViewModel>();

// Récupération des informations.
// NOTE : A remplacer si pas d'utilisation dans une image DOCKER !
string qnaEndPoint = Environment.GetEnvironmentVariable("QNA_ENDPOINT");
string qnaEndPointKey = Environment.GetEnvironmentVariable("QNA_ENDPOINT_KEY");
string qnaIdApp = Environment.GetEnvironmentVariable("QNA_ID_APP");

// Dans le cas si l'utilisation ne se fait pas avec Docker.
//string qnaEndPoint = "METTRE lE ENDPOINT";
//string qnaEndPointKey = "METTRE LA KEY DU ENDPOINT";
//string qnaIdApp = "ID DE LA BASE";

// Service pour la page de Chatbot
builder.Services.AddSingleton(new InfoVariablesEnvironment(qnaEndPoint, qnaEndPointKey, qnaIdApp));
builder.Services.AddScoped<IWebChatViewModel, WebChatViewModel>();

// Service pour "Toolbelt HotKeys"
builder.Services.AddHotKeys();

#endregion


#region Startup / Configure

// SUPER IMPORTANT ! sinon Exception
var app = builder.Build();

// pour SignalR
app.UseResponseCompression();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
}

// Middleware pour la localization
app.UseRequestLocalization(app.Services.GetService<IOptions<RequestLocalizationOptions>>().Value);

app.UseStaticFiles();
app.UseRouting();

// Middleware Compteur
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
	ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedHost
});

app.UseMiddleware<CounterMiddleware>();
app.UseMiddleware<SecondMiddleware>();

// MapControllers - pour ajouter notre controller
app.MapControllers();
app.MapBlazorHub();

// pour SignalR
app.MapHub<FanHub>("/fanhub");
app.MapFallbackToPage("/_Host");

#endregion

// Et surtout ne pas l'oublier....
app.Run();