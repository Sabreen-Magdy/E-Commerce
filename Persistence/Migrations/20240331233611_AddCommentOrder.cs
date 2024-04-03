using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddCommentOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "يُرجى الانتظار بينما يقوم البائع بمراجعة طلبك واتخاذ قرار بشأن قبوله أو رفض");

            migrationBuilder.AddCheckConstraint(
                name: "StateValidation",
                table: "Orders",
                sql: "[State] >= 0 and [State] <= 3");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "StateValidation",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Orders");
        }
    }
}
