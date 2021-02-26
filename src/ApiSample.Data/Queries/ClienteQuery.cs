using ApiSample.Core.Contracts.Querys;
using ApiSample.Core.DomainObjects;
using ApiSample.Data.Contexts;
using System.Collections.Generic;

namespace ApiSample.Data.Queries
{
    public class ClienteQuery : IClienteQuery
    {
        protected readonly ApiSampleContext _apiSampleContext;

        public ClienteQuery(ApiSampleContext apiSampleContext)
        {
            this._apiSampleContext = apiSampleContext;
        }

        public Cliente Get(int id)
        {
            return this._apiSampleContext.Clientes.Find(id);
        }

        public IEnumerable<Cliente> GetAll()
        {
            return this._apiSampleContext.Clientes;
        }
    }
}
