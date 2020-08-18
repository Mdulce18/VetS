using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetS.Controllers.Resources;
using VetS.Models;

namespace VetS.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Animal, AnimalResource>();
            CreateMap<Raza, RazaResource>();
        }
    }
}
