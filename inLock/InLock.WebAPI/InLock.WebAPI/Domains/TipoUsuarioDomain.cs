using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InLock.WebAPI.Domains
{
    /// <summary>
    /// CLASSE QUE REPRESENTA A TBL_TipoUsuario NO BANCO DE DADOS BD_InLock
    /// </summary>
    public class TipoUsuarioDomain
    {
        public int IdTipoUsuario { get; set; }

        public string TituloTipoUsuario { get; set; }
    }
}
