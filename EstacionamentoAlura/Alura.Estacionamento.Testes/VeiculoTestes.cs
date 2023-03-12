using Alura.Estacionamento.Modelos;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes
    {
        // A - Arrange -> Preparar o cenário para o teste
        // A - Act -> O método que será testado
        // A - Assert -> O resultado esperado

        [Fact(DisplayName = "Teste nº 1")]
        [Trait("Funcionalidade", "Acelerar")]
        public void TestaVeiculoAcelerar()
        {
            // Arrange
            var veiculo = new Veiculo();
            // Act
            veiculo.Acelerar(10);
            // Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "Teste nº 2")]
        [Trait("Funcionalidade", "Acelerar")]
        public void TestaVeiculoFrear()
        {
            // Arrange
            var veiculo = new Veiculo();
            // Act
            veiculo.Frear(10);
            // Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "Teste nº 3", Skip = "Teste ainda não implementado. Ignorar")]
        public void ValidaNomeProprietario()
        {

        }
    }
}
