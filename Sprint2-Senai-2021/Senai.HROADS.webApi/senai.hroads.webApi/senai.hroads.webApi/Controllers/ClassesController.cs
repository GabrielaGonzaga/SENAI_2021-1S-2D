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
    public class ClassesController : ControllerBase
    {
        /// <summary>
        /// Objeto _classeRepository que irá receber todos os métodos definidos na interface IClasseRepository
        /// </summary>
        private IClasseRepository _classeRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _classeRepository para que haja a referência nos métodos implementas no repositório ClasseRepository
        /// </summary>
        public ClassesController()
        {
            _classeRepository = new ClasseRepository();
        }

        /// <summary>
        /// Lista todas as clases
        /// </summary>
        /// <returns>Uma lista de classs e um status code 200 - Ok</returns>
        /// 
        [HttpGet]
        public IActionResult Get()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_classeRepository.Listar());
        }



        /// <summary>
        /// Atualiza uma classe existente
        /// </summary>
        /// <param name="id">ID da classe que será atualizado</param>
        /// <param name="classeAtualizada">Objeto classeAtualizada com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Class classeAtualizada)
        {
            // Faz a chamada para o método
            _classeRepository.Atualizar(id, classeAtualizada);

            // Retorna um status code
            return StatusCode(204);
        }

        /// <summary>
        /// Busca uma classe através do seu ID
        /// </summary>
        /// <param name="id">ID da classe que será buscado</param>
        /// <returns>Um estúdio encontrado e um status code 200 - Ok</returns>
        /// http://localhost:5000/api/estudios/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_classeRepository.BuscarPorId(id));
        }


        /// <summary>
        /// Cadastra uma nova classe
        /// </summary>
        /// <param name="novaClasse">Objeto novaClasse que será cadastrada</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Class novaClasse)
        {
            // Faz a chamada para o método
            _classeRepository.Cadastrar(novaClasse);

            // Retorna um status code
            return StatusCode(201);
        }

        /// <summary>
        /// Deleta uma classe existente
        /// </summary>
        /// <param name="id">ID da classe que será deletada</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método
            _classeRepository.Deletar(id);

            // Retorna um status code
            return StatusCode(200);
        }

    }
}
