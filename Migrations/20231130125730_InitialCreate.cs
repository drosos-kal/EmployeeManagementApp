using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagementChallenge.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Firstname = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Lastname = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Skills = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Details = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TimeCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Firstname", "Lastname", "Skills" },
                values: new object[,]
                {
                    { 1, "John", "Doe", "1,2" },
                    { 2, "Alice", "W", null },
                    { 3, "Ross", "Bob", "2,3" },
                    { 4, "Rachel", "Green", "5" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Details", "Name", "TimeCreated" },
                values: new object[,]
                {
                    { 1, "Knowledge of Python language", "Python", new DateTime(2023, 11, 30, 14, 57, 30, 631, DateTimeKind.Local).AddTicks(693) },
                    { 2, "Knowledge of Java programming language", "Java", new DateTime(2023, 11, 30, 14, 57, 30, 632, DateTimeKind.Local).AddTicks(4159) },
                    { 3, "Web Pages", "HTML", new DateTime(2023, 11, 30, 14, 57, 30, 632, DateTimeKind.Local).AddTicks(4172) },
                    { 4, "Styling", "CSS", new DateTime(2023, 11, 30, 14, 57, 30, 632, DateTimeKind.Local).AddTicks(4173) },
                    { 5, "DOM Handling", "JavaScript", new DateTime(2023, 11, 30, 14, 57, 30, 632, DateTimeKind.Local).AddTicks(4174) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skills_Name",
                table: "Skills",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Skills");
        }
    }
}
