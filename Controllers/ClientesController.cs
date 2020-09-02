using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
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

        public ClientesController(IMapper mapper, IClienteRepository repository, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public IClienteRepository Repository { get; }

        [HttpPost()]
        public async Task<IActionResult> CrearCliente([FromBody] ClienteResource clienteResource)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var cliente = mapper.Map<ClienteResource, Cliente>(clienteResource);
            cliente.Actualizacion = DateTime.Now;

            repository.Add(cliente);
            await unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> TraerClientes(int id)
        {
            var cliente = await repository.GetCliente(id);
            if (cliente == null)
                return NotFound();

            var resultado = mapper.Map<Cliente, ClienteResource>(cliente);

            return Ok(resultado);
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarCliente(int id, [FromBody] ClienteResource clienteResource)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var cliente = await repository.GetCliente(id);
            if (cliente == null)
                return NotFound();

            cliente = mapper.Map<ClienteResource, Cliente>(clienteResource, cliente);
            cliente.Actualizacion = DateTime.Now;

            await unitOfWork.CompleteAsync();

            cliente = await repository.GetCliente(cliente.Id);
            if (cliente == null)
                return NotFound();

            var resultado = mapper.Map<Cliente, ClienteResource>(cliente);

            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarCliente(int id)
        {
            var cliente = await repository.GetCliente(id);
            if (cliente == null)
                return NotFound();

            repository.Remove(cliente);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }
    }
}
