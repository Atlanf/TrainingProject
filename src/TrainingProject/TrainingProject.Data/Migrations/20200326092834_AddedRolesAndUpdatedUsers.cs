using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingProject.Data.Migrations
{
    public partial class AddedRolesAndUpdatedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Results",
                keyColumn: "ResultId",
                keyValue: 1,
                column: "DateFinished",
                value: new DateTime(2020, 3, 26, 12, 28, 20, 530, DateTimeKind.Local).AddTicks(5683));

            migrationBuilder.UpdateData(
                table: "Results",
                keyColumn: "ResultId",
                keyValue: 2,
                column: "DateFinished",
                value: new DateTime(2020, 3, 26, 12, 28, 20, 530, DateTimeKind.Local).AddTicks(8987));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Role name 1" });

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 3, 26, 12, 28, 20, 520, DateTimeKind.Local).AddTicks(8610));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Password", "RoleId" },
                values: new object[] { "SomeMail@test.by", "PswTest1", 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Password", "RoleId" },
                values: new object[] { "SomeMail2@test.by", "PswTest2", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Role_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Role_RoleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Results",
                keyColumn: "ResultId",
                keyValue: 1,
                column: "DateFinished",
                value: new DateTime(2020, 3, 24, 17, 29, 31, 221, DateTimeKind.Local).AddTicks(4474));

            migrationBuilder.UpdateData(
                table: "Results",
                keyColumn: "ResultId",
                keyValue: 2,
                column: "DateFinished",
                value: new DateTime(2020, 3, 24, 17, 29, 31, 221, DateTimeKind.Local).AddTicks(8275));

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 3, 24, 17, 29, 31, 211, DateTimeKind.Local).AddTicks(3161));
        }
    }
}
