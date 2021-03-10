using Microsoft.EntityFrameworkCore.Migrations;

namespace Ozone.DAL.Migrations
{
    public partial class UpdatedRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainer_Training_TrainingId",
                schema: "Trainings",
                table: "Trainer");

            migrationBuilder.DropIndex(
                name: "IX_Trainer_TrainingId",
                schema: "Trainings",
                table: "Trainer");

            migrationBuilder.DropColumn(
                name: "TrainingId",
                schema: "Trainings",
                table: "Trainer");

            migrationBuilder.CreateTable(
                name: "TrainerTraining",
                schema: "Trainings",
                columns: table => new
                {
                    TrainerId = table.Column<int>(type: "int", nullable: false),
                    TrainingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerTraining", x => new { x.TrainerId, x.TrainingId });
                    table.ForeignKey(
                        name: "FK_TrainerTraining_Trainer_TrainerId",
                        column: x => x.TrainerId,
                        principalSchema: "Trainings",
                        principalTable: "Trainer",
                        principalColumn: "TrainerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainerTraining_Training_TrainingId",
                        column: x => x.TrainingId,
                        principalSchema: "Trainings",
                        principalTable: "Training",
                        principalColumn: "TrainingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainerTraining_TrainingId",
                schema: "Trainings",
                table: "TrainerTraining",
                column: "TrainingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainerTraining",
                schema: "Trainings");

            migrationBuilder.AddColumn<int>(
                name: "TrainingId",
                schema: "Trainings",
                table: "Trainer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Trainer_TrainingId",
                schema: "Trainings",
                table: "Trainer",
                column: "TrainingId");

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
    }
}
