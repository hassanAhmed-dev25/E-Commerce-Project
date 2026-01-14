using Microsoft.AspNetCore.Identity;

namespace ECommerceProject.Infrastructure.Data.SeedData
{
    public static class RoleSeedData
    {
        public static void SeedRoleData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(

                new IdentityRole
                {
                    Id = "1",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "2",
                    Name = "Seller",
                    NormalizedName = "SELLER"
                },
                new IdentityRole
                {
                    Id = "3",
                    Name = "Buyer",
                    NormalizedName = "BUYER"
                }
            );
        }
    }
}
