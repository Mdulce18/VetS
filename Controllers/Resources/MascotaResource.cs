using System;
using System.ComponentModel.DataAnnotations;

namespace VetS.Controllers.Resources
{
    public class MascotaResource
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        public int AnimalId { get; set; }

        [Required]
        public int RazaId { get; set; }

        public DateTime FechaNacimiento { get; set; }
    }
}
