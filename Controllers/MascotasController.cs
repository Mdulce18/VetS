using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VetS.Data;
using VetS.Models;

namespace VetS.Controllers.Resources
{
    [Route("api/mascotas")]
    public class MascotasController : Controller
    {
        private readonly IMapper mapper;
        private readonly VetSDbContext vetSDbContext;

        public MascotasController(IMapper mapper, VetSDbContext vetSDbContext)
        {
            this.mapper = mapper;
            this.vetSDbContext = vetSDbContext;
        }



        [HttpPost]
        public async Task<IActionResult> CrearMascota([FromBody] MascotaResource mascotaResource)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            //var raza = await vetSDbContext.Razas.FindAsync(mascotaResource.RazaId);
            //if (raza == null)
            //{
            //    ModelState.AddModelError("RazaId", "RazaId invalida.");
            //    return BadRequest(ModelState);
            //}

            var mascota = mapper.Map<MascotaResource, Mascota>(mascotaResource);
            mascota.Actualizacion = DateTime.Now;

            vetSDbContext.Mascotas.Add(mascota);
            await vetSDbContext.SaveChangesAsync();

            return Ok(mascota);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarMascota(int id, [FromBody] MascotaResource mascotaResource)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var mascota = await vetSDbContext.Mascotas.FindAsync(id);

            if (mascota == null)
                return NotFound();

            mascota = mapper.Map<MascotaResource, Mascota>(mascotaResource, mascota);
            mascota.Actualizacion = DateTime.Now;

            await vetSDbContext.SaveChangesAsync();

            return Ok(mascota);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarMascota(int id)
        {
            var mascota = await vetSDbContext.Mascotas.FindAsync(id);

            if (mascota == null)
                return NotFound();

            vetSDbContext.Remove(mascota);
            await vetSDbContext.SaveChangesAsync();

            return Ok(id);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> TraerMascota(int id)
        {
            var mascota = await vetSDbContext.Mascotas.FindAsync(id);

            if (mascota == null)
                return NotFound();

            var mascotaResource = mapper.Map<Mascota, MascotaResource>(mascota);

            return Ok(mascotaResource);
        }
    }
}
