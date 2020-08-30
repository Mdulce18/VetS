using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VetS.Core;
using VetS.Core.Models;

namespace VetS.Controllers.Resources
{
    [Route("api/mascotas")]
    public class MascotasController : Controller
    {
        private readonly IMapper mapper;
        private readonly IMascotaRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public MascotasController(IMapper mapper, IMascotaRepository repository, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }



        [HttpPost]
        public async Task<IActionResult> CrearMascota([FromBody] SaveMascotaResource mascotaResource)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var mascota = mapper.Map<SaveMascotaResource, Mascota>(mascotaResource);
            mascota.Actualizacion = DateTime.Now;

            repository.Add(mascota);
            await unitOfWork.CompleteAsync();

            mascota = await repository.GetMascota(mascota.Id);

            var resultado = mapper.Map<Mascota, MascotaResource>(mascota);

            return Ok(resultado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarMascota(int id, [FromBody] SaveMascotaResource mascotaResource)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var mascota = await repository.GetMascota(id);

            if (mascota == null)
                return NotFound();

            mascota = mapper.Map<SaveMascotaResource, Mascota>(mascotaResource, mascota);
            mascota.Actualizacion = DateTime.Now;

            await unitOfWork.CompleteAsync();

            mascota = await repository.GetMascota(mascota.Id);

            var resultado = mapper.Map<Mascota, MascotaResource>(mascota);

            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarMascota(int id)
        {
            var mascota = await repository.GetMascota(id, IncludeRelated: false);

            if (mascota == null)
                return NotFound();

            repository.Remove(mascota);
            await unitOfWork.CompleteAsync();

            return Ok(id);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> TraerMascota(int id)
        {
            var mascota = await repository.GetMascota(id);

            if (mascota == null)
                return NotFound();

            var mascotaResource = mapper.Map<Mascota, MascotaResource>(mascota);

            return Ok(mascotaResource);
        }

        [HttpGet]
        public async Task<IEnumerable<MascotaResource>> TodasLasMascotas(MascotaQueryResource filtroResource)
        {
            var filtro = mapper.Map<MascotaQueryResource, MascotaQuery>(filtroResource);
            var mascotas = await repository.GetTodasLasMascotas(filtro);

            return mapper.Map<IEnumerable<Mascota>, IEnumerable<MascotaResource>>(mascotas);
        }
    }
}
