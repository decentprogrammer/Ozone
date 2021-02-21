using Microsoft.EntityFrameworkCore.Migrations;

namespace Ozone.DAL.Migrations
{
    public partial class addFaluttypeToElementDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FaultType",
                table: "ChecklistElementDetailsTable",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FaultType",
                table: "ChecklistElementDetailsTable");
        }
    }
}
