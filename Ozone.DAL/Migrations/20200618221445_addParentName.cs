using Microsoft.EntityFrameworkCore.Migrations;

namespace Ozone.DAL.Migrations
{
    public partial class addParentName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ParentName",
                table: "UnitsTable",
                maxLength: 300,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentName",
                table: "UnitsTable");
        }
    }
}
