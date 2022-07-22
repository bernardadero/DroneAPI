using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DroneAPI.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<string>(type: "varchar(100)", nullable: false),
                    model = table.Column<int>(type: "int", nullable: false),
                    WeightLimit = table.Column<decimal>(type: "decimal", nullable: false),
                    BatteryCapacity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drone", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drone");
        }
    }
}
