using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.Estacionamento.Modelos
{
    public class Patio
    {
        public Patio()
        {
            Faturado = 0;
            Veiculos = new List<Veiculo>();
        }

        public List<Veiculo> Veiculos { get; set; }
        public double Faturado { get; set; }

        public double TotalFaturado()
        {
            return Faturado;
        }

        public string MostrarFaturamento()
        {
            string totalfaturado = String.Format("Total faturado até o momento :::::::::::::::::::::::::::: {0:c}", this.TotalFaturado());
            return totalfaturado;
        }

        public void RegistrarEntradaVeiculo(Veiculo veiculo)
        {
            veiculo.HoraEntrada = DateTime.Now;
            Veiculos.Add(veiculo);
        }

        public string RegistrarSaidaVeiculo(String placa)
        {
            Veiculo veiculoARemover = null;
            string informacao = string.Empty;

            foreach (Veiculo veiculo in Veiculos)
            {
                if (veiculo.Placa == placa)
                {
                    double valorASerCobrado = 0;

                    veiculo.HoraSaida = DateTime.Now;
                    TimeSpan tempoPermanencia = veiculo.HoraSaida - veiculo.HoraEntrada;

                    /// O método Math.Ceiling(), aplica o conceito de teto da matemática onde o valor máximo é o inteiro imediatamente posterior a ele.
                    /// Ex.: 0,9999 ou 0,0001 teto = 1
                    /// Obs.: o conceito de chão é inverso e podemos utilizar Math.Floor();

                    if (veiculo.Tipo == TipoVeiculo.Automovel)
                    {
                        valorASerCobrado = Math.Ceiling(tempoPermanencia.TotalHours) * 2;
                    }

                    if (veiculo.Tipo == TipoVeiculo.Motocicleta)
                    {
                        valorASerCobrado = Math.Ceiling(tempoPermanencia.TotalHours) * 1;
                    }

                    informacao = string.Format("" +
                        "Hora de entrada: {0: HH: mm: ss} \n" +
                        "Hora de saída: {1: HH:mm:ss} \n" +
                        "Permanência: {2: HH:mm:ss} \n" +
                        "Valor a pagar: {3:c}",
                        veiculo.HoraEntrada, veiculo.HoraSaida, new DateTime().Add(tempoPermanencia), valorASerCobrado);

                    Faturado =+ valorASerCobrado;
                    veiculoARemover = veiculo;

                    break;
                }
            }

            if (veiculoARemover != null)
            {
                Veiculos.Remove(veiculoARemover);
            }
            else
            {
                return "Não foi encontrado veículo com a placa informada.";
            }

            return informacao;
        }

        public Veiculo PesquisaVeiculo(string placa)
        {
            var veiculoEncontrado = (from veiculo in this.Veiculos
                                     where veiculo.Placa == placa
                                     select veiculo).SingleOrDefault();

            return veiculoEncontrado;
        }
    }
}
