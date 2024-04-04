using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class newdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "561f29eb-1b31-4c74-99cf-e18ceb2b4f12");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd01d469-37a2-43e0-9cd0-4b9befcde984");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4b8c84f3-8865-449a-87d2-d4d6255640b0", "b4dd0a24-bb2e-4055-bfa4-871ce627495c", "Customer", "CUSTOMER" },
                    { "98d72152-b655-4106-8172-908db88bb979", "433720ba-4c96-4aff-991f-555fb2114396", "Saller", "SALLER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b8c84f3-8865-449a-87d2-d4d6255640b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98d72152-b655-4106-8172-908db88bb979");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "561f29eb-1b31-4c74-99cf-e18ceb2b4f12", "af1927d9-bf2b-4ad2-8c80-b9c9074c286b", "Customer", "CUSTOMER" },
                    { "fd01d469-37a2-43e0-9cd0-4b9befcde984", "b89aaf00-86ec-43a2-85f8-142d90b44514", "Saller", "SALLER" }
                });
        }
    }
}
