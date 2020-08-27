using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace SQLiteWithRoot.Code
{
    public static class DataInitializer
	{
		private static readonly string[] Roles = new string[] { "Admin", "Manager", "Member" };

		public static async Task SeedRolesAsync(IServiceProvider serviceProvider)
		{
			using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
			{
				var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

				foreach (var role in Roles)
				{
					if (!await roleManager.RoleExistsAsync(role))
					{
						await roleManager.CreateAsync(new IdentityRole(role));
					}
				}

				// Création de l'utilisateur Root.
				var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
				var user = await userManager.FindByNameAsync("root@email.com");

				if (user == null)
				{
					var poweruser = new IdentityUser
					{
						UserName = "root@email.com",
						Email = "root@email.com",
						EmailConfirmed = true
					};
					string userPwd = "Azerty123!";

					var createPowerUser = await userManager.CreateAsync(poweruser, userPwd);
					if (createPowerUser.Succeeded)
					{
						await userManager.AddToRoleAsync(poweruser, "Admin");
					}
				}
			}
		}

	}
}