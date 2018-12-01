using Microsoft.EntityFrameworkCore.Migrations;

namespace PicComputers.Data.Migrations
{
    public partial class ProductPropertyMapManyToMany2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPropertyMap_ProductProperty_ProductPropertyId",
                table: "ProductPropertyMap");

            migrationBuilder.RenameColumn(
                name: "ProductPropertyId",
                table: "ProductPropertyMap",
                newName: "ProductPropertyValueId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPropertyMap_ProductPropertyId",
                table: "ProductPropertyMap",
                newName: "IX_ProductPropertyMap_ProductPropertyValueId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPropertyMap_ProductPropertyValue_ProductPropertyValueId",
                table: "ProductPropertyMap",
                column: "ProductPropertyValueId",
                principalTable: "ProductPropertyValue",
                principalColumn: "ProductPropertyValueId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPropertyMap_ProductPropertyValue_ProductPropertyValueId",
                table: "ProductPropertyMap");

            migrationBuilder.RenameColumn(
                name: "ProductPropertyValueId",
                table: "ProductPropertyMap",
                newName: "ProductPropertyId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPropertyMap_ProductPropertyValueId",
                table: "ProductPropertyMap",
                newName: "IX_ProductPropertyMap_ProductPropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPropertyMap_ProductProperty_ProductPropertyId",
                table: "ProductPropertyMap",
                column: "ProductPropertyId",
                principalTable: "ProductProperty",
                principalColumn: "ProductPropertyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
