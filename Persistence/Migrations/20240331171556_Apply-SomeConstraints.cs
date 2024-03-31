using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ApplySomeConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "EmailValidation1",
                table: "Sallers");

            migrationBuilder.DropCheckConstraint(
                name: "AddingDateValidation",
                table: "Products");

            migrationBuilder.DropCheckConstraint(
                name: "EmailValidation",
                table: "Customers");

            migrationBuilder.AddCheckConstraint(
                name: "EmailValidation1",
                table: "Sallers",
                sql: "[Email] like '%[a-zA-Z0-9.]@gmail.com' and [Email] not like '%[-+/*]%'");

            migrationBuilder.AddCheckConstraint(
                name: "EmailValidation",
                table: "Customers",
                sql: "[Email] like '%[a-zA-Z0-9.]@gmail.com' and [Email] not like '%[-+/*]%'");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "EmailValidation1",
                table: "Sallers");

            migrationBuilder.DropCheckConstraint(
                name: "EmailValidation",
                table: "Customers");

            migrationBuilder.AddCheckConstraint(
                name: "EmailValidation1",
                table: "Sallers",
                sql: "[Email] like '%[a-zA-Z0-9.]@__%.__%' and [Email] not like '%[-+/*]%'");

            migrationBuilder.AddCheckConstraint(
                name: "AddingDateValidation",
                table: "Products",
                sql: "DATEPART(YEAR, [AddingDate]) >= DATEPART(YEAR, GETDATE()) and DATEPART(MONTH, [AddingDate]) >= DATEPART(MONTH, GETDATE()) and DATEPART(DAY, [AddingDate]) >= DATEPART(DAY, GETDATE())");

            migrationBuilder.AddCheckConstraint(
                name: "EmailValidation",
                table: "Customers",
                sql: "[Email] like '%[a-zA-Z0-9.]@__%.__%' and [Email] not like '%[-+/*]%'");
        }
    }
}
