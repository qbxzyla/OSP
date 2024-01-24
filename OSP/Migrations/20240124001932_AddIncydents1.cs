using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OSP.Migrations
{
    public partial class AddIncydents1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DriveId",
                table: "Incidents",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_DriveId",
                table: "Incidents",
                column: "DriveId");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_Drive_DriveId",
                table: "Incidents",
                column: "DriveId",
                principalTable: "Drive",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_Drive_DriveId",
                table: "Incidents");

            migrationBuilder.DropIndex(
                name: "IX_Incidents_DriveId",
                table: "Incidents");

            migrationBuilder.DropColumn(
                name: "DriveId",
                table: "Incidents");
        }
    }
}
