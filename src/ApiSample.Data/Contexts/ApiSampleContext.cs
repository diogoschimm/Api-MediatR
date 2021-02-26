using ApiSample.Core.DomainObjects;
using Microsoft.EntityFrameworkCore;

namespace ApiSample.Data.Contexts
{
    public class ApiSampleContext : DbContext
    { 
        public ApiSampleContext(DbContextOptions<ApiSampleContext> options) 
            : base(options) {  }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<ItemVenda> ItemVenda { get; set; } 
    }
}
