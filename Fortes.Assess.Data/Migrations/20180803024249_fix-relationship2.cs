using Microsoft.EntityFrameworkCore.Migrations;

namespace Fortes.Assess.Data.Migrations
{
    public partial class fixrelationship2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdminPageId1",
                table: "Assessments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserPageId1",
                table: "Assessments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_AdminPageId1",
                table: "Assessments",
                column: "AdminPageId1");

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_UserPageId1",
                table: "Assessments",
                column: "UserPageId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_AdminPages_AdminPageId1",
                table: "Assessments",
                column: "AdminPageId1",
                principalTable: "AdminPages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_UserPages_UserPageId1",
                table: "Assessments",
                column: "UserPageId1",
                principalTable: "UserPages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_AdminPages_AdminPageId1",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_UserPages_UserPageId1",
                table: "Assessments");

            migrationBuilder.DropIndex(
                name: "IX_Assessments_AdminPageId1",
                table: "Assessments");

            migrationBuilder.DropIndex(
                name: "IX_Assessments_UserPageId1",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "AdminPageId1",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "UserPageId1",
                table: "Assessments");
        }
    }
}
