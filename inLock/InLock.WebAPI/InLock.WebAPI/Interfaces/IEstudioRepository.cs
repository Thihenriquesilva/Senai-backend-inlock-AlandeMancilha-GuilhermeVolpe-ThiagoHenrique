using InLock.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InLock.WebAPI.Interfaces
{
    interface IEstudioRepository
    {
        List<EstudioDomain> Listar();
        void Cadastrar(EstudioDomain estudio);
        
    }
}
