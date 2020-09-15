using Microsoft.EntityFrameworkCore.Migrations;

namespace VetS.Data.Migrations
{
    public partial class AddClienteMascotaAlModelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mascotas_Clientes_ClienteId",
                table: "Mascotas");

            migrationBuilder.DropIndex(
                name: "IX_Mascotas_ClienteId",
                table: "Mascotas");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Mascotas");

            migrationBuilder.CreateTable(
                name: "ClienteMascotas",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false),
                    MascotaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteMascotas", x => new { x.ClienteId, x.MascotaId });
                    table.ForeignKey(
                        name: "FK_ClienteMascotas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClienteMascotas_Mascotas_MascotaId",
                        column: x => x.MascotaId,
                        principalTable: "Mascotas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClienteMascotas_MascotaId",
                table: "ClienteMascotas",
                column: "MascotaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClienteMascotas");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Mascotas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_ClienteId",
                table: "Mascotas",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mascotas_Clientes_ClienteId",
                table: "Mascotas",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
