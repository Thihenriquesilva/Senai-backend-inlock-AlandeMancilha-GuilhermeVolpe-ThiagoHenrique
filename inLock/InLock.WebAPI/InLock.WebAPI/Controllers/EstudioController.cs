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
    // DEFINE O TIPO DE RESPOSTA DA API QUE SERÁ NO FORMATO Json
    [Produces("application/json")]

    // DEFINE QUE A ROTA DE UMA REQUISIÇÃO SERÁ NO FORMATO domínio/api/NomeController
    [Route("api/[controller]")]

    //DEFINE QUE É UM CONTROLADOR DE API
    [ApiController]
    public class EstudioController : ControllerBase
    {   
        // CRIA UM OBJETO _estudioRepository QUE IRÁ RECEBER TODOS OS MÉTODOS DEFINIDOS NA INTERFACE E IMPLEMENTADOS NO EstudioRepository
        private EstudioRepository _estudioRepository { get; set; }

        // INSTANCIA O OBEJETO _estudioRepository QUE IRÁ RECEBER TODOS OS MÉTODOS DEFINIDOS NA INTERFACE E IMPLEMENTADOS NO EstudioRepository
        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        /// <summary>
        /// LISTA TODOS OS Estúdios
        /// </summary>
        /// <returns>
        /// RETORNA UMA LISTA EstudioDomain E O Status Code 200 - OK
        /// </returns>

        [HttpGet]
        public IActionResult Get()
        {
            // FAZ A CHAMADA PARA O MÉTODO .Listar()
            return Ok(_estudioRepository.Listar());
        }

        [HttpPost]
        public IActionResult Post(EstudioDomain novoEstudio)
        {
            if (novoEstudio.NomeEstudio == null)
            {
                return BadRequest("O NOME DO ESTÚDIO É OBRIGATÓRIO");
            }

            _estudioRepository.Cadastrar(novoEstudio);


            return Created("O OBJETO FOI CADASTRADO", novoEstudio);
        }

    }
}