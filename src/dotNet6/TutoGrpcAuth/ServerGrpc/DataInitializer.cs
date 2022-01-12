using Microsoft.AspNetCore.Identity;

namespace ServerGrpc
{
    public static class DataInitializer
    {
        //NOTE : Mettre les noms des rôles que vous voulez.
        private static readonly string[] Roles = new string[] { "Admin", "Manager", "Member" };
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
            await CreateUser("root", "Admin", userManager);

            // Création d'un utilisateur Membre
            await CreateUser("theManager", "Manager", userManager);

            // Création d'un utilisateur Membre
            await CreateUser("MarcelMembre", "Member", userManager);
        }

        private static async Task CreateUser(string name, string role, UserManager<IdentityUser> userManager)
        {
            // Création de l'utilisateur Root.
            var user = await userManager.FindByNameAsync(name);
            if (user == null)
            {
                var poweruser = new IdentityUser
                {
                    UserName = name,
                    Email = name + "@email.com",
                    EmailConfirmed = true
                };
                string userPwd = "Azerty123!";
                var createPowerUser = await userManager.CreateAsync(poweruser, userPwd);
                if (createPowerUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(poweruser, role);
                }
            }
        }
    }
}
