using FansApp.CustomMiddleware;
using FansApp.Data;
using FansApp.Hubs;
using FansApp.Services;
using FansApp.ViewModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace FansApp
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddRazorPages();
			services.AddServerSideBlazor();

			services.AddTransient<IHubService, HubService>();

			// Un service pour simuler l'accès à une base de données, ou un service API
			services.AddSingleton<IAccessDatabase, FakeAccessDatabase>();

			// ViewModel pour le FanClub
			services.AddScoped<IFanClubViewModel, FanClubViewModel>();

			// ViewModel pour un Fan
			services.AddScoped<IFanViewModel, FanViewModel>();

			// Service pour remettre à zéro
			services.AddHostedService<ResetHostedService>();

			// Titanic Model
			services.AddScoped<ITitanicViewModel, TitanicViewModel>();

			// Service pour la localization
			services.AddLocalization(options => options.ResourcesPath = "Resources");
			services.Configure<RequestLocalizationOptions>(options =>
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
			services.AddSignalR();
			services.AddResponseCompression(opts =>
			{
				opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
					new[] { "application/octet-stream" });
			});

			// Service pour Info utilisateur
			services.AddSingleton<ICounterUser, CounterUser>();

			// Service pour le Middleware
			services.AddScoped<IMiddleViewModel, MiddleViewModel>();

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
			services.AddSingleton(new InfoVariablesEnvironment(qnaEndPoint, qnaEndPointKey, qnaIdApp));
			services.AddScoped<IWebChatViewModel, WebChatViewModel>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			// pour SignalR
			app.UseResponseCompression();

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
			}

			// Middleware pour la localization
			app.UseRequestLocalization(app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value);

			app.UseStaticFiles();
			app.UseRouting();

			// Middleware Compteur
			app.UseForwardedHeaders(new ForwardedHeadersOptions
			{
				ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedHost
			});

			app.UseMiddleware<CounterMiddleware>();
			app.UseMiddleware<SecondMiddleware>();

			app.UseEndpoints(endpoints =>
			{
				// MapControllers - pour ajouter notre controller
				endpoints.MapControllers();
				endpoints.MapBlazorHub();
				// pour SignalR
				endpoints.MapHub<FanHub>("/fanhub");
				endpoints.MapFallbackToPage("/_Host");
			});
		}
	}
}


