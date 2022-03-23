using System;
using System.Collections.Generic;

namespace Resolucao_Desafio_Evento
{
    public class Convidado
    {
        public static List<Cardapio> Cardapio;
        public string NomeConvidado { get; set; }
        public int Idade { get; set; }
        public DateTime DataChegada { get; set; }

        public List<Cardapio> ItensConsumido { get; set; }

        public int Mesa { get; set; }

        public Convidado()
        {
            ItensConsumido = new List<Cardapio>();

            Cardapio = new List<Cardapio>();

            Cardapio.Add(new Cardapio { Id = 1, Nome = "Refrigerante", Valor = 5.5 });
            Cardapio.Add(new Cardapio { Id = 2, Nome = "Suco", Valor = 7 });
            Cardapio.Add(new Cardapio { Id = 3, Nome = "Bife com Fritas", Valor = 18.9 });
            Cardapio.Add(new Cardapio { Id = 4, Nome = "Coxinha", Valor = 3.5 });
            Cardapio.Add(new Cardapio { Id = 5, Nome = "Sobremesa", Valor = 8 });
        }

        public double Consumo()
        {
            double temp = 0;
            for (int i = 0; i < ItensConsumido.Count; i++)
            {
                temp += ItensConsumido[i].Valor;
            }
            return temp;
        }

        public List<Cardapio> cardapios => Cardapio;
    }
}