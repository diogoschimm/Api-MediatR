using ApiSample.Core.DomainObjects;
using System.Threading.Tasks;

namespace ApiSample.Core.Contracts.Repositories
{
    public interface IClienteRepository
    {
        Task Add(Cliente cliente);
        Task Update(Cliente cliente);
        Task Delete(Cliente cliente);
    }
}
