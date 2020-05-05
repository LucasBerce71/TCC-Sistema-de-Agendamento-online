using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TccNovoGrupo.Models
{
    public class Agenda
    {

        public int cod_agendamento { get; set; }
        public string data { get; set; }
        public string nome { get; set; }
        public string Profissional { get; set; }
        public string Servico { get; set; }
        public string Inicio { get; set; }

        public int ClienteId { get; set; }
        public int cod_profissional { get; set; }
        public int cod_servico { get; set; }
        public int cod_inicio { get; set; }

    }
}