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
    public class TiposDeUsuariosController : ControllerBase
    {
        /// <summary>
        /// Objeto _tipoDeUsuarioRepository que irá receber todos os métodos definidos na interface ITipoDeUsuarioRepository
        /// </summary>
        private ITipoDeUsuarioRepository _tipoDeUsuarioRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _tipoDeUsuarioRepository para que haja a referência nos métodos implementas no repositório TipoDeUsuarioRepository
        /// </summary>
        public TiposDeUsuariosController()
        {
            _tipoDeUsuarioRepository = new TipoDeUsuarioRepository();
        }

        /// <summary>
        /// Lista todos os tiposDeUsuarios
        /// </summary>
        /// <returns>Uma lista de tiposDeUsuarios e um status code 200 - Ok</returns>
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
        public IActionResult Put(int id, TiposDeUsuario tipoDeUsuarioAtualizado)
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
        /// <param name="novoTipoDeUsuario">Objeto novoTipoDeUsuario que será cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(TiposDeUsuario novoTipoDeUsuario)
        {
            // Faz a chamada para o método
            _tipoDeUsuarioRepository.Cadastrar(novoTipoDeUsuario);

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

