using Microsoft.EntityFrameworkCore.Migrations;

namespace VetS.Data.Migrations
{
    public partial class PrimerosRegistrosDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Animales (Nombre) VALUES ('Gato')");
            migrationBuilder.Sql("INSERT INTO Animales (Nombre) VALUES ('Perro')");
            migrationBuilder.Sql("INSERT INTO Animales (Nombre) VALUES ('Conejo')");

            migrationBuilder.Sql("INSERT INTO Razas (Nombre, AnimalId) VALUES ('Gato-Siames',(SELECT ID FROM Animales WHERE Nombre = 'Gato'))");
            migrationBuilder.Sql("INSERT INTO Razas (Nombre, AnimalId) VALUES ('Gato-Común europeo',(SELECT ID FROM Animales WHERE Nombre = 'Gato'))");
            migrationBuilder.Sql("INSERT INTO Razas (Nombre, AnimalId) VALUES ('Gato-Persa',(SELECT ID FROM Animales WHERE Nombre = 'Gato'))");

            migrationBuilder.Sql("INSERT INTO Razas (Nombre, AnimalId) VALUES ('Perro-Chihuahua',(SELECT ID FROM Animales WHERE Nombre = 'Perro'))");
            migrationBuilder.Sql("INSERT INTO Razas (Nombre, AnimalId) VALUES ('Perro-Golden retriever',(SELECT ID FROM Animales WHERE Nombre = 'Perro'))");
            migrationBuilder.Sql("INSERT INTO Razas (Nombre, AnimalId) VALUES ('Perro-Ovejero alemán',(SELECT ID FROM Animales WHERE Nombre = 'Perro'))");

            migrationBuilder.Sql("INSERT INTO Razas (Nombre, AnimalId) VALUES ('Conejo-Mariposa',(SELECT ID FROM Animales WHERE Nombre = 'Conejo'))");
            migrationBuilder.Sql("INSERT INTO Razas (Nombre, AnimalId) VALUES ('Conejo-Arlequin',(SELECT ID FROM Animales WHERE Nombre = 'Conejo'))");
            migrationBuilder.Sql("INSERT INTO Razas (Nombre, AnimalId) VALUES ('Conejo-Angora',(SELECT ID FROM Animales WHERE Nombre = 'Conejo'))");
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Animales WHERE Nombre IN ('Gato','Perro','Conejo')");
        }
    }
}
