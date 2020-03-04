using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InLock.WebAPI.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "INFORME O EMAIL")]

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
 
        [Required(ErrorMessage = "INFORME A SENHA")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
