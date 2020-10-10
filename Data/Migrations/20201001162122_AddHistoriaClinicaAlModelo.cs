using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VetS.Data.Migrations
{
    public partial class AddHistoriaClinicaAlModelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistoriaClinicas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MascotaId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Contenido = table.Column<string>(nullable: false),
                    NombreVet = table.Column<string>(maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoriaClinicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoriaClinicas_Mascotas_MascotaId",
                        column: x => x.MascotaId,
                        principalTable: "Mascotas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoriaMascotas",
                columns: table => new
                {
                    HistoriaClinicaId = table.Column<int>(nullable: false),
                    MascotaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoriaMascotas", x => new { x.HistoriaClinicaId, x.MascotaId });
                    table.ForeignKey(
                        name: "FK_HistoriaMascotas_HistoriaClinicas_HistoriaClinicaId",
                        column: x => x.HistoriaClinicaId,
                        principalTable: "HistoriaClinicas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HistoriaMascotas_Mascotas_MascotaId",
                        column: x => x.MascotaId,
                        principalTable: "Mascotas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoriaClinicas_MascotaId",
                table: "HistoriaClinicas",
                column: "MascotaId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoriaMascotas_MascotaId",
                table: "HistoriaMascotas",
                column: "MascotaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoriaMascotas");

            migrationBuilder.DropTable(
                name: "HistoriaClinicas");
        }
    }
}
