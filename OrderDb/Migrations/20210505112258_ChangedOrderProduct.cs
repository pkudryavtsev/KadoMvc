using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderDb.Migrations
{
    public partial class ChangedOrderProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_OrderItems_OrderItemId",
                schema: "Ords",
                table: "OrderProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderProduct",
                schema: "Ords",
                table: "OrderProduct");

            migrationBuilder.RenameTable(
                name: "OrderProduct",
                schema: "Ords",
                newName: "OrderProducts",
                newSchema: "Ords");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProduct_OrderItemId",
                schema: "Ords",
                table: "OrderProducts",
                newName: "IX_OrderProducts_OrderItemId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "Ords",
                table: "OrderProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                schema: "Ords",
                table: "OrderProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderProducts",
                schema: "Ords",
                table: "OrderProducts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_OrderItems_OrderItemId",
                schema: "Ords",
                table: "OrderProducts",
                column: "OrderItemId",
                principalSchema: "Ords",
                principalTable: "OrderItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_OrderItems_OrderItemId",
                schema: "Ords",
                table: "OrderProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderProducts",
                schema: "Ords",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "Ords",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "PictureUrl",
                schema: "Ords",
                table: "OrderProducts");

            migrationBuilder.RenameTable(
                name: "OrderProducts",
                schema: "Ords",
                newName: "OrderProduct",
                newSchema: "Ords");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProducts_OrderItemId",
                schema: "Ords",
                table: "OrderProduct",
                newName: "IX_OrderProduct_OrderItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderProduct",
                schema: "Ords",
                table: "OrderProduct",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_OrderItems_OrderItemId",
                schema: "Ords",
                table: "OrderProduct",
                column: "OrderItemId",
                principalSchema: "Ords",
                principalTable: "OrderItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
