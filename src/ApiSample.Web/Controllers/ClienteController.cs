using ApiSample.Core.Contracts.Querys;
using ApiSample.Core.DomainObjects;
using ApiSample.Core.Handlers.Commands.Cadastros;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiSample.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IClienteQuery _clienteQuery;

        public ClienteController(IMediator mediator, IClienteQuery clienteQuery)
        {
            this._mediator = mediator;
            this._clienteQuery = clienteQuery;
        }

        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            return _clienteQuery.GetAll();
        }

        [HttpGet("{id}")]
        public Cliente Get(int id)
        {
            return _clienteQuery.Get(id);
        }

        [HttpPost]
        public async Task Post([FromBody] CriarClienteCommand criarClienteCommand)
        {
            await _mediator.Send(criarClienteCommand);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AlterarClienteCommand alterarClienteCommand)
        {
            if (id != alterarClienteCommand.IdCliente)
                return BadRequest("Inconsistência nos dados informados, o id da rota deve ser igual ao id do corpo da requisição");

            await _mediator.Send(alterarClienteCommand);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _mediator.Send(new ExcluirClienteCommand() { IdCliente = id });
        }
    }
}
