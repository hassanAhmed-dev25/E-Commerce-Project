namespace ECommerceProject.Infrastructure.Data.SeedData
{
    public static class UserSeedData
    {
        public static async Task SeedAdminUserAsync(UserManager<ApplicationUser> userManager)
        {
            var adminEmail = "admin@system.com";

            var admin = await userManager.FindByEmailAsync(adminEmail);

            if (admin == null)
            {
                admin = new ApplicationUser
                {
                    UserName = "Admin",
                    Email = adminEmail,
                    EmailConfirmed = true,

                    FirstName = "admin",
                    LastName = "admin"

                };

                // Create Admin
                await userManager.CreateAsync(admin, "Admin@1234");


                // Give him the Role
                await userManager.AddToRoleAsync(admin, "Admin");
            }
        }

    }
}
