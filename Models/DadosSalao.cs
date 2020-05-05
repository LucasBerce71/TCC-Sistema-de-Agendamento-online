using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TccNovoGrupo.Models
{
    public class DadosSalao
    {
        public int SalaoId { get; set; }
        public string Salao { get; set; }
        public string Endereco { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string Contato { get; set; }
        public string Proprietario { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
    }
}