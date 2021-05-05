using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductDb.Migrations
{
    public partial class RemovedBoxIdFromProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoxesToProducts",
                schema: "Prd");
        }
    }
}
