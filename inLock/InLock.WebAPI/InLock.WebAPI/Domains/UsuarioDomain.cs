using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InLock.WebAPI.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        public string Email { get; set; }
 
        public string Senha { get; set; }

        public int Fk_TipoUsuario { get; set;}
        
        public TipoUsuarioDomain TipoUsuario { get; set;}
    }
}
