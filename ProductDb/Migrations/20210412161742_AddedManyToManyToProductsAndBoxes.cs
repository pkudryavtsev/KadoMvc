using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductDb.Migrations
{
    public partial class AddedManyToManyToProductsAndBoxes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Boxes_BoxId",
                schema: "Prd",
                table: "Products");

            migrationBuilder.DropTable(
                name: "BoxesToProducts",
                schema: "Prd");

            migrationBuilder.DropIndex(
                name: "IX_Products_BoxId",
                schema: "Prd",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BoxId",
                schema: "Prd",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "BoxProducts",
                schema: "Prd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoxId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoxProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoxProducts_Boxes_BoxId",
                        column: x => x.BoxId,
                        principalSchema: "Prd",
                        principalTable: "Boxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoxProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Prd",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoxProducts_BoxId_ProductId",
                schema: "Prd",
                table: "BoxProducts",
                columns: new[] { "BoxId", "ProductId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoxProducts_ProductId",
                schema: "Prd",
                table: "BoxProducts",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoxProducts",
                schema: "Prd");

            migrationBuilder.AddColumn<int>(
                name: "BoxId",
                schema: "Prd",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BoxesToProducts",
                schema: "Prd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoxId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoxesToProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoxesToProducts_Boxes_BoxId",
                        column: x => x.BoxId,
                        principalSchema: "Prd",
                        principalTable: "Boxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoxesToProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Prd",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_BoxId",
                schema: "Prd",
                table: "Products",
                column: "BoxId");

            migrationBuilder.CreateIndex(
                name: "IX_BoxesToProducts_BoxId_ProductId",
                schema: "Prd",
                table: "BoxesToProducts",
                columns: new[] { "BoxId", "ProductId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoxesToProducts_ProductId",
                schema: "Prd",
                table: "BoxesToProducts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Boxes_BoxId",
                schema: "Prd",
                table: "Products",
                column: "BoxId",
                principalSchema: "Prd",
                principalTable: "Boxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
