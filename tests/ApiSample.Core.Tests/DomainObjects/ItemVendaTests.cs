using ApiSample.Core.DomainObjects;
using Xunit;

namespace ApiSample.Core.Tests.DomainObjects
{
    public class ItemVendaTests
    {
        [Fact]
        [Trait("Itens de Venda", "Criação de Item de Venda")]
        public void ItemVenda_CriarItemVenda_DeveRetornarSucessoPreenchimentoDosCampos()
        {
            // Arrange
            var descricao = "Bola de Futebol";
            var qtd = 1;
            var valorUnitario = 20.0M;

            // Act
            var itemVenda = new ItemVenda(descricao, qtd, valorUnitario);

            // Assert 
            Assert.Equal(descricao, itemVenda.Descricao);
            Assert.Equal(qtd, itemVenda.Qtd);
            Assert.Equal(valorUnitario, itemVenda.ValorUnitario);
        }

        [Fact]
        [Trait("Itens de Venda", "Criação de Item de Venda")]
        public void ItemVenda_CriarItemVenda_ValorTotalDeveSerValido()
        {
            // Arrange
            var descricao = "Bola de Futebol";
            var qtd = 2;
            var valorUnitario = 20.0M;

            // Act
            var itemVenda = new ItemVenda(descricao, qtd, valorUnitario);

            // Assert
            var valorEsperado = qtd * valorUnitario;
            Assert.Equal(valorEsperado, itemVenda.ObterTotal());
        }
    }
}
