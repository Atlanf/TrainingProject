using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingProject.Data.Migrations
{
    public partial class ModelChangeAndDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Tests_TestId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_TestResults_Tests_TestId",
                table: "TestResults");

            migrationBuilder.DropForeignKey(
                name: "FK_TestResults_Users_UserId",
                table: "TestResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestResults",
                table: "TestResults");

            migrationBuilder.RenameTable(
                name: "TestResults",
                newName: "Results");

            migrationBuilder.RenameIndex(
                name: "IX_TestResults_TestId",
                table: "Results",
                newName: "IX_Results_TestId");

            migrationBuilder.AlterColumn<int>(
                name: "TestId",
                table: "Questions",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TestId",
                table: "Results",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Results",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ResultId",
                table: "Results",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Results",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Results",
                table: "Results",
                column: "ResultId");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, "Test description 1", false, "C#" },
                    { 2, "Test description java test 123", false, "Java" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "IsDeleted", "LastName", "UserName" },
                values: new object[,]
                {
                    { 1, "Ivan", false, "Ivanov", "UserIvan" },
                    { 2, "Petr", false, "Petrov", "User_Petr" }
                });

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "Id", "AuthorId", "CategoryId", "DateCreated", "Description", "IsDeleted", "Name" },
                values: new object[] { 1, 1, 1, new DateTime(2020, 3, 24, 17, 29, 31, 211, DateTimeKind.Local).AddTicks(3161), "Some kind of description", false, "C# Basics" });

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "Id", "AuthorId", "CategoryId", "DateCreated", "Description", "IsDeleted", "Name" },
                values: new object[] { 2, 1, 1, new DateTime(2020, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Another description", false, "C# OOP" });

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "Id", "AuthorId", "CategoryId", "DateCreated", "Description", "IsDeleted", "Name" },
                values: new object[] { 3, 2, 2, new DateTime(2020, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Java description", false, "Java Basics" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Description", "Image", "IsDeleted", "MultipleAnswers", "TestId" },
                values: new object[,]
                {
                    { 1, "Test 1 Question #1 text", "", false, false, 1 },
                    { 2, "Test 1 Question #2 text", "Some image path", false, false, 1 },
                    { 3, "Test 1 Question #3 text", "", false, true, 1 },
                    { 4, "Test 2 Question #1 text", "Image", false, false, 2 }
                });

            migrationBuilder.InsertData(
                table: "Results",
                columns: new[] { "ResultId", "CorrectAnswers", "DateFinished", "IsDeleted", "TestFinished", "TestId", "UserId" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2020, 3, 24, 17, 29, 31, 221, DateTimeKind.Local).AddTicks(4474), false, true, 1, 1 },
                    { 2, 1, new DateTime(2020, 3, 24, 17, 29, 31, 221, DateTimeKind.Local).AddTicks(8275), false, false, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Choices",
                columns: new[] { "Id", "Description", "IsAnswer", "IsDeleted", "QuestionId" },
                values: new object[,]
                {
                    { 1, "Choice 1 for question 1", false, false, 1 },
                    { 2, "Choice 2 for question 1", true, false, 1 },
                    { 3, "Choice 3 for question 1", false, false, 1 },
                    { 4, "Choice 1 for question 2", true, false, 2 },
                    { 5, "Choice 2 for question 2", false, false, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Results_UserId",
                table: "Results",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Tests_TestId",
                table: "Questions",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Tests_TestId",
                table: "Results",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Users_UserId",
                table: "Results",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Tests_TestId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Tests_TestId",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Users_UserId",
                table: "Results");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Results",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Results_UserId",
                table: "Results");

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Results",
                keyColumn: "ResultId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Results",
                keyColumn: "ResultId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "ResultId",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Results");

            migrationBuilder.RenameTable(
                name: "Results",
                newName: "TestResults");

            migrationBuilder.RenameIndex(
                name: "IX_Results_TestId",
                table: "TestResults",
                newName: "IX_TestResults_TestId");

            migrationBuilder.AlterColumn<int>(
                name: "TestId",
                table: "Questions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "TestResults",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TestId",
                table: "TestResults",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestResults",
                table: "TestResults",
                columns: new[] { "UserId", "TestId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Tests_TestId",
                table: "Questions",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestResults_Tests_TestId",
                table: "TestResults",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TestResults_Users_UserId",
                table: "TestResults",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
