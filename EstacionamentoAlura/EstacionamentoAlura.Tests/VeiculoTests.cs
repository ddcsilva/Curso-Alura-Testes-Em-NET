using EstacionamentoAlura.App.Modelos;
using Xunit;

namespace EstacionamentoAlura.Tests
{
    // Padr�o dos Testes
    // Arrange -> Prepara��o do cen�rio necess�rio para invocar o m�todo testado
    // Act -> M�todo a ser testado
    // Assert -> Verifica��o do resultado obtido ap�s a execu��o do m�todo testado

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
