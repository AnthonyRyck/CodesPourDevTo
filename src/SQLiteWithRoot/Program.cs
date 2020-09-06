using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SQLiteWithRoot.Data;
using SQLiteWithRoot.Code;
using Microsoft.AspNetCore.Identity;

namespace SQLiteWithRoot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            // Création du répertoire pour la base de donnée
            string pathDatabase = Path.Combine(AppContext.BaseDirectory, "database");
            if(!Directory.Exists(pathDatabase))
                Directory.CreateDirectory(pathDatabase);

            var scopeFactory = host.Services.GetRequiredService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                if (db.Database.EnsureCreated())
                {
                    DataInitializer.InitData(roleManager, userManager).Wait();
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

    }
}