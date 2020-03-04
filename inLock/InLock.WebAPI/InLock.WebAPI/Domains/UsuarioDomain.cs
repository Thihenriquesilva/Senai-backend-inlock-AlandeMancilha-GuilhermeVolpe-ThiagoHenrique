using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InLock.WebAPI.Domains
{
    /// <summary>
    /// CLASSE QUE REPRESENTA A TBL_Usuario NO BANCO DE DADOS BD_InLock
    /// </summary>
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "INFORME O EMAIL DO USUÁRIO")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "INFORME A SENHA DO USUÁRIO")]
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "A SENHA DEVE CONTER NO MÍNIMO 5 E NO MÁXIMO 30 CARACTERES")]
        public string Senha { get; set; }
        public int FK_IdTipoUsuario { get; set; }
        public TipoUsuarioDomain TipoUsuario { get; set; }
    }
}
