using System.ComponentModel.DataAnnotations;

namespace VetS.Controllers.Resources
{
    public class ContactoResource
    {
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Apellido { get; set; }

        [Required]
        [StringLength(50)]
        public string Telefono { get; set; }
        public string Direccion { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }
    }
}
