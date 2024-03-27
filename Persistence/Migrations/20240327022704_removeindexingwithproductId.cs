using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class removeindexingwithproductId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductVarients_ProductId",
                table: "ProductVarients");

            migrationBuilder.DropIndex(
                name: "IX_ColoredProducts_ProductId",
                table: "ColoredProducts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProductVarients_ProductId",
                table: "ProductVarients",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ColoredProducts_ProductId",
                table: "ColoredProducts",
                column: "ProductId",
                unique: true);
        }
    }
}
