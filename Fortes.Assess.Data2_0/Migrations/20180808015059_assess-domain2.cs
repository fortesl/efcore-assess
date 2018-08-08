using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Fortes.Assess.Data.Migrations
{
    public partial class assessdomain2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Industries_IndustryId1",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_IndustryId1",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "IndustryId1",
                table: "Companies");

            migrationBuilder.AlterColumn<int>(
                name: "IndustryId",
                table: "Companies",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_IndustryId",
                table: "Companies",
                column: "IndustryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Industries_IndustryId",
                table: "Companies",
                column: "IndustryId",
                principalTable: "Industries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Industries_IndustryId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_IndustryId",
                table: "Companies");

            migrationBuilder.AlterColumn<string>(
                name: "IndustryId",
                table: "Companies",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "IndustryId1",
                table: "Companies",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_IndustryId1",
                table: "Companies",
                column: "IndustryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Industries_IndustryId1",
                table: "Companies",
                column: "IndustryId1",
                principalTable: "Industries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
