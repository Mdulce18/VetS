using System.ComponentModel.DataAnnotations;

namespace VetS.Controllers.Resources
{
    public class TipoTurnoResource
    {
        public int Id { get; set; }

        [Required]
        [StringLength(75)]
        public string Descripcion { get; set; }
    }
}
