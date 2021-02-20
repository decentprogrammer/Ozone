using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ozone.DAL.Migrations
{
    public partial class AddedTrgTablesUpdated2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainer_Course_CourseId",
                schema: "Trainings",
                table: "Trainer");

            migrationBuilder.DropTable(
                name: "TraineeCourse",
                schema: "Trainings");

            migrationBuilder.DropColumn(
                name: "Title",
                schema: "Trainings",
                table: "Course");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                schema: "Trainings",
                table: "Trainer",
                newName: "TrainingId");

            migrationBuilder.RenameIndex(
                name: "IX_Trainer_CourseId",
                schema: "Trainings",
                table: "Trainer",
                newName: "IX_Trainer_TrainingId");

            migrationBuilder.AddColumn<string>(
                name: "CourseName",
                schema: "Trainings",
                table: "Course",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Training",
                schema: "Trainings",
                columns: table => new
                {
                    TrainingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training", x => x.TrainingId);
                    table.ForeignKey(
                        name: "FK_Training_Course_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "Trainings",
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TraineeTraining",
                schema: "Trainings",
                columns: table => new
                {
                    TraineeId = table.Column<int>(type: "int", nullable: false),
                    TrainingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraineeTraining", x => new { x.TraineeId, x.TrainingId });
                    table.ForeignKey(
                        name: "FK_TraineeTraining_Trainee_TraineeId",
                        column: x => x.TraineeId,
                        principalSchema: "Trainings",
                        principalTable: "Trainee",
                        principalColumn: "TraineeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TraineeTraining_Training_TrainingId",
                        column: x => x.TrainingId,
                        principalSchema: "Trainings",
                        principalTable: "Training",
                        principalColumn: "TrainingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TraineeTraining_TrainingId",
                schema: "Trainings",
                table: "TraineeTraining",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_Training_CourseId",
                schema: "Trainings",
                table: "Training",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainer_Training_TrainingId",
                schema: "Trainings",
                table: "Trainer",
                column: "TrainingId",
                principalSchema: "Trainings",
                principalTable: "Training",
                principalColumn: "TrainingId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainer_Training_TrainingId",
                schema: "Trainings",
                table: "Trainer");

            migrationBuilder.DropTable(
                name: "TraineeTraining",
                schema: "Trainings");

            migrationBuilder.DropTable(
                name: "Training",
                schema: "Trainings");

            migrationBuilder.DropColumn(
                name: "CourseName",
                schema: "Trainings",
                table: "Course");

            migrationBuilder.RenameColumn(
                name: "TrainingId",
                schema: "Trainings",
                table: "Trainer",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Trainer_TrainingId",
                schema: "Trainings",
                table: "Trainer",
                newName: "IX_Trainer_CourseId");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                schema: "Trainings",
                table: "Course",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TraineeCourse",
                schema: "Trainings",
                columns: table => new
                {
                    TraineeId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraineeCourse", x => new { x.TraineeId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_TraineeCourse_Course_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "Trainings",
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TraineeCourse_Trainee_TraineeId",
                        column: x => x.TraineeId,
                        principalSchema: "Trainings",
                        principalTable: "Trainee",
                        principalColumn: "TraineeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TraineeCourse_CourseId",
                schema: "Trainings",
                table: "TraineeCourse",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainer_Course_CourseId",
                schema: "Trainings",
                table: "Trainer",
                column: "CourseId",
                principalSchema: "Trainings",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
