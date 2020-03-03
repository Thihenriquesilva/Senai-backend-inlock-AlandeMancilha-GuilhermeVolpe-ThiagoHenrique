using InLock.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InLock.WebAPI.Interfaces
{
    interface IUsuarioRepository
    {

        List<UsuarioDomain> Listar();

        void Cadastrar(UsuarioDomain novoUsuario);


    }
}
