using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VetS.Controllers.Resources;
using VetS.Core;
using VetS.Core.Models;

namespace VetS.Controllers
{
    [Route("/api/historias")]
    public class HistoriasClinicasController : Controller
    {
        private readonly IMapper mapper;
        private readonly IHistoriaClinicaRepository historiaClinicaRepository;
        private readonly IMascotaRepository mascotaRepository;
        private readonly IUnitOfWork unitOfWork;

        public HistoriasClinicasController(IMapper mapper,
            IHistoriaClinicaRepository historiaClinicaRepository,
            IMascotaRepository mascotaRepository,
            IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.historiaClinicaRepository = historiaClinicaRepository;
            this.mascotaRepository = mascotaRepository;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]

        public async Task<IActionResult> CrearHistoria([FromBody] HistoriaClinicaResource historiaClinicaResource)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var mascota = await mascotaRepository.GetMascota(historiaClinicaResource.MascotaId);
            var historia = mapper.Map<HistoriaClinicaResource, HistoriaClinica>(historiaClinicaResource);

            historia.Fecha = DateTime.Now;
            mascota.TieneHistoriaClinica = true;

            historiaClinicaRepository.Add(historia);
            await unitOfWork.CompleteAsync();

            var historiaCreada = await historiaClinicaRepository.GetHistoria(historia.Id);
            var resultado = mapper.Map<HistoriaClinica, HistoriaClinicaResource>(historiaCreada);

            return Ok(resultado);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> TraerHistoria(int id)
        {
            var historia = await historiaClinicaRepository.GetHistoria(id);

            if (historia == null)
                return NotFound();

            var historiaResource = mapper.Map<HistoriaClinica, HistoriaClinicaResource>(historia);

            return Ok(historiaResource);

        }

        [HttpGet("mascota/{mascotaId}")]

        public async Task<IEnumerable<HistoriaClinicaResource>> TraerHistoriasMascota(int mascotaId)
        {
            var historias = await historiaClinicaRepository.GetListaHistorias(mascotaId);

            return mapper.Map<IEnumerable<HistoriaClinica>, IEnumerable<HistoriaClinicaResource>>(historias);
        }
    }
}
