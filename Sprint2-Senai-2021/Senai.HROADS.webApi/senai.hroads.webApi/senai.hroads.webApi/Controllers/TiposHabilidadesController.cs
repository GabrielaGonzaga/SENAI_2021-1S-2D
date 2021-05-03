using Microsoft.AspNetCore.Authorization;
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
    [Produces("application/json")]

    [Route("api/[controller]")]
    
    [ApiController]
    public class TiposHabilidadesController : ControllerBase
    {
        /// <summary>
        /// Objeto _tipoHabilidadeRepository que irá receber todos os métodos definidos na interface ITipoHabilidadeRepository
        /// </summary>
        private ITipoHabilidadeRepository _tipoHabilidadeRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _tipoHabilidadeRepository para que haja a referência nos métodos implementas no repositório TipoHabilidadeRepository
        /// </summary>
        public TiposHabilidadesController()
        {
            _tipoHabilidadeRepository = new TipoHabilidadeRepository();
        }

        /// <summary>
        /// Lista todos os tiposHabilidades
        /// </summary>
        /// <returns>Uma lista de tiposHabilidades e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_tipoHabilidadeRepository.Listar());
        }



        /// <summary>
        /// Atualiza um tipoHabilidade existente
        /// </summary>
        /// <param name="id">ID do tipoHabilidade que será atualizado</param>
        /// <param name="tipoHabilidadeAtualizado">Objeto tipoHabilidadeAtualizado com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoHabilidade tipoHabilidadeAtualizado)
        {
            // Faz a chamada para o método
            _tipoHabilidadeRepository.Atualizar(id, tipoHabilidadeAtualizado);

            // Retorna um status code
            return StatusCode(204);
        }

        /// <summary>
        /// Busca um tipoHabilidade através do seu ID
        /// </summary>
        /// <param name="id">ID do tipoHabilidade que será buscado</param>
        /// <returns>Um estúdio encontrado e um status code 200 - Ok</returns>
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_tipoHabilidadeRepository.BuscarPorId(id));
        }


        /// <summary>
        /// Cadastra um novo tipoHabilidade
        /// </summary>
        /// <param name="novoTipoHabilidade">Objeto novoTipoHabilidade que será cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(TipoHabilidade novoTipoHabilidade)
        {
            // Faz a chamada para o método
            _tipoHabilidadeRepository.Cadastrar(novoTipoHabilidade);

            // Retorna um status code
            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um tipoHabilidade existente
        /// </summary>
        /// <param name="id">ID do tipoHabilidade que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método
            _tipoHabilidadeRepository.Deletar(id);

            // Retorna um status code
            return StatusCode(200);
        }

    }
}

