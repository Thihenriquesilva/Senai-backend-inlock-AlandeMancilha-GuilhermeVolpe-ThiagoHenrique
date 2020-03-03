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
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private UsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpGet]

        public IActionResult Get()
        {
            return Ok(_usuarioRepository.Listar());

        }
        
        [HttpPost]
        public IActionResult Post(UsuarioDomain novoUsuario)
        {
            _usuarioRepository.Cadastrar(novoUsuario);

            return Created("http://localhost:5000/api/Usuario", novoUsuario);
        }
    }
}