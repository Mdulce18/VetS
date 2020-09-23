using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VetS.Data.Migrations
{
    public partial class AddTurnosAlModelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoTurno",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTurno", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turnos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(nullable: true),
                    Dia = table.Column<DateTime>(nullable: false),
                    Horario = table.Column<byte>(nullable: false),
                    TipoTurnoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turnos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Turnos_TipoTurno_TipoTurnoId",
                        column: x => x.TipoTurnoId,
                        principalTable: "TipoTurno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_ClienteId",
                table: "Turnos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_TipoTurnoId",
                table: "Turnos",
                column: "TipoTurnoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Turnos");

            migrationBuilder.DropTable(
                name: "TipoTurno");
        }
    }
}
