using Microsoft.EntityFrameworkCore.Migrations;

namespace Fortes.Assess.Data.Migrations
{
    public partial class changecontentfieldName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "UserPages",
                newName: "Body");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "AdminPages",
                newName: "Body");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Body",
                table: "UserPages",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "Body",
                table: "AdminPages",
                newName: "Content");
        }
    }
}
