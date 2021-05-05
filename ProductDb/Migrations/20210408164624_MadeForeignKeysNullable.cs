using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductDb.Migrations
{
    public partial class MadeForeignKeysNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                schema: "Prd",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Types_ProductTypeId",
                schema: "Prd",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "ProductTypeId",
                schema: "Prd",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                schema: "Prd",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                schema: "Prd",
                table: "Products",
                column: "CategoryId",
                principalSchema: "Prd",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Types_ProductTypeId",
                schema: "Prd",
                table: "Products",
                column: "ProductTypeId",
                principalSchema: "Prd",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                schema: "Prd",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Types_ProductTypeId",
                schema: "Prd",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "ProductTypeId",
                schema: "Prd",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                schema: "Prd",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                schema: "Prd",
                table: "Products",
                column: "CategoryId",
                principalSchema: "Prd",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Types_ProductTypeId",
                schema: "Prd",
                table: "Products",
                column: "ProductTypeId",
                principalSchema: "Prd",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
