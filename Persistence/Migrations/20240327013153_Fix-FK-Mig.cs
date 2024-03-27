using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixFKMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cartItems_ProductVarients_ProductId_SizeId_ColorId",
                table: "cartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CartProductVarient_ProductVarients_ProductVarientsProductId_ProductVarientsColorId_ProductVarientsSizeId",
                table: "CartProductVarient");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductVarientBelongToOrder_ProductVarients_ProductId_SizeId_ColorId",
                table: "ProductVarientBelongToOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductVarients",
                table: "ProductVarients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartProductVarient",
                table: "CartProductVarient");

            migrationBuilder.DropIndex(
                name: "IX_CartProductVarient_ProductVarientsProductId_ProductVarientsColorId_ProductVarientsSizeId",
                table: "CartProductVarient");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                columns: new[] { "ProductId", "CustomerId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductVarients",
                table: "ProductVarients",
                columns: new[] { "ProductId", "SizeId", "ColorId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartProductVarient",
                table: "CartProductVarient",
                columns: new[] { "CartsId", "ProductVarientsProductId", "ProductVarientsSizeId", "ProductVarientsColorId" });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CustomerId",
                table: "Reviews",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVarients_ProductId_ColorId",
                table: "ProductVarients",
                columns: new[] { "ProductId", "ColorId" });

            migrationBuilder.CreateIndex(
                name: "IX_CartProductVarient_ProductVarientsProductId_ProductVarientsSizeId_ProductVarientsColorId",
                table: "CartProductVarient",
                columns: new[] { "ProductVarientsProductId", "ProductVarientsSizeId", "ProductVarientsColorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_cartItems_ProductVarients_ProductId_SizeId_ColorId",
                table: "cartItems",
                columns: new[] { "ProductId", "SizeId", "ColorId" },
                principalTable: "ProductVarients",
                principalColumns: new[] { "ProductId", "SizeId", "ColorId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartProductVarient_ProductVarients_ProductVarientsProductId_ProductVarientsSizeId_ProductVarientsColorId",
                table: "CartProductVarient",
                columns: new[] { "ProductVarientsProductId", "ProductVarientsSizeId", "ProductVarientsColorId" },
                principalTable: "ProductVarients",
                principalColumns: new[] { "ProductId", "SizeId", "ColorId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVarientBelongToOrder_ProductVarients_ProductId_SizeId_ColorId",
                table: "ProductVarientBelongToOrder",
                columns: new[] { "ProductId", "SizeId", "ColorId" },
                principalTable: "ProductVarients",
                principalColumns: new[] { "ProductId", "SizeId", "ColorId" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cartItems_ProductVarients_ProductId_SizeId_ColorId",
                table: "cartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CartProductVarient_ProductVarients_ProductVarientsProductId_ProductVarientsSizeId_ProductVarientsColorId",
                table: "CartProductVarient");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductVarientBelongToOrder_ProductVarients_ProductId_SizeId_ColorId",
                table: "ProductVarientBelongToOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_CustomerId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductVarients",
                table: "ProductVarients");

            migrationBuilder.DropIndex(
                name: "IX_ProductVarients_ProductId_ColorId",
                table: "ProductVarients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartProductVarient",
                table: "CartProductVarient");

            migrationBuilder.DropIndex(
                name: "IX_CartProductVarient_ProductVarientsProductId_ProductVarientsSizeId_ProductVarientsColorId",
                table: "CartProductVarient");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                columns: new[] { "CustomerId", "ProductId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductVarients",
                table: "ProductVarients",
                columns: new[] { "ProductId", "ColorId", "SizeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartProductVarient",
                table: "CartProductVarient",
                columns: new[] { "CartsId", "ProductVarientsProductId", "ProductVarientsColorId", "ProductVarientsSizeId" });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CartProductVarient_ProductVarientsProductId_ProductVarientsColorId_ProductVarientsSizeId",
                table: "CartProductVarient",
                columns: new[] { "ProductVarientsProductId", "ProductVarientsColorId", "ProductVarientsSizeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_cartItems_ProductVarients_ProductId_SizeId_ColorId",
                table: "cartItems",
                columns: new[] { "ProductId", "SizeId", "ColorId" },
                principalTable: "ProductVarients",
                principalColumns: new[] { "ProductId", "ColorId", "SizeId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartProductVarient_ProductVarients_ProductVarientsProductId_ProductVarientsColorId_ProductVarientsSizeId",
                table: "CartProductVarient",
                columns: new[] { "ProductVarientsProductId", "ProductVarientsColorId", "ProductVarientsSizeId" },
                principalTable: "ProductVarients",
                principalColumns: new[] { "ProductId", "ColorId", "SizeId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVarientBelongToOrder_ProductVarients_ProductId_SizeId_ColorId",
                table: "ProductVarientBelongToOrder",
                columns: new[] { "ProductId", "SizeId", "ColorId" },
                principalTable: "ProductVarients",
                principalColumns: new[] { "ProductId", "ColorId", "SizeId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
