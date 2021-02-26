using ApiSample.Core.DomainObjects;
using System.Threading.Tasks;

namespace ApiSample.Core.Contracts.Repositories
{
    public interface  IVendaRepository
    {
        Task Add(Venda venda); 
    }
}
