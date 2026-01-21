using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceProject.Infrastructure.Data.SeedData
{
    public static class ProductSeedData
    {
        public static async Task SeedProductsAsync(IServiceProvider services)
        {
            var context = services.GetRequiredService<ApplicationDbContext>();
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

            if (context.Products.Any())
                return;

            var admin = await userManager.FindByEmailAsync("admin@system.com");

            var products = new List<Product>
            {
                 // Electronics
                 new Product
                 {
                     Name = "iPhone 14",
                     Price = 30000,
                     StockQuantity = 15,
                     IsActive = true,
                     Description = "Apple iPhone 14 with A15 Bionic chip",
                     CreatedAt = new DateTime(2024, 1, 1),
                     CreatedBy = admin.Id,
                     CategoryId = 1
                 },
                 new Product
                 {
                     Name = "Samsung Galaxy S23",
                     Price = 28000,
                     StockQuantity = 20,
                     IsActive = true,
                     Description = "Samsung flagship smartphone with high performance",
                     CreatedAt = new DateTime(2024, 1, 2),
                     CreatedBy = admin.Id,
                     CategoryId = 1
                 },
                 new Product
                 {
                     Name = "Xiaomi Redmi Note 12",
                     Price = 12000,
                     StockQuantity = 30,
                     IsActive = true,
                     Description = "Affordable smartphone with great features",
                     CreatedAt = new DateTime(2024, 1, 3),
                     CreatedBy = admin.Id,
                     CategoryId = 1
                 },

                 // Laptops
                 new Product
                 {
                     Name = "Dell XPS 15",
                     Price = 45000,
                     StockQuantity = 8,
                     IsActive = true,
                     Description = "High-end laptop for professionals",
                     CreatedAt = new DateTime(2024, 1, 4),
                     CreatedBy = admin.Id,
                     CategoryId = 3
                 },
                 new Product
                 {
                     Name = "HP Pavilion 15",
                     Price = 32000,
                     StockQuantity = 10,
                     IsActive = true,
                     Description = "Reliable laptop for everyday use",
                     CreatedAt = new DateTime(2024, 1, 5),
                     CreatedBy = admin.Id,
                     CategoryId = 3
                 },
                 new Product
                 {
                     Name = "Lenovo ThinkPad X1",
                     Price = 50000,
                     StockQuantity = 6,
                     IsActive = true,
                     Description = "Business-class laptop with premium build",
                     CreatedAt = new DateTime(2024, 1, 6),
                     CreatedBy = admin.Id,
                     CategoryId = 3
                 },

                 // Clothing
                 new Product
                 {
                     Name = "Cotton T-Shirt",
                     Price = 500,
                     StockQuantity = 50,
                     IsActive = true,
                     Description = "Comfortable cotton t-shirt",
                     CreatedAt = new DateTime(2024, 1, 7),
                     CreatedBy = admin.Id,
                     CategoryId = 4
                 },
                 new Product
                 {
                     Name = "Slim Fit Jeans",
                     Price = 900,
                     StockQuantity = 40,
                     IsActive = true,
                     Description = "Stylish slim fit jeans",
                     CreatedAt = new DateTime(2024, 1, 8),
                     CreatedBy = admin.Id,
                     CategoryId = 4
                 },
                 new Product
                 {
                     Name = "Winter Jacket",
                     Price = 1800,
                     StockQuantity = 25,
                     IsActive = true,
                     Description = "Warm jacket for winter season",
                     CreatedAt = new DateTime(2024, 1, 9),
                     CreatedBy = admin.Id,
                     CategoryId = 4
                 },

                 // Shoes
                 new Product
                 {
                     Name = "Nike Air Max",
                     Price = 3500,
                     StockQuantity = 18,
                     IsActive = true,
                     Description = "Comfortable running shoes from Nike",
                     CreatedAt = new DateTime(2024, 1, 10),
                     CreatedBy = admin.Id,
                     CategoryId = 5
                 },
                 new Product
                 {
                     Name = "Adidas Ultraboost",
                     Price = 4000,
                     StockQuantity = 12,
                     IsActive = true,
                     Description = "High performance running shoes",
                     CreatedAt = new DateTime(2024, 1, 11),
                     CreatedBy = admin.Id,
                     CategoryId = 5
                 },
                 new Product
                 {
                     Name = "Puma Running Shoes",
                     Price = 2800,
                     StockQuantity = 20,
                     IsActive = true,
                     Description = "Lightweight shoes for daily training",
                     CreatedAt = new DateTime(2024, 1, 12),
                    CreatedBy = admin.Id,
                     CategoryId = 5
                 },

                 // Home Appliances
                 new Product
                 {
                     Name = "Microwave Oven",
                     Price = 6000,
                     StockQuantity = 10,
                     IsActive = true,
                     Description = "Modern microwave oven with multiple modes",
                     CreatedAt = new DateTime(2024, 1, 13),
                     CreatedBy = admin.Id,
                     CategoryId = 6
                 },
                 new Product
                 {
                     Name = "Refrigerator",
                     Price = 15000,
                     StockQuantity = 5,
                     IsActive = true,
                     Description = "Large capacity refrigerator",
                     CreatedAt = new DateTime(2024, 1, 14),
                     CreatedBy = admin.Id,
                     CategoryId = 6
                 },
                 new Product
                 {
                     Name = "Washing Machine",
                     Price = 13000,
                     StockQuantity = 7,
                     IsActive = true,
                     Description = "Automatic washing machine",
                     CreatedAt = new DateTime(2024, 1, 15),
                     CreatedBy = admin.Id,
                     CategoryId = 6
                 },

                 // Books
                 new Product
                 {
                     Name = "Clean Code",
                     Price = 600,
                     StockQuantity = 35,
                     IsActive = true,
                     Description = "A Handbook of Agile Software Craftsmanship",
                     CreatedAt = new DateTime(2024, 1, 16),
                     CreatedBy = admin.Id,
                     CategoryId = 7
                 },
                 new Product
                 {
                     Name = "Design Patterns",
                     Price = 750,
                     StockQuantity = 25,
                     IsActive = true,
                     Description = "Elements of Reusable Object-Oriented Software",
                     CreatedAt = new DateTime(2024, 1, 17),
                     CreatedBy = admin.Id,
                     CategoryId = 7
                 },

                 // Gaming
                 new Product
                 {
                     Name = "Gaming Mouse",
                     Price = 1200,
                     StockQuantity = 30,
                     IsActive = true,
                     Description = "High precision gaming mouse",
                     CreatedAt = new DateTime(2024, 1, 18),
                     CreatedBy = admin.Id,
                     CategoryId = 8
                 },
                 new Product
                 {
                     Name = "Mechanical Keyboard",
                     Price = 2500,
                     StockQuantity = 22,
                     IsActive = true,
                     Description = "Mechanical keyboard with RGB lighting",
                     CreatedAt = new DateTime(2024, 1, 19),
                     CreatedBy = admin.Id,
                     CategoryId = 8
                 },
                 new Product
                 {
                     Name = "Gaming Headset",
                     Price = 2200,
                     StockQuantity = 28,
                     IsActive = true,
                     Description = "Surround sound gaming headset",
                     CreatedAt = new DateTime(2024, 1, 20),
                     CreatedBy = admin.Id,
                     CategoryId = 8
                 }
            };

            context.Products.AddRange(products);
            await context.SaveChangesAsync();
        }
    }

}
