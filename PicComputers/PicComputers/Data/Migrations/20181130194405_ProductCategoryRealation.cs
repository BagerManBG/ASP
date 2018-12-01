using Microsoft.EntityFrameworkCore.Migrations;

namespace PicComputers.Data.Migrations
{
    public partial class ProductCategoryRealation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductCategory_CategoryProductCategoryId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductProperty_Product_ProductId",
                table: "ProductProperty");

            migrationBuilder.DropIndex(
                name: "IX_ProductProperty_ProductId",
                table: "ProductProperty");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductProperty");

            migrationBuilder.RenameColumn(
                name: "CategoryProductCategoryId",
                table: "Product",
                newName: "ProductCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CategoryProductCategoryId",
                table: "Product",
                newName: "IX_Product_ProductCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductCategory_ProductCategoryId",
                table: "Product",
                column: "ProductCategoryId",
                principalTable: "ProductCategory",
                principalColumn: "ProductCategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductCategory_ProductCategoryId",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "ProductCategoryId",
                table: "Product",
                newName: "CategoryProductCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ProductCategoryId",
                table: "Product",
                newName: "IX_Product_CategoryProductCategoryId");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductProperty",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductProperty_ProductId",
                table: "ProductProperty",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductCategory_CategoryProductCategoryId",
                table: "Product",
                column: "CategoryProductCategoryId",
                principalTable: "ProductCategory",
                principalColumn: "ProductCategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProperty_Product_ProductId",
                table: "ProductProperty",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
