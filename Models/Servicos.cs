using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TccNovoGrupo.Models
{
    public class Servicos
    {
        [Display(Name = "Id")]
        public int ServicoId { get; set; }
        [Required(ErrorMessage = "Informe o nome do serviço")]
        public string Servico { get; set; }
        [Required(ErrorMessage = "Informe um valor para o serviço")]
        public decimal Preco { get; set; }
        [Required(ErrorMessage = "Informe um tempo estimado para a realização do serviço")]
        public string Tempo { get; set; }
        [Required(ErrorMessage = "Descreva sobre o serviço")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Informe se o serviço é masculino ou feminino")]
        public string Tipo { get; set; }
    }
}