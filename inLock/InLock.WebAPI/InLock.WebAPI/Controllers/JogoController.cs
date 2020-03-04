using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InLock.WebAPI.Domains;
using InLock.WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InLock.WebAPI.Controllers
{   
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class JogoController : ControllerBase
    {

        JogoRepository _jogoRepository;


        public JogoController()
        {
            _jogoRepository = new JogoRepository();
        }


        [HttpGet]
        public List<JogoDomain> Get()
        { 
            return (_jogoRepository.Listar());
        }


        [HttpPost]
        public IActionResult Post(JogoDomain novoJogo)
        {
            if (novoJogo.NomeJogo == null)
            {
                return BadRequest("O NOME DO JOGO É OBRIGATÓRIO");
            }

            _jogoRepository.Cadastrar(novoJogo);

            return Created("O OBJETO FOI CADASTRADO", novoJogo);
        }

    }
}