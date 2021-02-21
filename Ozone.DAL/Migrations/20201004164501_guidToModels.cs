using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ozone.DAL.Migrations
{
    public partial class guidToModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GuidId",
                table: "UnitChecklistTable",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "GuidId",
                table: "ChecklistElementsTable",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "GuidId",
                table: "ChecklistElementDetailsTable",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "GuidId",
                table: "ChecklistCategoriesTable",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GuidId",
                table: "UnitChecklistTable");

            migrationBuilder.DropColumn(
                name: "GuidId",
                table: "ChecklistElementsTable");

            migrationBuilder.DropColumn(
                name: "GuidId",
                table: "ChecklistElementDetailsTable");

            migrationBuilder.DropColumn(
                name: "GuidId",
                table: "ChecklistCategoriesTable");
        }
    }
}
