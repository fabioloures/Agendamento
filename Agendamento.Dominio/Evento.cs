using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;




namespace Agendamento.Dominio
{
    public class Evento
    {
        public int id { get; set; }
        public string nome_resp { get; set; }

        public Sala Sala { get; set; }
        public int Salaid { get; set; }
        public DateTime data_inicial { get; set; }
        public DateTime data_final { get; set; }


    }
}
