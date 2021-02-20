using Microsoft.EntityFrameworkCore.Migrations;

namespace Ozone.DAL.Migrations
{
    public partial class AddedInitialTrgTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Training",
                schema: "Trainings");

            migrationBuilder.AddColumn<int>(
                name: "GradeId",
                schema: "Trainings",
                table: "Trainee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Grade",
                schema: "Catalogue",
                columns: table => new
                {
                    GradeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.GradeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trainee_GradeId",
                schema: "Trainings",
                table: "Trainee",
                column: "GradeId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainee_Grade_GradeId",
                schema: "Trainings",
                table: "Trainee");

            migrationBuilder.DropTable(
                name: "Grade",
                schema: "Catalogue");

            migrationBuilder.DropIndex(
                name: "IX_Trainee_GradeId",
                schema: "Trainings",
                table: "Trainee");

            migrationBuilder.DropColumn(
                name: "GradeId",
                schema: "Trainings",
                table: "Trainee");

            migrationBuilder.CreateTable(
                name: "Training",
                schema: "Trainings",
                columns: table => new
                {
                    TrainingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training", x => x.TrainingId);
                });
        }
    }
}
