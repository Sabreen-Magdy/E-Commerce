using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class HandleUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_IdentityUserId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Sallers_AspNetUsers_IdentityUserId",
                table: "Sallers");

            migrationBuilder.DropIndex(
                name: "IX_Sallers_IdentityUserId",
                table: "Sallers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_IdentityUserId",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43c9dd97-a954-41d8-8291-116ba4dc5bf8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d856635-ab1d-4856-97da-263c4f6a6d7d");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Sallers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Sallers");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Sallers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "79e00796-15de-4128-9189-674e2f7e081d", "655c4a83-5b85-413d-9e9c-9d1138a9e145", "Customer", "CUSTOMER" },
                    { "b8ec05da-3673-4b69-917c-bf6b29fc16f3", "7fdfe910-aca7-4a18-bea8-c272107d137b", "Saller", "SALLER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sallers_UserId",
                table: "Sallers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_UserId",
                table: "Customers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sallers_AspNetUsers_UserId",
                table: "Sallers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_UserId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Sallers_AspNetUsers_UserId",
                table: "Sallers");

            migrationBuilder.DropIndex(
                name: "IX_Sallers_UserId",
                table: "Sallers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_UserId",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79e00796-15de-4128-9189-674e2f7e081d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8ec05da-3673-4b69-917c-bf6b29fc16f3");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Sallers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Sallers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Sallers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "m@S*n!S#");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Customers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "m@S*n!S#");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "43c9dd97-a954-41d8-8291-116ba4dc5bf8", "b431542a-7d3d-492f-ac2c-105993a2fcdb", "Customer", "CUSTOMER" },
                    { "7d856635-ab1d-4856-97da-263c4f6a6d7d", "77afa350-091c-4f94-9114-492b6ffd03fb", "Saller", "SALLER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sallers_IdentityUserId",
                table: "Sallers",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_IdentityUserId",
                table: "Customers",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_IdentityUserId",
                table: "Customers",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sallers_AspNetUsers_IdentityUserId",
                table: "Sallers",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
