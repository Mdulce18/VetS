using Microsoft.EntityFrameworkCore.Migrations;

namespace VetS.Data.Migrations
{
    public partial class AddObservacionesTurno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Observaciones",
                table: "Turnos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observaciones",
                table: "Turnos");
        }
    }
}
