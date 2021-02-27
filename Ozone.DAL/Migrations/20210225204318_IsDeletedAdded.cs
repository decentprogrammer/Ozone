using Microsoft.EntityFrameworkCore.Migrations;

namespace Ozone.DAL.Migrations
{
    public partial class IsDeletedAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IsDeleted",
                schema: "Trainings",
                table: "Training",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsDeleted",
                schema: "Trainings",
                table: "Trainer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsDeleted",
                schema: "Trainings",
                table: "Trainee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsDeleted",
                schema: "Trainings",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Trainings",
                table: "Training");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Trainings",
                table: "Trainer");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Trainings",
                table: "Trainee");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Trainings",
                table: "Course");
        }
    }
}
