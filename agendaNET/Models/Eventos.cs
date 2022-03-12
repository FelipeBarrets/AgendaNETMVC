using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace agendaNET.Models
{
    public class Eventos
    {
        public string idEventos { get; set; }
        public string NomeEvento { get; set; }
        public string descrição { get; set; }
        public string Data { get; set; }
        public string local { get; set; }
        public string participantes { get; set; }
        public string Tipo { get; set; }
        public string criadorEvento { get; set; }

    }
}