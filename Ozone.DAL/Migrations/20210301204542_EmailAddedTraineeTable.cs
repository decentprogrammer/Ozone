using Microsoft.EntityFrameworkCore.Migrations;

namespace Ozone.DAL.Migrations
{
    public partial class EmailAddedTraineeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address1",
                schema: "Trainings",
                table: "Trainee");

            migrationBuilder.DropColumn(
                name: "Address2",
                schema: "Trainings",
                table: "Trainee");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "Trainings",
                table: "Trainee",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "Trainings",
                table: "Trainee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                schema: "Trainings",
                table: "Trainee");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "Trainings",
                table: "Trainee");

            migrationBuilder.AddColumn<string>(
                name: "Address1",
                schema: "Trainings",
                table: "Trainee",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address2",
                schema: "Trainings",
                table: "Trainee",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
