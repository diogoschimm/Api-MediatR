using ApiSample.Core.DomainObjects;
using System.Collections.Generic;

namespace ApiSample.Core.Contracts.Querys
{
    public interface IClienteQuery
    {
        IEnumerable<Cliente> GetAll();
        Cliente Get(int id);
    }
}
