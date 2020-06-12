using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingProject.Data.Migrations
{
    public partial class MinorConfiguringChoiceEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1194d141-a297-4e07-8f9b-580f351759b6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46e5dea4-c794-43c2-b6e7-121cf383cbd7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d0c9509-ef76-4f62-b62f-3976073ce6c7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "897b153e-57ab-4d02-9fb6-19bad08e69ec", "8e1ae4a4-d11f-40e6-b879-c06f29a528cd", "Visitor", "VISITOR" },
                    { "6d368753-e09f-4b21-9bed-241dc52d3f9c", "22d1f6ef-058b-46bb-b2e4-b5fe1b1e1c4e", "Moderator", "MODERATOR" },
                    { "ab90c57c-6c5c-4d6a-9047-260cb695bf47", "a9c9fda6-1634-415e-aae2-ee5c3210c72e", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "Results",
                keyColumn: "ResultId",
                keyValue: 1,
                column: "DateFinished",
                value: new DateTime(2020, 4, 7, 23, 43, 50, 119, DateTimeKind.Local).AddTicks(4712));

            migrationBuilder.UpdateData(
                table: "Results",
                keyColumn: "ResultId",
                keyValue: 2,
                column: "DateFinished",
                value: new DateTime(2020, 4, 7, 23, 43, 50, 119, DateTimeKind.Local).AddTicks(7804));

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 4, 7, 23, 43, 50, 107, DateTimeKind.Local).AddTicks(3707));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d368753-e09f-4b21-9bed-241dc52d3f9c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "897b153e-57ab-4d02-9fb6-19bad08e69ec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab90c57c-6c5c-4d6a-9047-260cb695bf47");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "46e5dea4-c794-43c2-b6e7-121cf383cbd7", "2213a4f1-ef57-48ce-bc9c-0961b7b548fa", "Visitor", "VISITOR" },
                    { "1194d141-a297-4e07-8f9b-580f351759b6", "b4ed74b0-dfd2-4285-97b3-3cc228c70597", "Moderator", "MODERATOR" },
                    { "6d0c9509-ef76-4f62-b62f-3976073ce6c7", "04a45091-ff86-4492-89bf-b9303a7199a6", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "Results",
                keyColumn: "ResultId",
                keyValue: 1,
                column: "DateFinished",
                value: new DateTime(2020, 4, 7, 23, 27, 2, 426, DateTimeKind.Local).AddTicks(6962));

            migrationBuilder.UpdateData(
                table: "Results",
                keyColumn: "ResultId",
                keyValue: 2,
                column: "DateFinished",
                value: new DateTime(2020, 4, 7, 23, 27, 2, 427, DateTimeKind.Local).AddTicks(248));

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 4, 7, 23, 27, 2, 413, DateTimeKind.Local).AddTicks(5418));
        }
    }
}
