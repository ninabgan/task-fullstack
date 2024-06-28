using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Version = table.Column<int>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Version = table.Column<int>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Version = table.Column<int>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Version = table.Column<int>(type: "INTEGER", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true),
                    UnitId = table.Column<int>(type: "INTEGER", nullable: true),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: true),
                    ValidFrom = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ValidTo = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRoles_Unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Unit",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name", "Version" },
                values: new object[] { 101, "User administration", 1 });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name", "Version" },
                values: new object[] { 102, "Endoscopist administration", 2 });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name", "Version" },
                values: new object[] { 103, "Report colonoscopy capacity", 1 });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name", "Version" },
                values: new object[] { 104, "Send invitations", 2 });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name", "Version" },
                values: new object[] { 105, "View statistics", 1 });

            migrationBuilder.InsertData(
                table: "Unit",
                columns: new[] { "Id", "Name", "Version" },
                values: new object[] { 11, "Kreftregisteret", 2 });

            migrationBuilder.InsertData(
                table: "Unit",
                columns: new[] { "Id", "Name", "Version" },
                values: new object[] { 12, "Akershus universitetssykehus HF", 1 });

            migrationBuilder.InsertData(
                table: "Unit",
                columns: new[] { "Id", "Name", "Version" },
                values: new object[] { 13, "Sørlandet sykehus HF", 2 });

            migrationBuilder.InsertData(
                table: "Unit",
                columns: new[] { "Id", "Name", "Version" },
                values: new object[] { 14, "Vestre Viken HF", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Version" },
                values: new object[] { 1, "Alice", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Version" },
                values: new object[] { 2, "Bob", 2 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Version" },
                values: new object[] { 3, "Eve", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UnitId",
                table: "UserRoles",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
