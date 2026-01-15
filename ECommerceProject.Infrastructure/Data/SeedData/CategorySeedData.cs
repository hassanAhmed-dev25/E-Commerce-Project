namespace ECommerceProject.Infrastructure.Data.SeedData
{
    public static class CategorySeedData
    {
        public static void SeedCategoryData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Mobile Phones" },
                new Category { Id = 3, Name = "Laptops" },
                new Category { Id = 4, Name = "Clothing" },
                new Category { Id = 5, Name = "Shoes" },
                new Category { Id = 6, Name = "Home Appliances" },
                new Category { Id = 7, Name = "Books" },
                new Category { Id = 8, Name = "Gaming" }
            );
        }
    }
}
