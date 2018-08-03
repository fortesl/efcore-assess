using Microsoft.EntityFrameworkCore.Migrations;

namespace Fortes.Assess.Data.Migrations
{
    public partial class fixidnames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Industry",
                table: "Companies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TypeId",
                table: "Questions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Industry",
                table: "Companies",
                nullable: true);
        }
    }
}
