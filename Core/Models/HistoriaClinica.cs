using System;
using System.ComponentModel.DataAnnotations;

namespace VetS.Core.Models
{
    public class HistoriaClinica
    {
        public int Id { get; set; }

        [Required]
        public int MascotaId { get; set; }
        public Mascota Mascota { get; set; }
        public DateTime Fecha { get; set; }

        [Required]
        public string Contenido { get; set; }
        [Required]
        [StringLength(75)]
        public string NombreVet { get; set; }
    }
}
