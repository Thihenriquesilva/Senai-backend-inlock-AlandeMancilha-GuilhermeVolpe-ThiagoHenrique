using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InLock.WebAPI.Domains;
using InLock.WebAPI.Interfaces;
using InLock.WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InLock.WebAPI.Controllers
{   [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {

        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tipoUsuarioRepository.Listar());
        }

        [HttpPost]
        public IActionResult Post(TipoUsuarioDomain tipoUsuario)
        {
            _tipoUsuarioRepository.Cadastrar(tipoUsuario);

            return Created("http://localhost:5000/api/Usuario", tipoUsuario);
        }
    }
}