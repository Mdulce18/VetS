using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace VetS.Models
{
    public class Animal
    {
        public int Id { get; set; }

        [Required]
        [StringLength(70)]
        public string Nombre { get; set; }
        public ICollection<Raza> Razas { get; set; }

        public Animal()
        {
            Razas = new Collection<Raza>();
        }
    }
}
