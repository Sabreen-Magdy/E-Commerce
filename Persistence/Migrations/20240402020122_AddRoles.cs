using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "43c9dd97-a954-41d8-8291-116ba4dc5bf8", "b431542a-7d3d-492f-ac2c-105993a2fcdb", "Customer", "CUSTOMER" },
                    { "7d856635-ab1d-4856-97da-263c4f6a6d7d", "77afa350-091c-4f94-9114-492b6ffd03fb", "Saller", "SALLER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43c9dd97-a954-41d8-8291-116ba4dc5bf8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d856635-ab1d-4856-97da-263c4f6a6d7d");
        }
    }
}
