using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Fortes.Assess.Data.Migrations
{
    public partial class assessdomain3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_AdminPages_AdminPageId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_Companies_CompanyId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_Durations_DurationId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_Fields_FieldId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_Frameworks_FrameworkId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_Industries_IndustryId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_Levels_LevelId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_Occupations_OccupationId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_ProgrammingLanguages_ProgrammingLanguageId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_UserPages_UserPageId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Industries_IndustryId",
                table: "Companies");

            migrationBuilder.AlterColumn<int>(
                name: "IndustryId",
                table: "Companies",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "UserPageId",
                table: "Assessments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ProgrammingLanguageId",
                table: "Assessments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PassingGrade",
                table: "Assessments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "OccupationId",
                table: "Assessments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "LevelId",
                table: "Assessments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "IndustryId",
                table: "Assessments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "FrameworkId",
                table: "Assessments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "FieldId",
                table: "Assessments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DurationId",
                table: "Assessments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Assessments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AdminPageId",
                table: "Assessments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_AdminPages_AdminPageId",
                table: "Assessments",
                column: "AdminPageId",
                principalTable: "AdminPages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_Companies_CompanyId",
                table: "Assessments",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_Durations_DurationId",
                table: "Assessments",
                column: "DurationId",
                principalTable: "Durations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_Fields_FieldId",
                table: "Assessments",
                column: "FieldId",
                principalTable: "Fields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_Frameworks_FrameworkId",
                table: "Assessments",
                column: "FrameworkId",
                principalTable: "Frameworks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_Industries_IndustryId",
                table: "Assessments",
                column: "IndustryId",
                principalTable: "Industries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_Levels_LevelId",
                table: "Assessments",
                column: "LevelId",
                principalTable: "Levels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_Occupations_OccupationId",
                table: "Assessments",
                column: "OccupationId",
                principalTable: "Occupations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_ProgrammingLanguages_ProgrammingLanguageId",
                table: "Assessments",
                column: "ProgrammingLanguageId",
                principalTable: "ProgrammingLanguages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_UserPages_UserPageId",
                table: "Assessments",
                column: "UserPageId",
                principalTable: "UserPages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Industries_IndustryId",
                table: "Companies",
                column: "IndustryId",
                principalTable: "Industries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_AdminPages_AdminPageId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_Companies_CompanyId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_Durations_DurationId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_Fields_FieldId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_Frameworks_FrameworkId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_Industries_IndustryId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_Levels_LevelId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_Occupations_OccupationId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_ProgrammingLanguages_ProgrammingLanguageId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_UserPages_UserPageId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Industries_IndustryId",
                table: "Companies");

            migrationBuilder.AlterColumn<int>(
                name: "IndustryId",
                table: "Companies",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserPageId",
                table: "Assessments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProgrammingLanguageId",
                table: "Assessments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PassingGrade",
                table: "Assessments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OccupationId",
                table: "Assessments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LevelId",
                table: "Assessments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IndustryId",
                table: "Assessments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FrameworkId",
                table: "Assessments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FieldId",
                table: "Assessments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DurationId",
                table: "Assessments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Assessments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AdminPageId",
                table: "Assessments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_AdminPages_AdminPageId",
                table: "Assessments",
                column: "AdminPageId",
                principalTable: "AdminPages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_Companies_CompanyId",
                table: "Assessments",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_Durations_DurationId",
                table: "Assessments",
                column: "DurationId",
                principalTable: "Durations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_Fields_FieldId",
                table: "Assessments",
                column: "FieldId",
                principalTable: "Fields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_Frameworks_FrameworkId",
                table: "Assessments",
                column: "FrameworkId",
                principalTable: "Frameworks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_Industries_IndustryId",
                table: "Assessments",
                column: "IndustryId",
                principalTable: "Industries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_Levels_LevelId",
                table: "Assessments",
                column: "LevelId",
                principalTable: "Levels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_Occupations_OccupationId",
                table: "Assessments",
                column: "OccupationId",
                principalTable: "Occupations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_ProgrammingLanguages_ProgrammingLanguageId",
                table: "Assessments",
                column: "ProgrammingLanguageId",
                principalTable: "ProgrammingLanguages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_UserPages_UserPageId",
                table: "Assessments",
                column: "UserPageId",
                principalTable: "UserPages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Industries_IndustryId",
                table: "Companies",
                column: "IndustryId",
                principalTable: "Industries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
