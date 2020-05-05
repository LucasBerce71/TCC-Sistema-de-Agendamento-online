using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TccNovoGrupo.Models
{
    public class AdmLogin
    {
        [Key]
        public int LoginAdmID { get; set; }
        [Required(ErrorMessage = "Informe o nome do administrador do salão")]
        public string NomeAdm { get; set; }
        [Required(ErrorMessage = "Informe o sobrenome do administrador")]
        public string SobrenomeAdm { get; set; }
        [Required(ErrorMessage = "Crie um nome de usuário válido para o Administrador")]
        public string AdmUsuario { get; set; }
        [Required(ErrorMessage = "Crie uma senha válida para o Administrador")]

        [DataType(DataType.Password)]
        public string AdmPassword { get; set; }
        [DataType(DataType.Password)]
        public string AdmConfirmPassword { get; set; }
    }
}