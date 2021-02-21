using Microsoft.EntityFrameworkCore.Migrations;

namespace Ozone.DAL.Migrations
{
    public partial class SchemaAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Trainings");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "Course",
                newSchema: "Trainings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Course",
                schema: "Trainings",
                newName: "Course");
        }
    }
}
