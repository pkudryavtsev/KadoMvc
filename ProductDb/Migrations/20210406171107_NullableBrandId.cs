using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductDb.Migrations
{
    public partial class NullableBrandId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_ProductBrandId",
                schema: "Prd",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "ProductBrandId",
                schema: "Prd",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_ProductBrandId",
                schema: "Prd",
                table: "Products",
                column: "ProductBrandId",
                principalSchema: "Prd",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_ProductBrandId",
                schema: "Prd",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "ProductBrandId",
                schema: "Prd",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_ProductBrandId",
                schema: "Prd",
                table: "Products",
                column: "ProductBrandId",
                principalSchema: "Prd",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
