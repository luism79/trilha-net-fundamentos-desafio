using System.Drawing;
using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal _precoInicial = 0;
        private decimal _precoPorHora = 0;
        private List<string> _veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this._precoInicial = precoInicial;
            this._precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            Console.Write("\nDigite a placa do veículo para estacionar: ");
            
            string placa = Console.ReadLine();

            if (!ValidarPlaca(placa))
            {
                Console.WriteLine("Placa inválida. Utilize o formato ABC-1234 ou ABC1D23.");
                return;
            }
            
            bool existe = _veiculos.Any(x => x.ToUpper() == placa.ToUpper());
            if (existe)
            {
                Console.WriteLine("Veículo já está estacionado.");
                return;
            }
            _veiculos.Add(FormatarPlaca(placa));
        }

        public void RemoverVeiculo()
        {
            Console.Write("\nDigite a placa do veículo para remover: ");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            string placa = FormatarPlaca(Console.ReadLine());

            // Verifica se o veículo existe
            if (_veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.Write("\nDigite a quantidade de horas que o veículo permaneceu estacionado: ");
                string horasInput = Console.ReadLine();
                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                int horas = 0;
                if (!int.TryParse(horasInput, out horas))
                {
                    Console.WriteLine("Quantidade de horas inválida.");
                    return;
                }
                decimal valorTotal = _precoInicial + _precoPorHora * horas; 

                // TODO: Remover a placa digitada da lista de veículos
                
                _veiculos.Remove(placa.ToUpper());

                Console.WriteLine("");
                Console.WriteLine("".PadLeft(37, '*'));
                Console.WriteLine("*      Listagem de finalização      *");
                Console.WriteLine("".PadLeft(37, '*'));
                Console.WriteLine($"   Veículo.......: {placa.ToUpper().PadLeft(8, ' ')}");
                Console.WriteLine($"   Horas.........: {horas, 8}");
                Console.WriteLine($"   Valor.........: {_precoInicial, 8:N2}");
                Console.WriteLine($"   Valor / Hora..: {_precoPorHora, 8:N2}");
                Console.WriteLine("".PadLeft(37, '-'));
                Console.WriteLine($"   Valor Total...: {valorTotal, 8:N2}");
                Console.WriteLine("".PadLeft(37, '-'));
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            Console.WriteLine("");
            if (_veiculos.Any())
            {
                Console.WriteLine("".PadLeft(37, '*'));
                Console.WriteLine("*       Listagem de Veículos        *");
                Console.WriteLine("".PadLeft(37, '*'));

                int cont = 1;
                foreach (var veiculo in _veiculos)
                {
                    Console.WriteLine($"  {cont.ToString("00")} - {veiculo}");
                    cont++;
                }
                Console.WriteLine("".PadLeft(37, '-'));
                Console.WriteLine($"Total de veículos estacionados: {_veiculos.Count.ToString("00")}");
                Console.WriteLine("".PadLeft(37, '-'));
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        private bool ValidarPlaca(string placa)
        {
            // Formato de placa: ABC-1234 ou ABC1D23
            var regex = new System.Text.RegularExpressions.Regex("^[A-Z]{3}-?[0-9][A-Z0-9][0-9]{2}$");
            return regex.IsMatch(placa.ToUpper());
        }

        private bool ValidarPlacaMercosul(string placa)
        {
            // Formato de placa Mercosul: ABC1D23
            var regex = new System.Text.RegularExpressions.Regex("^[A-Z]{3}\\d[A-Z]\\d{2}$");
            return regex.IsMatch(placa.ToUpper());
        }

        private string FormatarPlaca(string placa)
        {
            if (ValidarPlacaMercosul(placa))
            {
                return placa.ToUpper();
            }
            
            // Formatar placa para o padrão ABC-1234
            placa = placa.ToUpper().Replace("-", "");
            return placa.Substring(0, 3) + "-" + placa.Substring(3, 4);
        }
    }
}
