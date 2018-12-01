using Microsoft.EntityFrameworkCore.Migrations;

namespace PicComputers.Data.Migrations
{
    public partial class ProductPropertyMapManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductPropertyMap",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    ProductPropertyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPropertyMap", x => new { x.ProductId, x.ProductPropertyId });
                    table.ForeignKey(
                        name: "FK_ProductPropertyMap_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductPropertyMap_ProductProperty_ProductPropertyId",
                        column: x => x.ProductPropertyId,
                        principalTable: "ProductProperty",
                        principalColumn: "ProductPropertyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductPropertyMap_ProductPropertyId",
                table: "ProductPropertyMap",
                column: "ProductPropertyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductPropertyMap");
        }
    }
}
