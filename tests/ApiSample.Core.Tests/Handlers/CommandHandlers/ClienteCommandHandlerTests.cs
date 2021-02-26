using ApiSample.Core.Handlers.CommandHandlers;
using ApiSample.Core.Handlers.Commands.Cadastros;
using FluentAssertions;
using MediatR;
using Moq;
using Moq.AutoMock;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ApiSample.Core.Tests.Handlers.CommandHandlers
{
    public class ClienteCommandHandlerTests
    {
        [Fact]
        [Trait("Cliente Command Handler", "Adicionar Cliente")]
        public async Task ClienteCommandHandler_AdicionarCliente_RetornarSucesso()
        {
            // Arrange 
            var autoMocker = new AutoMocker();
            var mediator = autoMocker.CreateInstance<ClienteCommandHandler>();

            autoMocker.GetMock<IRequestHandler<CriarClienteCommand, bool>>()
                .Setup(c => c.Handle(It.IsAny<CriarClienteCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(true));

            var command = new CriarClienteCommand
            {
                NomeCliente = "Diogo Schimmelpfennig"
            };

            // Act
            var result = await mediator.Handle(command, CancellationToken.None);

            // Assert
            result.Should().BeTrue();
        }
    }
}
