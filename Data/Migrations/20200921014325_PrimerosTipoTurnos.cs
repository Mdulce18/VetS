using Microsoft.EntityFrameworkCore.Migrations;

namespace VetS.Data.Migrations
{
    public partial class PrimerosTipoTurnos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO TipoTurno (Descripcion) VALUES ('Clínica')");
            migrationBuilder.Sql("INSERT INTO TipoTurno (Descripcion) VALUES ('Cirugía')");
            migrationBuilder.Sql("INSERT INTO TipoTurno (Descripcion) VALUES ('Peluquería')");
            migrationBuilder.Sql("INSERT INTO TipoTurno (Descripcion) VALUES ('Baño')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM TipoTurno WHERE Descripcion IN ('Clínica','Cirugía','Peluquería', 'Baño')");
        }
    }
}
