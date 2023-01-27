using EstacionamentoAlura.App.Modelos;
using Xunit;

namespace EstacionamentoAlura.Tests
{
    // Padrão dos Testes
    // Arrange -> Preparação do cenário necessário para invocar o método testado
    // Act -> Método a ser testado
    // Assert -> Verificação do resultado obtido após a execução do método testado

    public class VeiculoTests
    {
        [Fact]
        public void TestaVeiculoAcelerar()
        {
            // Arrange
            var veiculo = new Veiculo();

            // Act
            veiculo.Acelerar(10);

            // Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaVeiculoFrear()
        {
            // Arrange
            var veiculo = new Veiculo();

            // Act
            veiculo.Frear(10);

            // Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaTipoVeiculo()
        {
            //Arrange
            var veiculo = new Veiculo();

            //Act

            //Assert
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }
    }
}
