using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PicComputers.Data.Migrations
{
    public partial class OneToManyPropertyRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "ProductProperty");

            migrationBuilder.CreateTable(
                name: "ProductPropertyValue",
                columns: table => new
                {
                    ProductPropertyValueId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<string>(nullable: false),
                    ProductPropertyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPropertyValue", x => x.ProductPropertyValueId);
                    table.ForeignKey(
                        name: "FK_ProductPropertyValue_ProductProperty_ProductPropertyId",
                        column: x => x.ProductPropertyId,
                        principalTable: "ProductProperty",
                        principalColumn: "ProductPropertyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductPropertyValue_ProductPropertyId",
                table: "ProductPropertyValue",
                column: "ProductPropertyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductPropertyValue");

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "ProductProperty",
                maxLength: 60,
                nullable: false,
                defaultValue: "");
        }
    }
}
