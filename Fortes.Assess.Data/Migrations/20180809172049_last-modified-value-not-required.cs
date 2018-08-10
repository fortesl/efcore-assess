using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fortes.Assess.Data.Migrations
{
    public partial class lastmodifiedvaluenotrequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2018, 8, 9, 12, 20, 48, 953, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "UserRole",
                nullable: false,
                defaultValue: new DateTime(2018, 8, 9, 12, 20, 48, 953, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "UserPages",
                nullable: false,
                defaultValue: new DateTime(2018, 8, 9, 12, 20, 48, 953, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Tags",
                nullable: false,
                defaultValue: new DateTime(2018, 8, 9, 12, 20, 48, 953, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Roles",
                nullable: false,
                defaultValue: new DateTime(2018, 8, 9, 12, 20, 48, 953, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "QuestionTypes",
                nullable: false,
                defaultValue: new DateTime(2018, 8, 9, 12, 20, 48, 953, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "QuestionTag",
                nullable: false,
                defaultValue: new DateTime(2018, 8, 9, 12, 20, 48, 953, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Questions",
                nullable: false,
                defaultValue: new DateTime(2018, 8, 9, 12, 20, 48, 953, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "ProgrammingLanguages",
                nullable: false,
                defaultValue: new DateTime(2018, 8, 9, 12, 20, 48, 953, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Option",
                nullable: false,
                defaultValue: new DateTime(2018, 8, 9, 12, 20, 48, 952, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Occupations",
                nullable: false,
                defaultValue: new DateTime(2018, 8, 9, 12, 20, 48, 952, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Levels",
                nullable: false,
                defaultValue: new DateTime(2018, 8, 9, 12, 20, 48, 952, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Industries",
                nullable: false,
                defaultValue: new DateTime(2018, 8, 9, 12, 20, 48, 952, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Frameworks",
                nullable: false,
                defaultValue: new DateTime(2018, 8, 9, 12, 20, 48, 952, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Fields",
                nullable: false,
                defaultValue: new DateTime(2018, 8, 9, 12, 20, 48, 952, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Durations",
                nullable: false,
                defaultValue: new DateTime(2018, 8, 9, 12, 20, 48, 952, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Companies",
                nullable: false,
                defaultValue: new DateTime(2018, 8, 9, 12, 20, 48, 952, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "AssessmentUser",
                nullable: false,
                defaultValue: new DateTime(2018, 8, 9, 12, 20, 48, 952, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "AssessmentQuestion",
                nullable: false,
                defaultValue: new DateTime(2018, 8, 9, 12, 20, 48, 952, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "AdminPages",
                nullable: false,
                defaultValue: new DateTime(2018, 8, 9, 12, 20, 48, 946, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "LastModified", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 8, 9, 12, 20, 48, 954, DateTimeKind.Local), "User" },
                    { 2, new DateTime(2018, 8, 9, 12, 20, 48, 954, DateTimeKind.Local), "Admin" },
                    { 3, new DateTime(2018, 8, 9, 12, 20, 48, 954, DateTimeKind.Local), "AssessmentAdmin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CompanyId", "Email", "FirstName", "LastModified", "LastName", "Name" },
                values: new object[] { 1, null, "lmlf100@gmail.com", null, new DateTime(2018, 8, 9, 12, 20, 48, 954, DateTimeKind.Local), "Fortes", "Luis Fortes" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "UserId", "RoleId", "LastModified" },
                values: new object[] { 1, 2, new DateTime(2018, 8, 9, 12, 20, 48, 954, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Users",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 8, 9, 12, 20, 48, 953, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "UserRole",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 8, 9, 12, 20, 48, 953, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "UserPages",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 8, 9, 12, 20, 48, 953, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Tags",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 8, 9, 12, 20, 48, 953, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Roles",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 8, 9, 12, 20, 48, 953, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "QuestionTypes",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 8, 9, 12, 20, 48, 953, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "QuestionTag",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 8, 9, 12, 20, 48, 953, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Questions",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 8, 9, 12, 20, 48, 953, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "ProgrammingLanguages",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 8, 9, 12, 20, 48, 953, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Option",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 8, 9, 12, 20, 48, 952, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Occupations",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 8, 9, 12, 20, 48, 952, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Levels",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 8, 9, 12, 20, 48, 952, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Industries",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 8, 9, 12, 20, 48, 952, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Frameworks",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 8, 9, 12, 20, 48, 952, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Fields",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 8, 9, 12, 20, 48, 952, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Durations",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 8, 9, 12, 20, 48, 952, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Companies",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 8, 9, 12, 20, 48, 952, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "AssessmentUser",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 8, 9, 12, 20, 48, 952, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "AssessmentQuestion",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 8, 9, 12, 20, 48, 952, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "AdminPages",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 8, 9, 12, 20, 48, 946, DateTimeKind.Local));
        }
    }
}
