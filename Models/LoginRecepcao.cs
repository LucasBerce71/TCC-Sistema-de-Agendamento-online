using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TccNovoGrupo.Models
{
    public class LoginRecepcao
    {
        [Key]
        public int LoginRecepcaoID { get; set; }
        [Required(ErrorMessage = "Informe o nome do(a) Rescepcionista")]
        public string NomeRecepcionista { get; set; }
        [Required(ErrorMessage = "Informe o sobrenome do(a) Recepcionista")]
        public string SobrenomeRecepcionista { get; set; }
        [Required(ErrorMessage = "Crie um nome de usuário válido par o(a) Recepcionista")]
        public string RecepcionistaUsuario { get; set; }
        [Required(ErrorMessage = "Crie uma senha válida para o(a) Recepcionista")]

        [DataType(DataType.Password)]
        public string RecepcionistaPassword { get; set; }
        [DataType(DataType.Password)]
        public string RecepcionistaConfirmPassword { get; set; }
    }
}