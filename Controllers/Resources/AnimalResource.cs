using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VetS.Controllers.Resources
{
    public class AnimalResource
    {
        public int Id { get; set; }

        public string Nombre { get; set; }
        public ICollection<RazaResource> Razas { get; set; }

        public AnimalResource()
        {
            Razas = new Collection<RazaResource>();
        }
    }
}
