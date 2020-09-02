using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VetS.Data.Migrations
{
    public partial class AddActualizacionCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Actualizacion",
                table: "Clientes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Actualizacion",
                table: "Clientes");
        }
    }
}
