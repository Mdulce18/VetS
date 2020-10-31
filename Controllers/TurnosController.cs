using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VetS.Controllers.Resources;
using VetS.Core;
using VetS.Core.Models;

namespace VetS.Controllers
{
    [Route("/api/turnos")]
    public class TurnosController : Controller
    {
        private readonly IMapper mapper;
        private readonly ITurnoRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public TurnosController(IMapper mapper, ITurnoRepository repository, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> CrearTurno([FromBody] TurnoResource turnoResource)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var turno = mapper.Map<TurnoResource, Turno>(turnoResource);

            repository.Add(turno);
            await unitOfWork.CompleteAsync();

            var resultado = await repository.GetTurno(turno.Id);

            var restmp = mapper.Map<Turno, TurnoResource>(resultado);

            return Ok(restmp);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> TraerTurno(int id)
        {
            var turno = await repository.GetTurno(id);

            if (turno == null)
                return NotFound();

            var resultado = mapper.Map<Turno, TurnoResource>(turno);
            return Ok(resultado);
        }

        [HttpGet("todos")]
        public async Task<IActionResult> TraerTodosLosTurnos()
        {
            var turnos = await repository.GetTodosLosTurnos();
            return Ok(turnos);
        }
        [HttpGet("tipos")]
        public async Task<IActionResult> TraerTiposDeTurnos()
        {
            var tipos = await repository.GetTipoDeTurnos();
            return Ok(tipos);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarTurno(int id, [FromBody] TurnoResource turnoResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var turno = await repository.GetTurno(id);

            if (turno == null)
                return NotFound();

            turno = mapper.Map<TurnoResource, Turno>(turnoResource, turno);

            await unitOfWork.CompleteAsync();

            var actualizacion = await repository.GetTurno(turno.Id);
            var resultado = mapper.Map<Turno, TurnoResource>(actualizacion);

            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarTurno(int id)
        {
            var turno = await repository.GetTurno(id);

            if (turno == null)
                return NotFound();

            repository.Remove(turno);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }
    }
}
