using ApiSample.Core.Handlers.Commands.Vendas;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiSample.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VendaController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CriarVendaCommand criarVendaCommand)
        {
            var result = await _mediator.Send(criarVendaCommand);

            return Ok(result);
        }
    }
}
