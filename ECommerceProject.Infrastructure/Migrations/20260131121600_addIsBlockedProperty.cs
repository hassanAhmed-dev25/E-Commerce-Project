using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addIsBlockedProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBlocked",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 31, 12, 15, 56, 603, DateTimeKind.Utc).AddTicks(4342));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 31, 12, 15, 56, 603, DateTimeKind.Utc).AddTicks(4346));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 31, 12, 15, 56, 603, DateTimeKind.Utc).AddTicks(4348));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 31, 12, 15, 56, 603, DateTimeKind.Utc).AddTicks(4350));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 31, 12, 15, 56, 603, DateTimeKind.Utc).AddTicks(4351));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 31, 12, 15, 56, 603, DateTimeKind.Utc).AddTicks(4353));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 31, 12, 15, 56, 603, DateTimeKind.Utc).AddTicks(4355));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 31, 12, 15, 56, 603, DateTimeKind.Utc).AddTicks(4356));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBlocked",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 24, 9, 30, 26, 136, DateTimeKind.Utc).AddTicks(4149));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 24, 9, 30, 26, 136, DateTimeKind.Utc).AddTicks(4156));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 24, 9, 30, 26, 136, DateTimeKind.Utc).AddTicks(4157));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 24, 9, 30, 26, 136, DateTimeKind.Utc).AddTicks(4157));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 24, 9, 30, 26, 136, DateTimeKind.Utc).AddTicks(4158));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 24, 9, 30, 26, 136, DateTimeKind.Utc).AddTicks(4159));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 24, 9, 30, 26, 136, DateTimeKind.Utc).AddTicks(4159));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 24, 9, 30, 26, 136, DateTimeKind.Utc).AddTicks(4160));
        }
    }
}
