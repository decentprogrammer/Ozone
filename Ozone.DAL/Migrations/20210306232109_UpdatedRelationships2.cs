using Microsoft.EntityFrameworkCore.Migrations;

namespace Ozone.DAL.Migrations
{
    public partial class UpdatedRelationships2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SkillDescription",
                table: "Trainer",
                schema: "Trainings");

            migrationBuilder.AddColumn<string>(
                name: "Specialization",
                table: "Trainer",
                nullable: true,
                schema: "Trainings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
