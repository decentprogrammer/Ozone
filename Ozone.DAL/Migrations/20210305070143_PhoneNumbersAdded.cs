using Microsoft.EntityFrameworkCore.Migrations;

namespace Ozone.DAL.Migrations
{
    public partial class PhoneNumbersAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CellNumber",
                schema: "Trainings",
                table: "Trainer",
                newName: "PhoneHome");

            migrationBuilder.AddColumn<string>(
                name: "PhoneMobile",
                schema: "Trainings",
                table: "Trainer",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneHome",
                schema: "Trainings",
                table: "Trainee",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneMobile",
                schema: "Trainings",
                table: "Trainee",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneMobile",
                schema: "Trainings",
                table: "Trainer");

            migrationBuilder.DropColumn(
                name: "PhoneHome",
                schema: "Trainings",
                table: "Trainee");

            migrationBuilder.DropColumn(
                name: "PhoneMobile",
                schema: "Trainings",
                table: "Trainee");

            migrationBuilder.RenameColumn(
                name: "PhoneHome",
                schema: "Trainings",
                table: "Trainer",
                newName: "CellNumber");
        }
    }
}
