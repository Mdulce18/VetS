using Microsoft.EntityFrameworkCore.Migrations;

namespace VetS.Data.Migrations
{
    public partial class cambioNombrePropAsignada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "estaAsignada",
                table: "Mascotas",
                newName: "EstaAsignada");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EstaAsignada",
                table: "Mascotas",
                newName: "estaAsignada");
        }
    }
}
