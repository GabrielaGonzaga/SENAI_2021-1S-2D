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
    public class UsuariosController : ControllerBase
    {
        /// <summary>
        /// Objeto _usuarioRepository que irá receber todos os métodos definidos na interface IUsuarioRepository
        /// </summary>
        private IUsuarioRepository _usuarioRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _usuarioRepository para que haja a referência nos métodos implementadas no repositório UsuarioRepository
        /// </summary>
        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Lista todos os usuarios
        /// </summary>
        /// <returns>Uma lista de usuarios e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_usuarioRepository.Listar());
        }



        /// <summary>
        /// Atualiza um usuario existente
        /// </summary>
        /// <param name="id">ID do usuario que será atualizado</param>
        /// <param name="usuarioAtualizado">Objeto usuarioAtualizado com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario usuarioAtualizado)
        {
            // Faz a chamada para o método
            _usuarioRepository.Atualizar(id, usuarioAtualizado);

            // Retorna um status code
            return StatusCode(204);
        }

        /// <summary>
        /// Busca um usuario através do seu ID
        /// </summary>
        /// <param name="id">ID do usuario que será buscado</param>
        /// <returns>Um estúdio encontrado e um status code 200 - Ok</returns>
        /// http://localhost:5000/api/estudios/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_usuarioRepository.BuscarPorId(id));
        }


        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario que será cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Usuario novoUsuario)
        {
            // Faz a chamada para o método
            _usuarioRepository.Cadastrar(novoUsuario);

            // Retorna um status code
            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um usuario existente
        /// </summary>
        /// <param name="id">ID do usuario que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método
            _usuarioRepository.Deletar(id);

            // Retorna um status code
            return StatusCode(200);
        }

    }
}

