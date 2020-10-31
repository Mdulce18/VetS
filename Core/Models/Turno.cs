using System;
using System.ComponentModel.DataAnnotations;

namespace VetS.Core.Models
{
    public class Turno
    {
        public int Id { get; set; }
        public int? ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [Required]
        public DateTime Dia { get; set; }

        [Required]
        public int TipoTurnoId { get; set; }
        public TipoTurno TipoTurno { get; set; }
        public string Observaciones { get; set; }
    }
}
