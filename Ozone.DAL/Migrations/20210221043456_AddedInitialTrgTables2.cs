using Microsoft.EntityFrameworkCore.Migrations;

namespace Ozone.DAL.Migrations
{
    public partial class AddedInitialTrgTables2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TraineeCourses_Course_CourseId",
                table: "TraineeCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_TraineeCourses_Trainee_TraineeId",
                table: "TraineeCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TraineeCourses",
                table: "TraineeCourses");

            migrationBuilder.RenameTable(
                name: "TraineeCourses",
                newName: "TraineeCourse",
                newSchema: "Trainings");

            migrationBuilder.RenameIndex(
                name: "IX_TraineeCourses_CourseId",
                schema: "Trainings",
                table: "TraineeCourse",
                newName: "IX_TraineeCourse_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TraineeCourse",
                schema: "Trainings",
                table: "TraineeCourse",
                columns: new[] { "TraineeId", "CourseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TraineeCourse_Course_CourseId",
                schema: "Trainings",
                table: "TraineeCourse",
                column: "CourseId",
                principalSchema: "Trainings",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TraineeCourse_Trainee_TraineeId",
                schema: "Trainings",
                table: "TraineeCourse",
                column: "TraineeId",
                principalSchema: "Trainings",
                principalTable: "Trainee",
                principalColumn: "TraineeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TraineeCourse_Course_CourseId",
                schema: "Trainings",
                table: "TraineeCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_TraineeCourse_Trainee_TraineeId",
                schema: "Trainings",
                table: "TraineeCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TraineeCourse",
                schema: "Trainings",
                table: "TraineeCourse");

            migrationBuilder.RenameTable(
                name: "TraineeCourse",
                schema: "Trainings",
                newName: "TraineeCourses");

            migrationBuilder.RenameIndex(
                name: "IX_TraineeCourse_CourseId",
                table: "TraineeCourses",
                newName: "IX_TraineeCourses_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TraineeCourses",
                table: "TraineeCourses",
                columns: new[] { "TraineeId", "CourseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TraineeCourses_Course_CourseId",
                table: "TraineeCourses",
                column: "CourseId",
                principalSchema: "Trainings",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TraineeCourses_Trainee_TraineeId",
                table: "TraineeCourses",
                column: "TraineeId",
                principalSchema: "Trainings",
                principalTable: "Trainee",
                principalColumn: "TraineeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
