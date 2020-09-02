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
            CreateMap<Cliente, ClienteResource>()
                .ForMember(cr => cr.Contacto, opt => opt.MapFrom(c => new ContactoResource { Nombre = c.Nombre, Apellido = c.Apellido, Telefono = c.Telefono, Direccion = c.Direccion, Email = c.Email }));
            CreateMap(typeof(QueryResult<>), typeof(QueryResultResource<>));
            CreateMap<Animal, AnimalResource>();
            CreateMap<Raza, RazaResource>();
            CreateMap<Mascota, SaveMascotaResource>();
            CreateMap<Mascota, MascotaResource>()
                .ForMember(mr => mr.Animal, opt => opt.MapFrom(m => new AnimalResource { Id = m.AnimalId, Nombre = m.Animal.Nombre, Razas = { new RazaResource { Id = m.RazaId, Nombre = m.Raza.Nombre } } }));


            //API a Dominio
            CreateMap<ClienteResource, Cliente>()
                .ForMember(c => c.Id, opt => opt.Ignore())
                .ForMember(c => c.Nombre, opt => opt.MapFrom(cr => cr.Contacto.Nombre))
                .ForMember(c => c.Apellido, opt => opt.MapFrom(cr => cr.Contacto.Apellido))
                .ForMember(c => c.Telefono, opt => opt.MapFrom(cr => cr.Contacto.Telefono))
                .ForMember(c => c.Direccion, opt => opt.MapFrom(cr => cr.Contacto.Direccion))
                .ForMember(c => c.Email, opt => opt.MapFrom(cr => cr.Contacto.Email));

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
