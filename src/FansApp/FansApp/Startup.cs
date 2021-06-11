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

			// Un service pour simuler l'acc�s � une base de donn�es, ou un service API
			services.AddSingleton<IAccessDatabase, FakeAccessDatabase>();

			// ViewModel pour le FanClub
			services.AddScoped<IFanClubViewModel, FanClubViewModel>();

			// ViewModel pour un Fan
			services.AddScoped<IFanViewModel, FanViewModel>();

			// Service pour remettre � z�ro
			services.AddHostedService<ResetHostedService>();

			// Titanic Model
			services.AddScoped<ITitanicViewModel, TitanicViewModel>();

			// Service pour la localization
			services.AddLocalization(options => options.ResourcesPath = "Resources");
			services.Configure<RequestLocalizationOptions>(options =>
			{
				// D�finition de la liste de langue pris en charge.
				var supportedCultures = new List<CultureInfo>()
									{
										 new CultureInfo("en-US"),
										 new CultureInfo("fr-FR")
									};

				// Langue par d�faut
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

			services.AddScoped<IMiddleViewModel, MiddleViewModel>();
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
				ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
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
