using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TccNovoGrupo.Models
{
    public class Clientes
    {
        public int cod_cliente { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string cpf { get; set; }
        public string contato { get; set; }
        public string senha { get; set; }
        public string sexo { get; set; }
        public int cod_nv { get; set; }
    }
}