using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ozone.DAL.Migrations
{
    public partial class IntialDatabase_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UnitsTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnglishName = table.Column<string>(maxLength: 300, nullable: false),
                    ArabicName = table.Column<string>(maxLength: 300, nullable: false),
                    NameAbbreviation = table.Column<string>(maxLength: 10, nullable: true),
                    Location = table.Column<string>(maxLength: 300, nullable: false),
                    ResponsibleName = table.Column<string>(maxLength: 300, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Email = table.Column<string>(maxLength: 300, nullable: true),
                    Telephone = table.Column<string>(maxLength: 15, nullable: true),
                    InternalTel_1 = table.Column<string>(maxLength: 8, nullable: true),
                    InternalTel_2 = table.Column<string>(maxLength: 8, nullable: true),
                    Mobile = table.Column<string>(maxLength: 15, nullable: true),
                    Fax = table.Column<string>(maxLength: 15, nullable: true),
                    PersonToCantact = table.Column<string>(maxLength: 100, nullable: true),
                    ParentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitsTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitChecklistTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicVisible = table.Column<bool>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    GeneralStatus = table.Column<string>(maxLength: 20, nullable: false),
                    UserID = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    UnitID = table.Column<int>(nullable: false),
                    UnitModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitChecklistTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnitChecklistTable_UnitsTable_UnitModelId",
                        column: x => x.UnitModelId,
                        principalTable: "UnitsTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChecklistCategoriesTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HelpId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    PublicVisible = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    UnitChecklistId = table.Column<int>(nullable: false),
                    UnitChecklistModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChecklistCategoriesTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChecklistCategoriesTable_UnitChecklistTable_UnitChecklistModelId",
                        column: x => x.UnitChecklistModelId,
                        principalTable: "UnitChecklistTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChecklistElementsTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HelpId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 300, nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    ProcessStatus = table.Column<string>(maxLength: 20, nullable: false),
                    PublicVisible = table.Column<bool>(nullable: false),
                    ElementRank = table.Column<string>(maxLength: 20, nullable: false),
                    CartegoryId = table.Column<int>(nullable: false),
                    ChecklistCategoryModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChecklistElementsTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChecklistElementsTable_ChecklistCategoriesTable_ChecklistCategoryModelId",
                        column: x => x.ChecklistCategoryModelId,
                        principalTable: "ChecklistCategoriesTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChecklistElementDetailsTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(maxLength: 20, nullable: false),
                    StartEventDate = table.Column<DateTime>(nullable: false),
                    EndEventDate = table.Column<DateTime>(nullable: true),
                    StartEventHour = table.Column<DateTime>(nullable: false),
                    EndEventHour = table.Column<DateTime>(nullable: true),
                    FaultDescription = table.Column<string>(nullable: false),
                    ResponseDescription = table.Column<string>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    EmployeesInvolved = table.Column<string>(nullable: false),
                    PublicVisible = table.Column<bool>(nullable: false),
                    FaultRank = table.Column<string>(maxLength: 20, nullable: false),
                    ElementId = table.Column<int>(nullable: false),
                    ChecklistElementModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChecklistElementDetailsTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChecklistElementDetailsTable_ChecklistElementsTable_ChecklistElementModelId",
                        column: x => x.ChecklistElementModelId,
                        principalTable: "ChecklistElementsTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistCategoriesTable_UnitChecklistModelId",
                table: "ChecklistCategoriesTable",
                column: "UnitChecklistModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistElementDetailsTable_ChecklistElementModelId",
                table: "ChecklistElementDetailsTable",
                column: "ChecklistElementModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistElementsTable_ChecklistCategoryModelId",
                table: "ChecklistElementsTable",
                column: "ChecklistCategoryModelId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitChecklistTable_UnitModelId",
                table: "UnitChecklistTable",
                column: "UnitModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChecklistElementDetailsTable");

            migrationBuilder.DropTable(
                name: "ChecklistElementsTable");

            migrationBuilder.DropTable(
                name: "ChecklistCategoriesTable");

            migrationBuilder.DropTable(
                name: "UnitChecklistTable");

            migrationBuilder.DropTable(
                name: "UnitsTable");
        }
    }
}
