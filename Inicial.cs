using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Resolucao_Desafio_Evento
{
    public class Inicial
    {
        private static string _NomeEvento;
        private List<int> MesasDisponiveis { get; set; }

        Evento EventoAtual = new Evento();  // Objeto Evento
        Convidado guest = new Convidado(); // Objeto Convidado
        public void InclusaoConsumo(int mesa, Convidado convidado)
        {
            bool isValid = true;
            //var convidadoSearch = (from convidados
            //            in EventoAtual.Convidados
            //                   where convidados.Mesa == mesa
            //                   select convidados).Single();
            Console.Clear();
            Console.WriteLine("========= CARDAPIO =========");
            foreach (var item in convidado.cardapios)
            {
                Console.WriteLine($"Código: {item.Id} - Item: {item.Nome} - Valor: {item.Valor:C}");
            }
            Console.WriteLine("===========================\n");
            do
            {
                try
                {
                    Console.Write("Digite o Código do produto: ");
                    int codProduto = int.Parse(Console.ReadLine());

                    var item = (from cardapio in convidado.cardapios where cardapio.Id == codProduto select cardapio).SingleOrDefault();
                    


                    convidado.ItensConsumido.Add(item);

                    Console.WriteLine("Incluir mais um item?\nS - SIM ou qualquer tecla para NÃO... ");
                    isValid = Console.ReadLine().ToUpper() == "S" ? true : false; 
                }
                catch
                {
                    Console.WriteLine("Parametros incorretos! Digite somente números...");
                    isValid = true;
                }
                
            } while (isValid);

        }
        public void InicioEvento()
        {
            Console.Clear();
            Console.Write("Digite o nome do Evento: ");
            string NomeEvento = Console.ReadLine();
            Console.Write("Digite quantas mesas seão reservadas");
            int QtdMesas = int.Parse(Console.ReadLine());
            MesasDisponiveis = new List<int>();
            for (int i = 0; i < QtdMesas; i++)
            {
                MesasDisponiveis.Add(i + 1);
            }
            EventoAtual.Nome = NomeEvento;
            for (int i = 0; i < QtdMesas; i++)
            {
                var Convidado = IncluirConvidado();
                EventoAtual.Convidados.Add(Convidado);
                if (Convidado.Idade > 18) EventoAtual.Sorteio.Add(Convidado);
            }

        }
        public Convidado IncluirConvidado()
        {
            guest = new Convidado();
            Console.Clear();
            Console.Write("Digite o nome do Convidado");
            string nomeConvidado = Console.ReadLine();
            Console.Write("Digite a idade");
            int Idade = int.Parse(Console.ReadLine());
            Console.WriteLine("\nMESAS DISPONÍVEIS\n\n");
            foreach (var item in MesasDisponiveis)
            {
                Console.Write($" {item} |");
            }
            Console.Write("\nQual mesa gostaria de ocupar: ");
            int Mesa = int.Parse(Console.ReadLine());
            MesasDisponiveis.Remove(Mesa);
            guest.NomeConvidado = nomeConvidado;
            guest.Idade = Idade;
            guest.DataChegada = DateTime.Now;
            guest.Mesa = Mesa;
            return guest;

        }
        public void Start()
        {
            bool IsValid;
            InicioEvento();

            do
            {
                Console.WriteLine("Escolha uma das mesas abaixo para inclusão do consumo:\n");

                for (int i = 0; i < EventoAtual.Convidados.Count; i++)
                {
                    Console.Write($" {EventoAtual.Convidados[i].Mesa} |");
                }
                Console.Write("\nDigite a mesa:");
                try
                {
                    
                    int escolha = int.Parse(Console.ReadLine());
                    var guestSearch = (from convidados
                        in EventoAtual.Convidados
                        where convidados.Mesa == escolha
                        select convidados).Single();

                    if (guestSearch.Mesa == escolha)
                    {
                        InclusaoConsumo(escolha, guestSearch);
                        Console.WriteLine($"Consumo do {guestSearch.NomeConvidado} é de {guestSearch.Consumo():C}");
                        IsValid = false;
                        Thread.Sleep(2000);
                        Console.Clear();
                        Console.WriteLine("E o sorteado é:");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Console.WriteLine("3");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Console.WriteLine("2");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Console.WriteLine("1");
                        Thread.Sleep(1000);
                        Console.Clear();
                        int qtdSorteados = 2;
                        for (int i = 0; i < qtdSorteados; i++)
                        {
                            var Sorteado = Sorteio();
                            Console.WriteLine($"{i+1}º Sorteado é -> {Sorteado.NomeConvidado}");
                            Console.WriteLine("\n\n");
                        }

                        


                    }
                    else
                    {
                        Console.WriteLine("Mesa inexistente, favor digite somente uma das listadas...");
                        Console.ReadKey();
                        IsValid = true;
                    }
                }
                catch
                {
                    Console.WriteLine("Digite somente números!!!");
                    Console.ReadKey();
                    IsValid=true;
                }

            } while (IsValid);


        }

        public Convidado Sorteio()
        {
            Random random = new Random();
            int sorteado = random.Next(EventoAtual.Sorteio.Count);
            return EventoAtual.Sorteio.ElementAt(sorteado);
        }
    }
}
