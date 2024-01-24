using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OSP.Migrations
{
    public partial class AddIncydents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drive_Drive_DriveId",
                table: "Drive");

            migrationBuilder.DropIndex(
                name: "IX_Drive_DriveId",
                table: "Drive");

            migrationBuilder.DropColumn(
                name: "DriveId",
                table: "Drive");

            migrationBuilder.AddColumn<int>(
                name: "DriveId",
                table: "Firefighter",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IncidentId",
                table: "Drive",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IncydentId",
                table: "Drive",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Incidents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PlaceName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    DataS = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Firefighter_DriveId",
                table: "Firefighter",
                column: "DriveId");

            migrationBuilder.CreateIndex(
                name: "IX_Drive_IncidentId",
                table: "Drive",
                column: "IncidentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drive_Incidents_IncidentId",
                table: "Drive",
                column: "IncidentId",
                principalTable: "Incidents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Firefighter_Drive_DriveId",
                table: "Firefighter",
                column: "DriveId",
                principalTable: "Drive",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drive_Incidents_IncidentId",
                table: "Drive");

            migrationBuilder.DropForeignKey(
                name: "FK_Firefighter_Drive_DriveId",
                table: "Firefighter");

            migrationBuilder.DropTable(
                name: "Incidents");

            migrationBuilder.DropIndex(
                name: "IX_Firefighter_DriveId",
                table: "Firefighter");

            migrationBuilder.DropIndex(
                name: "IX_Drive_IncidentId",
                table: "Drive");

            migrationBuilder.DropColumn(
                name: "DriveId",
                table: "Firefighter");

            migrationBuilder.DropColumn(
                name: "IncidentId",
                table: "Drive");

            migrationBuilder.DropColumn(
                name: "IncydentId",
                table: "Drive");

            migrationBuilder.AddColumn<int>(
                name: "DriveId",
                table: "Drive",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drive_DriveId",
                table: "Drive",
                column: "DriveId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drive_Drive_DriveId",
                table: "Drive",
                column: "DriveId",
                principalTable: "Drive",
                principalColumn: "Id");
        }
    }
}
