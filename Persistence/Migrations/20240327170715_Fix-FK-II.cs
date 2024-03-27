using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixFKII : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "cartItems");
            migrationBuilder.AddColumn<int>(
              name: "Id",
              table: "cartItems",
              type: "int",
              nullable: false)
              .Annotation("SqlServer:Identity", "1, 1");
            migrationBuilder.CreateIndex(
                name: "IX_cartItems_Id",
                table: "cartItems",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_cartItems_Id",
                table: "cartItems");
        }
    }
}
