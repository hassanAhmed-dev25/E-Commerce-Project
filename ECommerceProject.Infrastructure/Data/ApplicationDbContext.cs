using ECommerceProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceProject.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply configurations from current assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);



        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }


    }
}
