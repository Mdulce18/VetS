using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VetS.Controllers.Resources
{
    public class ClienteResource
    {
        public int Id { get; set; }

        public ContactoResource Contacto { get; set; }
        public string DNI { get; set; }
        public ICollection<MascotaResource> Mascotas { get; set; }

        public ClienteResource()
        {
            Mascotas = new Collection<MascotaResource>();
        }

    }
}
