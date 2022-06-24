using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace minimalAPIef.Migrations
{
    public partial class ColumWeightCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "weight",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "weight",
                table: "Category");
        }
    }
}
