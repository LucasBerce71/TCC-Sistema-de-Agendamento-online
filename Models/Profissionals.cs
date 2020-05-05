using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TccNovoGrupo.Models
{
    public class Profissionals
    {
        [Display(Name = "Id")]
        public int ProfissionalId { get; set; }
        [Required(ErrorMessage = "Informe o nome do profissionaç")]
        public string Profissional { get; set; }
        [Required(ErrorMessage = "Informe o CPF do profissional")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "Informe a data de admissão do funcionário")]
        public string DataAdmissao { get; set; }
        [Required(ErrorMessage = "Informe a data de nascimento do profissional")]
        public string DataNascimento { get; set; }
        [Required(ErrorMessage = "Informe o salário atual do profissional")]
        public string Salario { get; set; }
    }


}