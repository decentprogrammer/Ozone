using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ozone.DAL.Migrations
{
    public partial class LastNextMINT_InstalledReplce : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Installed",
                table: "ChecklistElementsTable",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Replace",
                table: "ChecklistElementsTable",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastMINT",
                table: "ChecklistElementDetailsTable",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NextMINT",
                table: "ChecklistElementDetailsTable",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Installed",
                table: "ChecklistElementsTable");

            migrationBuilder.DropColumn(
                name: "Replace",
                table: "ChecklistElementsTable");

            migrationBuilder.DropColumn(
                name: "LastMINT",
                table: "ChecklistElementDetailsTable");

            migrationBuilder.DropColumn(
                name: "NextMINT",
                table: "ChecklistElementDetailsTable");
        }
    }
}
