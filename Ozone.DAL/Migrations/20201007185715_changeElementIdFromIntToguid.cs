using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ozone.DAL.Migrations
{
    public partial class changeElementIdFromIntToguid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ElementId",
                table: "ChecklistElementDetailsTable",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ElementId",
                table: "ChecklistElementDetailsTable",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid));
        }
    }
}
