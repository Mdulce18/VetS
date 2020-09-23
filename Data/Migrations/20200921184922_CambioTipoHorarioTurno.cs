using Microsoft.EntityFrameworkCore.Migrations;

namespace VetS.Data.Migrations
{
    public partial class CambioTipoHorarioTurno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Horario",
                table: "Turnos",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Horario",
                table: "Turnos",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10);
        }
    }
}
