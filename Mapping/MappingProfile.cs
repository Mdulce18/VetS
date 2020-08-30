using AutoMapper;
using VetS.Controllers.Resources;
using VetS.Core.Models;

namespace VetS.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Dominio a API
            CreateMap<Animal, AnimalResource>();
            CreateMap<Raza, RazaResource>();
            CreateMap<Mascota, SaveMascotaResource>();
            CreateMap<Mascota, MascotaResource>()
                .ForMember(mr => mr.Animal, opt => opt.MapFrom(m => new AnimalResource { Id = m.AnimalId, Nombre = m.Animal.Nombre, Razas = { new RazaResource { Id = m.RazaId, Nombre = m.Raza.Nombre } } }));


            //API a Dominio
            CreateMap<MascotaQueryResource, MascotaQuery>();
            CreateMap<SaveMascotaResource, Mascota>()
                .ForMember(m => m.Id, opt => opt.Ignore());
            CreateMap<RazaResource, Raza>();
            CreateMap<AnimalResource, Animal>();
            CreateMap<MascotaResource, Mascota>()
            .ForMember(m => m.AnimalId, opt => opt.MapFrom(mr => mr.Animal.Id))
            .ForMember(m => m.RazaId, opt => opt.MapFrom(mr => mr.Raza.Id));


        }
    }
}
