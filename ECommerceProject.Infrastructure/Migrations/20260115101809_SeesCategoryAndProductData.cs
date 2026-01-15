using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerceProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeesCategoryAndProductData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Description", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 15, 10, 18, 5, 747, DateTimeKind.Utc).AddTicks(7965), null, "Electronics" },
                    { 2, new DateTime(2026, 1, 15, 10, 18, 5, 747, DateTimeKind.Utc).AddTicks(7967), null, "Mobile Phones" },
                    { 3, new DateTime(2026, 1, 15, 10, 18, 5, 747, DateTimeKind.Utc).AddTicks(7968), null, "Laptops" },
                    { 4, new DateTime(2026, 1, 15, 10, 18, 5, 747, DateTimeKind.Utc).AddTicks(7969), null, "Clothing" },
                    { 5, new DateTime(2026, 1, 15, 10, 18, 5, 747, DateTimeKind.Utc).AddTicks(7969), null, "Shoes" },
                    { 6, new DateTime(2026, 1, 15, 10, 18, 5, 747, DateTimeKind.Utc).AddTicks(7970), null, "Home Appliances" },
                    { 7, new DateTime(2026, 1, 15, 10, 18, 5, 747, DateTimeKind.Utc).AddTicks(7971), null, "Books" },
                    { 8, new DateTime(2026, 1, 15, 10, 18, 5, 747, DateTimeKind.Utc).AddTicks(7971), null, "Gaming" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "CreatedBy", "Description", "ImageUrl", "IsActive", "Name", "Price", "StockQuantity" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Apple iPhone 14 with A15 Bionic chip", null, true, "iPhone 14", 30000m, 15 },
                    { 2, 1, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Samsung flagship smartphone with high performance", null, true, "Samsung Galaxy S23", 28000m, 20 },
                    { 3, 1, new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Affordable smartphone with great features", null, true, "Xiaomi Redmi Note 12", 12000m, 30 },
                    { 4, 3, new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "High-end laptop for professionals", null, true, "Dell XPS 15", 45000m, 8 },
                    { 5, 3, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Reliable laptop for everyday use", null, true, "HP Pavilion 15", 32000m, 10 },
                    { 6, 3, new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Business-class laptop with premium build", null, true, "Lenovo ThinkPad X1", 50000m, 6 },
                    { 7, 4, new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Comfortable cotton t-shirt", null, true, "Cotton T-Shirt", 500m, 50 },
                    { 8, 4, new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Stylish slim fit jeans", null, true, "Slim Fit Jeans", 900m, 40 },
                    { 9, 4, new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Warm jacket for winter season", null, true, "Winter Jacket", 1800m, 25 },
                    { 10, 5, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Comfortable running shoes from Nike", null, true, "Nike Air Max", 3500m, 18 },
                    { 11, 5, new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "High performance running shoes", null, true, "Adidas Ultraboost", 4000m, 12 },
                    { 12, 5, new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lightweight shoes for daily training", null, true, "Puma Running Shoes", 2800m, 20 },
                    { 13, 6, new DateTime(2024, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Modern microwave oven with multiple modes", null, true, "Microwave Oven", 6000m, 10 },
                    { 14, 6, new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Large capacity refrigerator", null, true, "Refrigerator", 15000m, 5 },
                    { 15, 6, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Automatic washing machine", null, true, "Washing Machine", 13000m, 7 },
                    { 16, 7, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Handbook of Agile Software Craftsmanship", null, true, "Clean Code", 600m, 35 },
                    { 17, 7, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Elements of Reusable Object-Oriented Software", null, true, "Design Patterns", 750m, 25 },
                    { 18, 8, new DateTime(2024, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "High precision gaming mouse", null, true, "Gaming Mouse", 1200m, 30 },
                    { 19, 8, new DateTime(2024, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mechanical keyboard with RGB lighting", null, true, "Mechanical Keyboard", 2500m, 22 },
                    { 20, 8, new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Surround sound gaming headset", null, true, "Gaming Headset", 2200m, 28 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "Admin", "ADMIN" },
                    { "2", null, "Seller", "SELLER" },
                    { "3", null, "Buyer", "BUYER" }
                });
        }
    }
}
