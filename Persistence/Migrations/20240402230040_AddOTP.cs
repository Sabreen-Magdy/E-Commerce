using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddOTP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sallers_AspNetUsers_UserId",
                table: "Sallers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79e00796-15de-4128-9189-674e2f7e081d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8ec05da-3673-4b69-917c-bf6b29fc16f3");

            migrationBuilder.AddColumn<string>(
                name: "OTP",
                table: "AspNetUsers",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "561f29eb-1b31-4c74-99cf-e18ceb2b4f12", "af1927d9-bf2b-4ad2-8c80-b9c9074c286b", "Customer", "CUSTOMER" },
                    { "fd01d469-37a2-43e0-9cd0-4b9befcde984", "b89aaf00-86ec-43a2-85f8-142d90b44514", "Saller", "SALLER" }
                });

            migrationBuilder.AddCheckConstraint(
                name: "OTPValidation",
                table: "AspNetUsers",
                sql: "len([OTP]) = 6");

            migrationBuilder.AddForeignKey(
                name: "FK_Sallers_AspNetUsers_UserId",
                table: "Sallers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sallers_AspNetUsers_UserId",
                table: "Sallers");

            migrationBuilder.DropCheckConstraint(
                name: "OTPValidation",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "561f29eb-1b31-4c74-99cf-e18ceb2b4f12");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd01d469-37a2-43e0-9cd0-4b9befcde984");

            migrationBuilder.DropColumn(
                name: "OTP",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "79e00796-15de-4128-9189-674e2f7e081d", "655c4a83-5b85-413d-9e9c-9d1138a9e145", "Customer", "CUSTOMER" },
                    { "b8ec05da-3673-4b69-917c-bf6b29fc16f3", "7fdfe910-aca7-4a18-bea8-c272107d137b", "Saller", "SALLER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Sallers_AspNetUsers_UserId",
                table: "Sallers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
