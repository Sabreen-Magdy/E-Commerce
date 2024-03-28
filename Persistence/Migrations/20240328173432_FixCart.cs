using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cartItems_Carts_CartId",
                table: "cartItems");

            migrationBuilder.DropTable(
                name: "CartProductVarient");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "cartItems",
                newName: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_cartItems_Customers_CustomerId",
                table: "cartItems",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cartItems_Customers_CustomerId",
                table: "cartItems");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "cartItems",
                newName: "CartId");

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartProductVarient",
                columns: table => new
                {
                    CartsId = table.Column<int>(type: "int", nullable: false),
                    ProductVarientsProductId = table.Column<int>(type: "int", nullable: false),
                    ProductVarientsSizeId = table.Column<int>(type: "int", nullable: false),
                    ProductVarientsColorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProductVarient", x => new { x.CartsId, x.ProductVarientsProductId, x.ProductVarientsSizeId, x.ProductVarientsColorId });
                    table.ForeignKey(
                        name: "FK_CartProductVarient_Carts_CartsId",
                        column: x => x.CartsId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartProductVarient_ProductVarients_ProductVarientsProductId_ProductVarientsSizeId_ProductVarientsColorId",
                        columns: x => new { x.ProductVarientsProductId, x.ProductVarientsSizeId, x.ProductVarientsColorId },
                        principalTable: "ProductVarients",
                        principalColumns: new[] { "ProductId", "SizeId", "ColorId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartProductVarient_ProductVarientsProductId_ProductVarientsSizeId_ProductVarientsColorId",
                table: "CartProductVarient",
                columns: new[] { "ProductVarientsProductId", "ProductVarientsSizeId", "ProductVarientsColorId" });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CustomerId",
                table: "Carts",
                column: "CustomerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_cartItems_Carts_CartId",
                table: "cartItems",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
