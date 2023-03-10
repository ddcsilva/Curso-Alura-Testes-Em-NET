using System;

namespace Alura.Estacionamento.Modelos
{
    public class Veiculo
    {
        public Veiculo() { }

        public Veiculo(string proprietario)
        {
            Proprietario = proprietario;
        }

        public string Cor { get; set; }
        public double Largura { get; set; }
        public double VelocidadeAtual { get; set; }
        public string Modelo { get; set; }
        public string Proprietario { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSaida { get; set; }
        public TipoVeiculo Tipo { get; set; }

        private string _placa;
        public string Placa
        {
            get
            {
                return _placa;
            }
            set
            {
                // Checa se o valor possui pelo menos 8 caracteres
                if (value.Length != 8)
                {
                    throw new FormatException("A placa deve possuir pelo menos 8 caracteres");
                }

                for (int i = 0; i < 3; i++)
                {
                    // Checa se os 3 primeiros caracteres são numeros
                    if (char.IsDigit(value[i]))
                    {
                        throw new FormatException("Os 3 primeiros caracteres devem ser letras!");
                    }
                }

                // Checa o Hifem
                if (value[3] != '-')
                {
                    throw new FormatException("O 4° caractere deve ser um hífen");
                }

                // Checa se os 3 primeiros caracteres são numeros
                for (int i = 4; i < 8; i++)
                {
                    if (!char.IsDigit(value[i]))
                    {
                        throw new FormatException("Do 5º ao 8º caractere deve-se ter um número!");
                    }
                }

                _placa = value;
            }
        }

        public void Acelerar(int tempoEmSegundos)
        {
            this.VelocidadeAtual += (tempoEmSegundos * 10);
        }

        public void Frear(int tempoEmSegundos)
        {
            this.VelocidadeAtual -= (tempoEmSegundos * 15);
        }
    }
}
