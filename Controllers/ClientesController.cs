using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using VetS.Controllers.Resources;
using VetS.Core;
using VetS.Core.Models;

namespace VetS.Controllers
{
    [Route("/api/clientes")]
    public class ClientesController : Controller
    {

        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IClienteRepository repository;
        private readonly IMascotaRepository mascotaRepository;

        public ClientesController(IMapper mapper, IClienteRepository repository, IMascotaRepository mascotaRepository, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.mascotaRepository = mascotaRepository;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost()]
        public async Task<IActionResult> CrearCliente([FromBody] ClienteResource clienteResource)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var cliente = mapper.Map<ClienteResource, Cliente>(clienteResource);
            cliente.Actualizacion = DateTime.Now;

            repository.Add(cliente);
            await unitOfWork.CompleteAsync();

            cliente = await repository.GetCliente(cliente.Id);

            var resultado = mapper.Map<Cliente, ClienteResource>(cliente);

            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> TraerClientes(int id)
        {
            var cliente = await repository.GetCliente(id);

            if (cliente == null)
                return NotFound();

            var clienteResource = mapper.Map<Cliente, ClienteResource>(cliente);

            return Ok(clienteResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarCliente(int id, [FromBody] ClienteResource clienteResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cliente = await repository.GetCliente(id);

            if (cliente == null)
                return NotFound();

            cliente = mapper.Map<ClienteResource, Cliente>(clienteResource, cliente);

            if (clienteResource.MascotaId > 0)
            {
                var mascota = await mascotaRepository.GetMascota(clienteResource.MascotaId);

                if (mascota == null)
                    return NotFound(mascota.Id);
                var clienteMascota = new ClienteMascota { ClienteId = cliente.Id, MascotaId = mascota.Id };

                if (!mascota.EstaAsignada)

                    cliente.Mascotas.Add(clienteMascota);

                else
                {
                    var removedMascota = cliente.Mascotas.Where(cm => cm.MascotaId == clienteResource.MascotaId).ToList();
                    foreach (var m in removedMascota)
                        cliente.Mascotas.Remove(m);
                }

                mascota.EstaAsignada = !mascota.EstaAsignada;

                cliente.Actualizacion = DateTime.Now;

                await unitOfWork.CompleteAsync();
            }
            cliente = await repository.GetCliente(cliente.Id);

            var resultado = mapper.Map<Cliente, ClienteResource>(cliente);

            return Ok(resultado);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarCliente(int id)
        {
            var cliente = await repository.GetCliente(id);
            if (cliente == null)
                return NotFound();

            var cantidad = cliente.Mascotas.Count();
            if (cantidad == 0)

                repository.Remove(cliente);

            else
            {
                var removedMascotas = cliente.Mascotas.ToList();
                foreach (var m in removedMascotas)
                {
                    var mascota = await mascotaRepository.GetMascota(m.MascotaId);
                    mascota.EstaAsignada = !mascota.EstaAsignada;
                }
            }

            repository.Remove(cliente);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }

        [HttpGet]
        public async Task<QueryResultResource<ClienteResource>> TraerClientes(ClienteQueryResource filtroResource)
        {
            var filtro = mapper.Map<ClienteQueryResource, ClienteQuery>(filtroResource);
            var queryResult = await repository.GetTodosLosClientess(filtro);

            return mapper.Map<QueryResult<Cliente>, QueryResultResource<ClienteResource>>(queryResult);
        }
        //public async Task<IEnumerable<ClienteResource>> TraerClientes()
        //{
        //    return await repository.GetClientes();

        //}

    }
}
