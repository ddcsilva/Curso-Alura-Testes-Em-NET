using Alura.Estacionamento.Modelos;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class PatioTestes
    {
        [Fact]
        public void ValidaFaturamento()
        {
            // Arrange
            var patio = new Patio();
            var veiculo = new Veiculo();

            veiculo.Proprietario = "Danilo Silva";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Azul";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "ASD-9999";

            patio.RegistrarEntradaVeiculo(veiculo);
            patio.RegistrarSaidaVeiculo(veiculo.Placa);

            // Act
            var faturamento = patio.TotalFaturado();

            // Assert
            Assert.Equal(2, faturamento);
        }
    }
}
