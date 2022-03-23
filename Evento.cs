using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resolucao_Desafio_Evento
{
    public class Evento
    {
        public string Nome { get; set; }
        public DateTime DataEvento { get; set; }
        public List<Convidado> Convidados { get; set; }

        public List<Convidado> Sorteio { get; set; }

        public double LucroEvento { get; set; }

        public int QtdMesas { get; set; }

        public Evento()
        {
            Convidados = new List<Convidado>();
            Sorteio = new List<Convidado>();
        }

    }
}
