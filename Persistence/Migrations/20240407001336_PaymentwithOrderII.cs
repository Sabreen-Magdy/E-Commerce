using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PaymentwithOrderII : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3929e358-4c15-4d0a-83be-7aba971ea16a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e551cb5-bc7d-4ed5-94a0-721bf2246149");

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "58638d21-23ab-45be-a10a-93e584a4ce8f", "2869b331-7441-4ba9-b032-4121149bf66f", "Saller", "SALLER" },
                    { "f5854f24-2acb-46a4-aae4-be39cb5c8233", "d9d882f6-7e2d-4b8f-b3a5-ca1d2b79029c", "Customer", "CUSTOMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58638d21-23ab-45be-a10a-93e584a4ce8f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5854f24-2acb-46a4-aae4-be39cb5c8233");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3929e358-4c15-4d0a-83be-7aba971ea16a", "cc5aca2b-11f4-4853-977e-c206b59e68b1", "Saller", "SALLER" },
                    { "5e551cb5-bc7d-4ed5-94a0-721bf2246149", "fc2a6563-672d-4f5c-b9a7-f813cd295c4a", "Customer", "CUSTOMER" }
                });
        }
    }
}
