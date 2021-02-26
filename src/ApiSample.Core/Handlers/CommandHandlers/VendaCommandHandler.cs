using ApiSample.Core.Contracts.Repositories;
using ApiSample.Core.DomainObjects;
using ApiSample.Core.Handlers.Commands.Vendas;
using ApiSample.Core.Handlers.Dtos.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApiSample.Core.Handlers.CommandHandlers
{
    public class VendaCommandHandler :
        IRequestHandler<CriarVendaCommand, VendaCommandResult>
    {
        private readonly IVendaRepository _vendaRepository;

        public VendaCommandHandler(IVendaRepository vendaRepository)
        {
            this._vendaRepository = vendaRepository;
        }

        public async Task<VendaCommandResult> Handle(CriarVendaCommand request, CancellationToken cancellationToken)
        {
            request.Validar();

            var venda = new Venda();
            foreach (var item in request.Itens)
                venda.AdicionarItem(new ItemVenda(item.Descricao, item.Qtd, item.ValorUnitario));

            await _vendaRepository.Add(venda);

            return new VendaCommandResult(venda.Id);
        }
    }
}
