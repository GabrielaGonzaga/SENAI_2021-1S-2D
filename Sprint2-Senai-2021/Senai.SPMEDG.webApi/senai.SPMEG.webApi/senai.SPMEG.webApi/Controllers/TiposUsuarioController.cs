using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.SPMEG.webApi.Domains;
using senai.SPMEG.webApi.Interfaces;
using senai.SPMEG.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SPMEG.webApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class TiposUsuarioController : ControllerBase
    {
        /// <summary>
        /// Objeto _tipoDeUsuarioRepository que irá receber todos os métodos definidos na interface ITipoUsuarioRepository
        /// </summary>
        private ITipoUsuarioRepository _tipoDeUsuarioRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _tipoDeUsuarioRepository para que haja a referência nos métodos implementas no repositório TipoUsuarioRepository
        /// </summary>
        public TiposUsuarioController()
        {
            _tipoDeUsuarioRepository = new TipoUsuarioRepository();
        }

        /// <summary>
        /// Lista todos os tipoPerfis
        /// </summary>
        /// <returns>Uma lista de tipoPerfis e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_tipoDeUsuarioRepository.Listar());
        }



        /// <summary>
        /// Atualiza um tipoDeUsuario existente
        /// </summary>
        /// <param name="id">ID do tipoDeUsuario que será atualizado</param>
        /// <param name="tipoDeUsuarioAtualizado">Objeto tipoDeUsuarioAtualizado com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, TiposUsuario tipoDeUsuarioAtualizado)
        {
            // Faz a chamada para o método
            _tipoDeUsuarioRepository.Atualizar(id, tipoDeUsuarioAtualizado);

            // Retorna um status code
            return StatusCode(204);
        }

        /// <summary>
        /// Busca um tipoDeUsuario através do seu ID
        /// </summary>
        /// <param name="id">ID do tipoDeUsuario que será buscado</param>
        /// <returns>Um estúdio encontrado e um status code 200 - Ok</returns>

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_tipoDeUsuarioRepository.BuscarPorId(id));
        }


        /// <summary>
        /// Cadastra um novo tipoDeUsuario
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto novoTipoUsuario que será cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        //[Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(TiposUsuario novoTipoUsuario)
        {
            // Faz a chamada para o método
            _tipoDeUsuarioRepository.Cadastrar(novoTipoUsuario);

            // Retorna um status code
            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um tipoDeUsuario existente
        /// </summary>
        /// <param name="id">ID do tipoDeUsuario que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método
            _tipoDeUsuarioRepository.Deletar(id);

            // Retorna um status code
            return StatusCode(200);
        }

    }
}

