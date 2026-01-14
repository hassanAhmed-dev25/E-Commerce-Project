using Microsoft.AspNetCore.Identity;

namespace ECommerceProject.Infrastructure.Data.SeedData
{
    public static class RoleSeedData
    {
        public static async Task SeedRoleDataAsync(RoleManager<IdentityRole> roleManager)
        {
            string[] roles =
            {

                "Admin",
                "Seller",
                "Buyer"
            };

            foreach (var roleName in roles)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    var role = new IdentityRole
                    {
                        Name = roleName,
                        NormalizedName = roleName.ToUpper()
                    };

                    await roleManager.CreateAsync(role);
                }
            }
        }
    }
}
