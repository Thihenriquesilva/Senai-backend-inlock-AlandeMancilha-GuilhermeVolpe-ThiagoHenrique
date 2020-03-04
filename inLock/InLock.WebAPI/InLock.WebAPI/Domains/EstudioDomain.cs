using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InLock.WebAPI.Domains
{
    /// <summary>
    /// CLASSE QUE REPRESENTA A TBL_Estudio NO BANCO DE DADOS DB_InLock
    /// </summary>
    public class EstudioDomain
    {
        public int IdEstudio { get; set; }
        public string NomeEstudio { get; set; }
    }
}
