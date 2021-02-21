using Microsoft.EntityFrameworkCore.Migrations;

namespace Ozone.DAL.Migrations
{
    public partial class vendorDictionary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BrandName",
                table: "ChecklistElementsTable",
                maxLength: 300,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "VendorsDictionaryTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorName = table.Column<string>(maxLength: 300, nullable: false),
                    Email = table.Column<string>(maxLength: 300, nullable: true),
                    Tel = table.Column<string>(maxLength: 25, nullable: true),
                    Mobile = table.Column<string>(maxLength: 25, nullable: true),
                    Fax = table.Column<string>(maxLength: 25, nullable: true),
                    Country = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorsDictionaryTable", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VendorsDictionaryTable");

            migrationBuilder.DropColumn(
                name: "BrandName",
                table: "ChecklistElementsTable");
        }
    }
}
