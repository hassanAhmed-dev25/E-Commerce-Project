using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditSellerIdCoulumnFronIntToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SellerId",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 16, 3, 45, 940, DateTimeKind.Utc).AddTicks(2414));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 16, 3, 45, 940, DateTimeKind.Utc).AddTicks(2416));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 16, 3, 45, 940, DateTimeKind.Utc).AddTicks(2417));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 16, 3, 45, 940, DateTimeKind.Utc).AddTicks(2418));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 16, 3, 45, 940, DateTimeKind.Utc).AddTicks(2419));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 16, 3, 45, 940, DateTimeKind.Utc).AddTicks(2420));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 16, 3, 45, 940, DateTimeKind.Utc).AddTicks(2421));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 16, 3, 45, 940, DateTimeKind.Utc).AddTicks(2421));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SellerId",
                table: "OrderItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 18, 23, 25, 41, 821, DateTimeKind.Utc).AddTicks(7714));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 18, 23, 25, 41, 821, DateTimeKind.Utc).AddTicks(7718));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 18, 23, 25, 41, 821, DateTimeKind.Utc).AddTicks(7719));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 18, 23, 25, 41, 821, DateTimeKind.Utc).AddTicks(7720));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 18, 23, 25, 41, 821, DateTimeKind.Utc).AddTicks(7720));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 18, 23, 25, 41, 821, DateTimeKind.Utc).AddTicks(7721));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 18, 23, 25, 41, 821, DateTimeKind.Utc).AddTicks(7722));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 18, 23, 25, 41, 821, DateTimeKind.Utc).AddTicks(7723));
        }
    }
}
