using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Carts_CartId",
                table: "CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_ProductVarients_ProductId_SizeId_ColorId",
                table: "CartItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartItem",
                table: "CartItem");

            migrationBuilder.RenameTable(
                name: "CartItem",
                newName: "cartItems");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_ProductId_SizeId_ColorId",
                table: "cartItems",
                newName: "IX_cartItems_ProductId_SizeId_ColorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cartItems",
                table: "cartItems",
                columns: new[] { "CartId", "ProductId", "SizeId", "ColorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_cartItems_Carts_CartId",
                table: "cartItems",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cartItems_ProductVarients_ProductId_SizeId_ColorId",
                table: "cartItems",
                columns: new[] { "ProductId", "SizeId", "ColorId" },
                principalTable: "ProductVarients",
                principalColumns: new[] { "ProductId", "ColorId", "SizeId" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cartItems_Carts_CartId",
                table: "cartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_cartItems_ProductVarients_ProductId_SizeId_ColorId",
                table: "cartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cartItems",
                table: "cartItems");

            migrationBuilder.RenameTable(
                name: "cartItems",
                newName: "CartItem");

            migrationBuilder.RenameIndex(
                name: "IX_cartItems_ProductId_SizeId_ColorId",
                table: "CartItem",
                newName: "IX_CartItem_ProductId_SizeId_ColorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartItem",
                table: "CartItem",
                columns: new[] { "CartId", "ProductId", "SizeId", "ColorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Carts_CartId",
                table: "CartItem",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_ProductVarients_ProductId_SizeId_ColorId",
                table: "CartItem",
                columns: new[] { "ProductId", "SizeId", "ColorId" },
                principalTable: "ProductVarients",
                principalColumns: new[] { "ProductId", "ColorId", "SizeId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
