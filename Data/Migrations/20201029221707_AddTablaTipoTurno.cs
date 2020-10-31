using Microsoft.EntityFrameworkCore.Migrations;

namespace VetS.Data.Migrations
{
    public partial class AddTablaTipoTurno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_TipoTurno_TipoTurnoId",
                table: "Turnos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoTurno",
                table: "TipoTurno");

            migrationBuilder.RenameTable(
                name: "TipoTurno",
                newName: "TipoTurnos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoTurnos",
                table: "TipoTurnos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_TipoTurnos_TipoTurnoId",
                table: "Turnos",
                column: "TipoTurnoId",
                principalTable: "TipoTurnos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_TipoTurnos_TipoTurnoId",
                table: "Turnos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoTurnos",
                table: "TipoTurnos");

            migrationBuilder.RenameTable(
                name: "TipoTurnos",
                newName: "TipoTurno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoTurno",
                table: "TipoTurno",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_TipoTurno_TipoTurnoId",
                table: "Turnos",
                column: "TipoTurnoId",
                principalTable: "TipoTurno",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
