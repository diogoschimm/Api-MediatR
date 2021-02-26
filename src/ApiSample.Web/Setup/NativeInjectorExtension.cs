using ApiSample.Core.Contracts.Querys;
using ApiSample.Core.Contracts.Repositories;
using ApiSample.Core.Handlers.CommandHandlers;
using ApiSample.Core.Handlers.Commands.Cadastros;
using ApiSample.Core.Handlers.Commands.Vendas;
using ApiSample.Core.Handlers.Dtos.Responses;
using ApiSample.Data.Contexts;
using ApiSample.Data.Queries;
using ApiSample.Data.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiSample.Web.Setup
{
    public static class NativeInjectorExtension
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            AddQueries(services);
            AddRepositories(services);
            AddHandlers(services);

            services.AddMediatR(typeof(Startup));

            services.AddDbContext<ApiSampleContext>(options =>
                        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }

        private static void AddQueries(IServiceCollection services)
        {
            services.AddScoped<IClienteQuery, ClienteQuery>();
        }

        private static void AddRepositories(IServiceCollection services)
        { 
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IVendaRepository, VendaRepository>();
        }

        private static void AddHandlers(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<CriarClienteCommand, bool>, ClienteCommandHandler>();
            services.AddScoped<IRequestHandler<AlterarClienteCommand, bool>, ClienteCommandHandler>();
            services.AddScoped<IRequestHandler<ExcluirClienteCommand, bool>, ClienteCommandHandler>();

            services.AddScoped<IRequestHandler<CriarVendaCommand, VendaCommandResult>, VendaCommandHandler>();
        }
    }
}
