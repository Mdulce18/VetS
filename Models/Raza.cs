using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VetS.Models
{
    [Table("Razas")]
    public class Raza
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public String Nombre { get; set; }
        public Animal Animal { get; set; }
        public int AnimalId { get; set; }
    }
}
