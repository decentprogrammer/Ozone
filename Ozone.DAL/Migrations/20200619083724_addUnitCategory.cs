using Microsoft.EntityFrameworkCore.Migrations;

namespace Ozone.DAL.Migrations
{
    public partial class addUnitCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "UnitsTable",
                maxLength: 150,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UnitCategoryTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(maxLength: 150, nullable: false),
                    UnitModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitCategoryTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnitCategoryTable_UnitsTable_UnitModelId",
                        column: x => x.UnitModelId,
                        principalTable: "UnitsTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UnitCategoryTable_UnitModelId",
                table: "UnitCategoryTable",
                column: "UnitModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnitCategoryTable");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "UnitsTable");
        }
    }
}
