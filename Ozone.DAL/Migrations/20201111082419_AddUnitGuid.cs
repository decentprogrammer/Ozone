using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ozone.DAL.Migrations
{
    public partial class AddUnitGuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UnitGuid",
                table: "ChecklistElementDetailsTable",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitGuid",
                table: "ChecklistElementDetailsTable");
        }
    }
}
