using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using senai.hroads.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class PersonagensController : ControllerBase
    {
        /// <summary>
        /// Objeto _personagemRepository que irá receber todos os métodos definidos na interface IPersonagemRepository
        /// </summary>
        private IPersonagemRepository _personagemRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _personagemRepository para que haja a referência nos métodos implementas no repositório PersonagemRepository
        /// </summary>
        public PersonagensController()
        {
            _personagemRepository = new PersonagemRepository();
        }

        /// <summary>
        /// Lista todos os personagens
        /// </summary>
        /// <returns>Uma lista de personagens e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_personagemRepository.Listar());
        }



        /// <summary>
        /// Atualiza um estúdio existente
        /// </summary>
        /// <param name="id">ID do estúdio que será atualizado</param>
        /// <param name="estudioAtualizado">Objeto estudioAtualizado com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Personagen personagemAtualizado)
        {
            // Faz a chamada para o método
            _personagemRepository.Atualizar(id, personagemAtualizado);

            // Retorna um status code
            return StatusCode(204);
        }

        /// <summary>
        /// Busca um estúdio através do seu ID
        /// </summary>
        /// <param name="id">ID do estúdio que será buscado</param>
        /// <returns>Um estúdio encontrado e um status code 200 - Ok</returns>
        /// http://localhost:5000/api/estudios/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_personagemRepository.BuscarPorId(id));
        }


        /// <summary>
        /// Cadastra um novo estúdio
        /// </summary>
        /// <param name="novoEstudio">Objeto novoEstudio que será cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(Personagen novoPersonagem)
        {
            // Faz a chamada para o método
            _personagemRepository.Cadastrar(novoPersonagem);

            // Retorna um status code
            return StatusCode(201);
        }

    }
}
