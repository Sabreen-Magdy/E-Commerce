using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PaymentwithOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "561f29eb-1b31-4c74-99cf-e18ceb2b4f12");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd01d469-37a2-43e0-9cd0-4b9befcde984");

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayedTransactionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefundTransactionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nonce = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PayedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrencyIsoCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3929e358-4c15-4d0a-83be-7aba971ea16a", "cc5aca2b-11f4-4853-977e-c206b59e68b1", "Saller", "SALLER" },
                    { "5e551cb5-bc7d-4ed5-94a0-721bf2246149", "fc2a6563-672d-4f5c-b9a7-f813cd295c4a", "Customer", "CUSTOMER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payment_OrderId",
                table: "Payment",
                column: "OrderId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3929e358-4c15-4d0a-83be-7aba971ea16a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e551cb5-bc7d-4ed5-94a0-721bf2246149");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "561f29eb-1b31-4c74-99cf-e18ceb2b4f12", "af1927d9-bf2b-4ad2-8c80-b9c9074c286b", "Customer", "CUSTOMER" },
                    { "fd01d469-37a2-43e0-9cd0-4b9befcde984", "b89aaf00-86ec-43a2-85f8-142d90b44514", "Saller", "SALLER" }
                });
        }
    }
}
