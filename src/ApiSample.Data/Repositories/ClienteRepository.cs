using ApiSample.Core.Contracts.Repositories;
using ApiSample.Core.DomainObjects;
using ApiSample.Data.Contexts;
using ApiSample.Data.Repositories.Bases;
using System.Threading.Tasks;

namespace ApiSample.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(ApiSampleContext apiSampleContext)
            : base(apiSampleContext) { }
         
        public Task Add(Cliente cliente) => SaveEntity(cliente);
        public Task Delete(Cliente cliente) => DeleteEntity(cliente);
        public Task Update(Cliente cliente) => UpdateEntity(cliente);
    }
}
