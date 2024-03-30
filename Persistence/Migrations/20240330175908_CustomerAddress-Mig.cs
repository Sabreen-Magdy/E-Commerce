using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CustomerAddressMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropCheckConstraint(
            //    name: "AddingDateValidation",
            //    table: "Products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderedDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Customers",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            //migrationBuilder.AddCheckConstraint(
            //    name: "AddingDateValidation",
            //    table: "Products",
            //    sql: "DATEPART(YEAR, [AddingDate]) >= DATEPART(YEAR, GETDATE()) and DATEPART(MONTH, [AddingDate]) >= DATEPART(MONTH, GETDATE()) and DATEPART(DAY, [AddingDate]) >= DATEPART(DAY, GETDATE())");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropCheckConstraint(
            //    name: "AddingDateValidation",
            //    table: "Products");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Customers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderedDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GetDate()");

            //migrationBuilder.AddCheckConstraint(
            //    name: "AddingDateValidation",
            //    table: "Products",
            //    sql: "DATEPART(YEAR, [AddingDate]) >= DATEPART(YEAR, GETDATE()) and DATEPART(MONTH, [AddingDate]) >= DATEPART(MONTH, GETDATE()) and DATEPART(DAY, [AddingDate]) >= DATEPART(DAY, GETDATE()) ");
        }
    }
}
