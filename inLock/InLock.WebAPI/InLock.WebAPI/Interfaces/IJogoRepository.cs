using InLock.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InLock.WebAPI.Interfaces
{
    interface IJogoRepository
    {
        List<JogoDomain> Listar();

        void Cadastrar(JogoDomain jogo);
    }
}
