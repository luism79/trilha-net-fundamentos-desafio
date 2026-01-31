using System.Drawing;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            Console.Write("\nDigite a placa do veículo para estacionar: ");
            
            string placa = Console.ReadLine();

            if (!string.IsNullOrEmpty(placa))
            {
                bool existe = veiculos.Any(x => x.ToUpper() == placa.ToUpper());
                if (existe)
                {
                    Console.WriteLine("Veículo já está estacionado.");
                    return;
                }
                veiculos.Add(placa.ToUpper());
            }
            else
            {
                Console.WriteLine("Placa não pode ser em branco.");
            }
        }

        public void RemoverVeiculo()
        {
            Console.Write("\nDigite a placa do veículo para remover: ");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
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
                decimal valorTotal = precoInicial + precoPorHora * horas; 

                // TODO: Remover a placa digitada da lista de veículos
                
                veiculos.Remove(placa.ToUpper());

                Console.WriteLine("");
                Console.WriteLine("".PadLeft(37, '*'));
                Console.WriteLine("*      Listagem de finalização      *");
                Console.WriteLine("".PadLeft(37, '*'));
                Console.WriteLine($"   Veículo.......: {placa.ToUpper()}");
                Console.WriteLine($"   Horas.........: {horas, 8}");
                Console.WriteLine($"   Valor.........: {precoInicial, 8:N2}");
                Console.WriteLine($"   Valor / Hora..: {precoPorHora, 8:N2}");
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
            if (veiculos.Any())
            {
                Console.WriteLine("".PadLeft(37, '*'));
                Console.WriteLine("*       Listagem de Veículos        *");
                Console.WriteLine("".PadLeft(37, '*'));

                int cont = 1;
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine($"  {cont.ToString("00")} - {veiculo}");
                    cont++;
                }
                Console.WriteLine("".PadLeft(37, '-'));
                Console.WriteLine($"Total de veículos estacionados: {veiculos.Count.ToString("00")}");
                Console.WriteLine("".PadLeft(37, '-'));
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
