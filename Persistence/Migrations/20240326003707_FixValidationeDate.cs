using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixValidationeDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "AddingDateValidation",
                table: "Products");

            migrationBuilder.AddCheckConstraint(
                name: "AddingDateValidation",
                table: "Products",
                sql: "DATEPART(YEAR, [AddingDate]) >= DATEPART(YEAR, GETDATE()) and DATEPART(MONTH, [AddingDate]) >= DATEPART(MONTH, GETDATE()) and DATEPART(DAY, [AddingDate]) >= DATEPART(DAY, GETDATE()) ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "AddingDateValidation",
                table: "Products");

            migrationBuilder.AddCheckConstraint(
                name: "AddingDateValidation",
                table: "Products",
                sql: "[AddingDate] >= GetDate()");
        }
    }
}
