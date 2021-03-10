using Microsoft.EntityFrameworkCore.Migrations;

namespace Ozone.DAL.Migrations
{
    public partial class AddedTrgTablesUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainee_Gender_GenderId",
                schema: "Trainings",
                table: "Trainee");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "Trainings",
                table: "Trainee",
                newName: "FullName");

            migrationBuilder.AlterColumn<int>(
                name: "GenderId",
                schema: "Trainings",
                table: "Trainee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "TraineeCourses",
                columns: table => new
                {
                    TraineeId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraineeCourses", x => new { x.TraineeId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_TraineeCourses_Course_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "Trainings",
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TraineeCourses_Trainee_TraineeId",
                        column: x => x.TraineeId,
                        principalSchema: "Trainings",
                        principalTable: "Trainee",
                        principalColumn: "TraineeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trainer",
                schema: "Trainings",
                columns: table => new
                {
                    TrainerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CellNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainer", x => x.TrainerId);
                    table.ForeignKey(
                        name: "FK_Trainer_Course_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "Trainings",
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TraineeCourses_CourseId",
                table: "TraineeCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainer_CourseId",
                schema: "Trainings",
                table: "Trainer",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainee_Gender_GenderId",
                schema: "Trainings",
                table: "Trainee",
                column: "GenderId",
                principalSchema: "Catalogue",
                principalTable: "Gender",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainee_Gender_GenderId",
                schema: "Trainings",
                table: "Trainee");

            migrationBuilder.DropTable(
                name: "TraineeCourses");

            migrationBuilder.DropTable(
                name: "Trainer",
                schema: "Trainings");

            migrationBuilder.RenameColumn(
                name: "FullName",
                schema: "Trainings",
                table: "Trainee",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "GenderId",
                schema: "Trainings",
                table: "Trainee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainee_Gender_GenderId",
                schema: "Trainings",
                table: "Trainee",
                column: "GenderId",
                principalSchema: "Catalogue",
                principalTable: "Gender",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
