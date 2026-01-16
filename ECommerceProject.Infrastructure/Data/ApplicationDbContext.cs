using ECommerceProject.Infrastructure.Data.SeedData;
using ECommerceProject.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace ECommerceProject.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply configurations from current assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);



            // Seeding Data
            modelBuilder.SeedCategoryData();
            modelBuilder.SeedProductData();


        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }



    }
}
