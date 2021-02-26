using ApiSample.Core.Contracts.Repositories;
using ApiSample.Core.DomainObjects;
using ApiSample.Data.Contexts;
using ApiSample.Data.Repositories.Bases;
using System.Threading.Tasks;

namespace ApiSample.Data.Repositories
{
    public class VendaRepository : RepositoryBase<Venda>, IVendaRepository
    {
        public VendaRepository(ApiSampleContext apiSampleContext) 
            : base(apiSampleContext) { }

        public Task Add(Venda venda)
        {
            this.SaveEntity(venda);

            foreach (var item in venda.Itens)
                this.SaveEntity(item);

            return Task.CompletedTask;
        }
    }
}
