using System;
using System.ComponentModel.DataAnnotations;

namespace VetS.Controllers.Resources
{
    public class TurnoResource
    {
        public int Id { get; set; }
        public int? ClienteId { get; set; }

        [Required]
        public DateTime Dia { get; set; }

        [Required]
        [StringLength(10)]
        public string Horario { get; set; }

        [Required]
        public int TipoTurnoId { get; set; }
        public string Observaciones { get; set; }
    }
}
