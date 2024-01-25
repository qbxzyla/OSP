using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OSP.Migrations
{
    public partial class AddNewRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "Crews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IncidentId",
                table: "Crews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Crews_DriverId",
                table: "Crews",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Crews_IncidentId",
                table: "Crews",
                column: "IncidentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Crews_Firefighter_DriverId",
                table: "Crews",
                column: "DriverId",
                principalTable: "Firefighter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Crews_Incidents_IncidentId",
                table: "Crews",
                column: "IncidentId",
                principalTable: "Incidents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crews_Firefighter_DriverId",
                table: "Crews");

            migrationBuilder.DropForeignKey(
                name: "FK_Crews_Incidents_IncidentId",
                table: "Crews");

            migrationBuilder.DropIndex(
                name: "IX_Crews_DriverId",
                table: "Crews");

            migrationBuilder.DropIndex(
                name: "IX_Crews_IncidentId",
                table: "Crews");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Crews");

            migrationBuilder.DropColumn(
                name: "IncidentId",
                table: "Crews");
        }
    }
}
