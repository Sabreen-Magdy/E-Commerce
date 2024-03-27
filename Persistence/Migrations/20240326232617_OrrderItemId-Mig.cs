using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class OrrderItemIdMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "AddingDateValidation",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductVarients");
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProductVarients",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductVarientBelongToOrder");
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProductVarientBelongToOrder",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.DropColumn(
               name: "Id",
               table: "ProductCategories");
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProductCategories",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");
            
            migrationBuilder.DropColumn(
             name: "Id",
             table: "ColoredProducts");
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ColoredProducts",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProductVarients_ProductId",
            //    table: "ProductVarients",
            //    column: "ProductId",
            //    unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductVarientBelongToOrder_Id",
                table: "ProductVarientBelongToOrder",
                column: "Id",
                unique: true);

            migrationBuilder.AddCheckConstraint(
                name: "AddingDateValidation",
                table: "Products",
                sql: "DATEPART(YEAR, [AddingDate]) >= DATEPART(YEAR, GETDATE()) and DATEPART(MONTH, [AddingDate]) >= DATEPART(MONTH, GETDATE()) and DATEPART(DAY, [AddingDate]) >= DATEPART(DAY, GETDATE()) ");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProductCategories_ProductId",
            //    table: "ProductCategories",
            //    column: "ProductId",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_ColoredProducts_ProductId",
            //    table: "ColoredProducts",
            //    column: "ProductId",
            //    unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropIndex(
            //    name: "IX_ProductVarients_ProductId",
            //    table: "ProductVarients");

            migrationBuilder.DropIndex(
                name: "IX_ProductVarientBelongToOrder_Id",
                table: "ProductVarientBelongToOrder");

            migrationBuilder.DropCheckConstraint(
                name: "AddingDateValidation",
                table: "Products");

            //migrationBuilder.DropIndex(
            //    name: "IX_ProductCategories_ProductId",
            //    table: "ProductCategories");

            //migrationBuilder.DropIndex(
            //    name: "IX_ColoredProducts_ProductId",
            //    table: "ColoredProducts");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ProductVarients",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ProductVarientBelongToOrder",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ProductCategories",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ColoredProducts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddCheckConstraint(
                name: "AddingDateValidation",
                table: "Products",
                sql: "[AddingDate] >= GetDate()");
        }
    }
}
