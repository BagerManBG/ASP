using Microsoft.EntityFrameworkCore.Migrations;

namespace PicComputers.Data.Migrations
{
    public partial class AddKeyToProductPropertyValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "ProductPropertyValue",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Key",
                table: "ProductPropertyValue");
        }
    }
}
