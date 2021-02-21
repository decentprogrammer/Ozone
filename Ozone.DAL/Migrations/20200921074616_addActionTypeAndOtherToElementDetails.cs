using Microsoft.EntityFrameworkCore.Migrations;

namespace Ozone.DAL.Migrations
{
    public partial class addActionTypeAndOtherToElementDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FaultType",
                table: "ChecklistElementDetailsTable",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FaultOther",
                table: "ChecklistElementDetailsTable",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ActionOther",
                table: "ChecklistElementDetailsTable",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ActionType",
                table: "ChecklistElementDetailsTable",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActionOther",
                table: "ChecklistElementDetailsTable");

            migrationBuilder.DropColumn(
                name: "ActionType",
                table: "ChecklistElementDetailsTable");

            migrationBuilder.AlterColumn<string>(
                name: "FaultType",
                table: "ChecklistElementDetailsTable",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FaultOther",
                table: "ChecklistElementDetailsTable",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
