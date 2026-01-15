namespace ECommerceProject.Infrastructure.Data.SeedData
{
    public static class ProductSeedData
    {
        public static void SeedProductData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(

                 // Electronics
                 new Product
                 {
                     Id = 1,
                     Name = "iPhone 14",
                     Price = 30000,
                     StockQuantity = 15,
                     IsActive = true,
                     Description = "Apple iPhone 14 with A15 Bionic chip",
                     CreatedAt = new DateTime(2024, 1, 1),
                     //CreatedBy = "admin",
                     CategoryId = 1
                 },
                 new Product
                 {
                     Id = 2,
                     Name = "Samsung Galaxy S23",
                     Price = 28000,
                     StockQuantity = 20,
                     IsActive = true,
                     Description = "Samsung flagship smartphone with high performance",
                     CreatedAt = new DateTime(2024, 1, 2),
                     //CreatedBy = "admin",
                     CategoryId = 1
                 },
                 new Product
                 {
                     Id = 3,
                     Name = "Xiaomi Redmi Note 12",
                     Price = 12000,
                     StockQuantity = 30,
                     IsActive = true,
                     Description = "Affordable smartphone with great features",
                     CreatedAt = new DateTime(2024, 1, 3),
                     //CreatedBy = "admin",
                     CategoryId = 1
                 },

                 // Laptops
                 new Product
                 {
                     Id = 4,
                     Name = "Dell XPS 15",
                     Price = 45000,
                     StockQuantity = 8,
                     IsActive = true,
                     Description = "High-end laptop for professionals",
                     CreatedAt = new DateTime(2024, 1, 4),
                     //CreatedBy = "seller",
                     CategoryId = 3
                 },
                 new Product
                 {
                     Id = 5,
                     Name = "HP Pavilion 15",
                     Price = 32000,
                     StockQuantity = 10,
                     IsActive = true,
                     Description = "Reliable laptop for everyday use",
                     CreatedAt = new DateTime(2024, 1, 5),
                     //CreatedBy = "seller",
                     CategoryId = 3
                 },
                 new Product
                 {
                     Id = 6,
                     Name = "Lenovo ThinkPad X1",
                     Price = 50000,
                     StockQuantity = 6,
                     IsActive = true,
                     Description = "Business-class laptop with premium build",
                     CreatedAt = new DateTime(2024, 1, 6),
                     //CreatedBy = "seller",
                     CategoryId = 3
                 },

                 // Clothing
                 new Product
                 {
                     Id = 7,
                     Name = "Cotton T-Shirt",
                     Price = 500,
                     StockQuantity = 50,
                     IsActive = true,
                     Description = "Comfortable cotton t-shirt",
                     CreatedAt = new DateTime(2024, 1, 7),
                     //CreatedBy = "seller",
                     CategoryId = 4
                 },
                 new Product
                 {
                     Id = 8,
                     Name = "Slim Fit Jeans",
                     Price = 900,
                     StockQuantity = 40,
                     IsActive = true,
                     Description = "Stylish slim fit jeans",
                     CreatedAt = new DateTime(2024, 1, 8),
                     //CreatedBy = "seller",
                     CategoryId = 4
                 },
                 new Product
                 {
                     Id = 9,
                     Name = "Winter Jacket",
                     Price = 1800,
                     StockQuantity = 25,
                     IsActive = true,
                     Description = "Warm jacket for winter season",
                     CreatedAt = new DateTime(2024, 1, 9),
                     //CreatedBy = "seller",
                     CategoryId = 4
                 },

                 // Shoes
                 new Product
                 {
                     Id = 10,
                     Name = "Nike Air Max",
                     Price = 3500,
                     StockQuantity = 18,
                     IsActive = true,
                     Description = "Comfortable running shoes from Nike",
                     CreatedAt = new DateTime(2024, 1, 10),
                     //CreatedBy = "seller",
                     CategoryId = 5
                 },
                 new Product
                 {
                     Id = 11,
                     Name = "Adidas Ultraboost",
                     Price = 4000,
                     StockQuantity = 12,
                     IsActive = true,
                     Description = "High performance running shoes",
                     CreatedAt = new DateTime(2024, 1, 11),
                     //CreatedBy = "seller",
                     CategoryId = 5
                 },
                 new Product
                 {
                     Id = 12,
                     Name = "Puma Running Shoes",
                     Price = 2800,
                     StockQuantity = 20,
                     IsActive = true,
                     Description = "Lightweight shoes for daily training",
                     CreatedAt = new DateTime(2024, 1, 12),
                    //CreatedBy = "seller",
                     CategoryId = 5
                 },

                 // Home Appliances
                 new Product
                 {
                     Id = 13,
                     Name = "Microwave Oven",
                     Price = 6000,
                     StockQuantity = 10,
                     IsActive = true,
                     Description = "Modern microwave oven with multiple modes",
                     CreatedAt = new DateTime(2024, 1, 13),
                     //CreatedBy = "admin",
                     CategoryId = 6
                 },
                 new Product
                 {
                     Id = 14,
                     Name = "Refrigerator",
                     Price = 15000,
                     StockQuantity = 5,
                     IsActive = true,
                     Description = "Large capacity refrigerator",
                     CreatedAt = new DateTime(2024, 1, 14),
                     //CreatedBy = "admin",
                     CategoryId = 6
                 },
                 new Product
                 {
                     Id = 15,
                     Name = "Washing Machine",
                     Price = 13000,
                     StockQuantity = 7,
                     IsActive = true,
                     Description = "Automatic washing machine",
                     CreatedAt = new DateTime(2024, 1, 15),
                     //CreatedBy = "admin",
                     CategoryId = 6
                 },

                 // Books
                 new Product
                 {
                     Id = 16,
                     Name = "Clean Code",
                     Price = 600,
                     StockQuantity = 35,
                     IsActive = true,
                     Description = "A Handbook of Agile Software Craftsmanship",
                     CreatedAt = new DateTime(2024, 1, 16),
                     //CreatedBy = "admin",
                     CategoryId = 7
                 },
                 new Product
                 {
                     Id = 17,
                     Name = "Design Patterns",
                     Price = 750,
                     StockQuantity = 25,
                     IsActive = true,
                     Description = "Elements of Reusable Object-Oriented Software",
                     CreatedAt = new DateTime(2024, 1, 17),
                     //CreatedBy = "admin",
                     CategoryId = 7
                 },

                 // Gaming
                 new Product
                 {
                     Id = 18,
                     Name = "Gaming Mouse",
                     Price = 1200,
                     StockQuantity = 30,
                     IsActive = true,
                     Description = "High precision gaming mouse",
                     CreatedAt = new DateTime(2024, 1, 18),
                     //CreatedBy = "seller",
                     CategoryId = 8
                 },
                 new Product
                 {
                     Id = 19,
                     Name = "Mechanical Keyboard",
                     Price = 2500,
                     StockQuantity = 22,
                     IsActive = true,
                     Description = "Mechanical keyboard with RGB lighting",
                     CreatedAt = new DateTime(2024, 1, 19),
                     //CreatedBy = "seller",
                     CategoryId = 8
                 },
                 new Product
                 {
                     Id = 20,
                     Name = "Gaming Headset",
                     Price = 2200,
                     StockQuantity = 28,
                     IsActive = true,
                     Description = "Surround sound gaming headset",
                     CreatedAt = new DateTime(2024, 1, 20),
                     //CreatedBy = "seller",
                     CategoryId = 8
                 }
             );

        }

    }

}
