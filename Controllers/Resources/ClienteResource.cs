using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VetS.Controllers.Resources
{
    public class ClienteResource
    {
        public int? Id { get; set; }

        public ContactoResource Contacto { get; set; }
        public string DNI { get; set; }
        public DateTime Actualizacion { get; set; }
        public int MascotaId { get; set; }
        public ICollection<int> Mascotas { get; set; }

        public ClienteResource()
        {
            Mascotas = new Collection<int>();
        }

    }
}
