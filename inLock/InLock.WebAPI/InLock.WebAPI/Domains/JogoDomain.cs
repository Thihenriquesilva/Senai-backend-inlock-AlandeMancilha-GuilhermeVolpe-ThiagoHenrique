using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InLock.WebAPI.Domains
{
    /// <summary>
    /// CLASSE QUE REPRESENTA A TBL_Jogo NO BANCO DE DADOS DB_InLock
    /// </summary>
    public class JogoDomain
    {
        public int IdJogo { get; set; }
        public string NomeJogo { get; set; }
        public string Descricao { get; set; }
        public string DataLancamento { get; set; }
        public double Valor { get; set; }
        public int FK_IdEstudio { get; set; }
        public EstudioDomain Estudio { get; set; }
    }    
}

