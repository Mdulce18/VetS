using System;
using System.ComponentModel.DataAnnotations;

namespace VetS.Models
{#
    public class Mascota
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }
        public int RazaId { get; set; }

        public DateTime FechaNacimiento { get; set; }
        public DateTime Actualizacion { get; set; }

    }
}
