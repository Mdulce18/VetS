using Microsoft.EntityFrameworkCore.Migrations;

namespace VetS.Data.Migrations
{
    public partial class Cliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mascotas_Razas_RazaId",
                table: "Mascotas");

            migrationBuilder.DropForeignKey(
                name: "FK_Razas_Animales_AnimalId",
                table: "Razas");

            migrationBuilder.AlterColumn<int>(
                name: "RazaId",
                table: "Mascotas",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Mascotas",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(maxLength: 50, nullable: false),
                    Direccion = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    DNI = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Mascotas_Razas_RazaId",
                table: "Mascotas",
                column: "RazaId",
                principalTable: "Razas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Razas_Animales_AnimalId",
                table: "Razas",
                column: "AnimalId",
                principalTable: "Animales",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mascotas_Clientes_ClienteId",
                table: "Mascotas");

            migrationBuilder.DropForeignKey(
                name: "FK_Mascotas_Razas_RazaId",
                table: "Mascotas");

            migrationBuilder.DropForeignKey(
                name: "FK_Razas_Animales_AnimalId",
                table: "Razas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Mascotas_ClienteId",
                table: "Mascotas");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Mascotas");

            migrationBuilder.AlterColumn<int>(
                name: "RazaId",
                table: "Mascotas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Mascotas_Razas_RazaId",
                table: "Mascotas",
                column: "RazaId",
                principalTable: "Razas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Razas_Animales_AnimalId",
                table: "Razas",
                column: "AnimalId",
                principalTable: "Animales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
