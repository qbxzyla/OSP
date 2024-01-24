using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OSP.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Firefighter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataS = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Driver = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firefighter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drive",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirefighterId = table.Column<int>(type: "int", nullable: false),
                    DriveId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drive", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drive_Drive_DriveId",
                        column: x => x.DriveId,
                        principalTable: "Drive",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Drive_Firefighter_FirefighterId",
                        column: x => x.FirefighterId,
                        principalTable: "Firefighter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drive_DriveId",
                table: "Drive",
                column: "DriveId");

            migrationBuilder.CreateIndex(
                name: "IX_Drive_FirefighterId",
                table: "Drive",
                column: "FirefighterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drive");

            migrationBuilder.DropTable(
                name: "Firefighter");
        }
    }
}
