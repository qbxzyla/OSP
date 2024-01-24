using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OSP.Migrations
{
    public partial class AddCarsandCarsInAction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IncydentId",
                table: "Drive");

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Liters = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarInAction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IncidentId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarInAction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarInAction_Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarInAction_Incidents_IncidentId",
                        column: x => x.IncidentId,
                        principalTable: "Incidents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarInAction_CarId",
                table: "CarInAction",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarInAction_IncidentId",
                table: "CarInAction",
                column: "IncidentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarInAction");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.AddColumn<int>(
                name: "IncydentId",
                table: "Drive",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
