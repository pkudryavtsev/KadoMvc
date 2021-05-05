using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderDb.Migrations
{
    public partial class ChangeOrderItemStructureToOrderProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderBox_BoxName",
                schema: "Ords",
                table: "OrderItems");

            migrationBuilder.RenameColumn(
                name: "OrderBox_BoxId",
                schema: "Ords",
                table: "OrderItems",
                newName: "BoxId");

            migrationBuilder.AlterColumn<int>(
                name: "BoxId",
                schema: "Ords",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                schema: "Ords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderItemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderProduct_OrderItems_OrderItemId",
                        column: x => x.OrderItemId,
                        principalSchema: "Ords",
                        principalTable: "OrderItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_OrderItemId",
                schema: "Ords",
                table: "OrderProduct",
                column: "OrderItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProduct",
                schema: "Ords");

            migrationBuilder.RenameColumn(
                name: "BoxId",
                schema: "Ords",
                table: "OrderItems",
                newName: "OrderBox_BoxId");

            migrationBuilder.AlterColumn<int>(
                name: "OrderBox_BoxId",
                schema: "Ords",
                table: "OrderItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "OrderBox_BoxName",
                schema: "Ords",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
