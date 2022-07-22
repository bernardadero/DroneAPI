using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DroneAPI.Migrations
{
    public partial class ModificatinOnLoadedMedication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BatteryLevelEventLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PreviousBatteryLevel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentBatteryLevel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LogTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatteryLevelEventLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicationModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    WeightLimit = table.Column<decimal>(type: "decimal", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoadedMedicineModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateLoaded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DroneId = table.Column<int>(type: "int", nullable: false),
                    medicationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoadedMedicineModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoadedMedicineModel_Drone_DroneId",
                        column: x => x.DroneId,
                        principalTable: "Drone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoadedMedicineModel_MedicationModel_medicationId",
                        column: x => x.medicationId,
                        principalTable: "MedicationModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoadedMedicineModel_DroneId",
                table: "LoadedMedicineModel",
                column: "DroneId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadedMedicineModel_medicationId",
                table: "LoadedMedicineModel",
                column: "medicationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BatteryLevelEventLog");

            migrationBuilder.DropTable(
                name: "LoadedMedicineModel");

            migrationBuilder.DropTable(
                name: "MedicationModel");
        }
    }
}
