using ApiSample.Core.Handlers.Commands.Bases;
using ApiSample.Core.Handlers.Dtos.Requests;
using ApiSample.Core.Handlers.Dtos.Responses;
using System.Collections.Generic;

namespace ApiSample.Core.Handlers.Commands.Vendas
{
    public class CriarVendaCommand : Command<VendaCommandResult>
    {
        public List<ItemVendaRequest> Itens { get; set; }

        public override bool Validar()
        {
            return true;
        }
    }
}
