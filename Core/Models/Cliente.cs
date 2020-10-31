using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace VetS.Core.Models
{
    public class Cliente
    {
        public int Id { get; set; }

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

        [Required]
        [StringLength(20)]
        public string DNI { get; set; }
        public DateTime Actualizacion { get; set; }
        public ICollection<ClienteMascota> Mascotas { get; set; }

        public Cliente()
        {
            Mascotas = new Collection<ClienteMascota>();
        }
    }
}
