using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiSecureSample.Data
{
	public class DataInitializer
	{
        private static readonly string[] Roles = new string[] { "Admin", "Manager" };
        public static async Task InitData(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            foreach (var role in Roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Création de l'utilisateur Root.
            var user = await userManager.FindByNameAsync("root");

            if (user == null)
            {
                var poweruser = new IdentityUser
                {
                    UserName = "root",
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

            // Création du Manager.
            var theManager = await userManager.FindByNameAsync("theManager");

            if (theManager == null)
            {
                var powerManager = new IdentityUser
                {
                    UserName = "theManager",
                    Email = "theManager@email.com",
                    EmailConfirmed = true
                };
                string userPwd = "Azerty123!";
                var createPowerUser = await userManager.CreateAsync(powerManager, userPwd);
                if (createPowerUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(powerManager, "Manager");
                }
            }
        }

    }
}
