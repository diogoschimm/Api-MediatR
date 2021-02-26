using ApiSample.Core.Contracts.Querys;
using ApiSample.Core.Contracts.Repositories;
using ApiSample.Core.DomainObjects;
using ApiSample.Core.Handlers.Commands.Cadastros;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApiSample.Core.Handlers.CommandHandlers
{
    public class ClienteCommandHandler :
        IRequestHandler<CriarClienteCommand, bool>,
        IRequestHandler<AlterarClienteCommand, bool>,
        IRequestHandler<ExcluirClienteCommand, bool>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteQuery _clienteQuery;

        public ClienteCommandHandler(IClienteRepository clienteRepository, IClienteQuery clienteQuery)
        {
            this._clienteRepository = clienteRepository;
            this._clienteQuery = clienteQuery;
        }

        public async Task<bool> Handle(CriarClienteCommand request, CancellationToken cancellationToken)
        {
            if (!request.Validar()) return false;

            var cliente = new Cliente(request.NomeCliente);

            await this._clienteRepository.Add(cliente);

            return true;
        }

        public async Task<bool> Handle(AlterarClienteCommand request, CancellationToken cancellationToken)
        {
            if (!request.Validar()) return false;

            var cliente = this._clienteQuery.Get(request.IdCliente);
            cliente.MudarNome(request.NomeCliente);

            await this._clienteRepository.Update(cliente);

            return true;
        }

        public async Task<bool> Handle(ExcluirClienteCommand request, CancellationToken cancellationToken)
        {
            if (!request.Validar()) return false;

            var cliente = this._clienteQuery.Get(request.IdCliente);
            await this._clienteRepository.Delete(cliente);

            return true;
        }
    }
}
