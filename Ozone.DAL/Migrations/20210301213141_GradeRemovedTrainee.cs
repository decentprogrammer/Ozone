using Microsoft.EntityFrameworkCore.Migrations;

namespace Ozone.DAL.Migrations
{
    public partial class GradeRemovedTrainee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainee_Grade_GradeId",
                schema: "Trainings",
                table: "Trainee");

            migrationBuilder.AlterColumn<int>(
                name: "GradeId",
                schema: "Trainings",
                table: "Trainee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainee_Grade_GradeId",
                schema: "Trainings",
                table: "Trainee",
                column: "GradeId",
                principalSchema: "Catalogue",
                principalTable: "Grade",
                principalColumn: "GradeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainee_Grade_GradeId",
                schema: "Trainings",
                table: "Trainee");

            migrationBuilder.AlterColumn<int>(
                name: "GradeId",
                schema: "Trainings",
                table: "Trainee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainee_Grade_GradeId",
                schema: "Trainings",
                table: "Trainee",
                column: "GradeId",
                principalSchema: "Catalogue",
                principalTable: "Grade",
                principalColumn: "GradeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
