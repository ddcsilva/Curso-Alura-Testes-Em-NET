using Alura.Estacionamento.Modelos;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class PatioTestes
    {
        // A - Arrange -> Preparar o cenário para o teste
        // A - Act -> O método que será testado
        // A - Assert -> O resultado esperado

        // Fact -> Testa um fato único
        // Theory -> Teste com parâmetros diferentes

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

        [Theory]
        [InlineData("Danilo Silva", "ASD-1498", "Preto", "Gol")]
        [InlineData("Rosana Silva", "EBS-1234", "Prata", "Fiesta")]
        [InlineData("Raquel Silva", "QPD-6338", "Branco", "Argo")]
        public void ValidaFaturamentoComVariosVeiculos(string proprietario, string placa, string cor, string modelo)
        {
            // Arrange
            var patio = new Patio();
            var veiculo = new Veiculo();

            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;

            patio.RegistrarEntradaVeiculo(veiculo);
            patio.RegistrarSaidaVeiculo(veiculo.Placa);

            // Act
            var faturamento = patio.TotalFaturado();

            // Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Danilo Silva", "ASD-1498", "Preto", "Gol")]
        public void LocalizaVeiculoNoPatio(string proprietario, string placa, string cor, string modelo)
        {
            // Arrange
            var patio = new Patio();
            var veiculo = new Veiculo();

            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;

            patio.RegistrarEntradaVeiculo(veiculo);

            // Act
            var veiculoConsultado = patio.PesquisaVeiculo(placa);

            //Assert
            Assert.Equal(placa, veiculoConsultado.Placa);
        }
    }
}
