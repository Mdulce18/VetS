using System.ComponentModel.DataAnnotations;

namespace VetS.Core.Models
{
    public class TipoTurno
    {
        public int Id { get; set; }

        [Required]
        [StringLength(75)]
        public string Descripcion { get; set; }
    }
}
