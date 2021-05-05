using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderDb.Migrations
{
    public partial class AddedBoxNameToOrderItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BoxName",
                schema: "Ords",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoxName",
                schema: "Ords",
                table: "OrderItems");
        }
    }
}
