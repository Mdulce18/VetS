using Microsoft.EntityFrameworkCore.Migrations;

namespace VetS.Data.Migrations
{
    public partial class CambiosModeloCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KeyValuePairResource");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Mascotas",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "KeyValuePairResource",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyValuePairResource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KeyValuePairResource_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KeyValuePairResource_ClienteId",
                table: "KeyValuePairResource",
                column: "ClienteId");
        }
    }
}
