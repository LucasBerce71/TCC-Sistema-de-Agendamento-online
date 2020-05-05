using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TccNovoGrupo.Models
{
    public class LoginProfissional
    {
        [Key]
        public int LoginProfissionalID { get; set; }
        [Required(ErrorMessage = "Informe o nome do Profissional")]
        public string NomeProfissional { get; set; }
        [Required(ErrorMessage = "Informe o sobrenome do Profissional")]
        public string SobrenomeProfissional { get; set; }
        [Required(ErrorMessage = "Crie um nome de usuário válido par o Profissional")]
        public string ProfissionalUsuario { get; set; }
        [Required(ErrorMessage = "Crie uma senha válida para o Profissional")]

        [DataType(DataType.Password)]
        public string ProfissionalPassword { get; set; }
        [DataType(DataType.Password)]
        public string ProfissionalConfirmPassword { get; set; }
    }
}