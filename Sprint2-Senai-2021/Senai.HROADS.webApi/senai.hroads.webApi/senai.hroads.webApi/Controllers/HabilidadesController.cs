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
    public class HabilidadesController : ControllerBase
    {
        /// <summary>
        /// Objeto _habilidadeRepository que irá receber todos os métodos definidos na interface IHabilidadeRepository
        /// </summary>
        private IHabilidadeRepository _habilidadeRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _habilidadeRepository para que haja a referência nos métodos implementas no repositório HabilidadeRepository
        /// </summary>
        public HabilidadesController()
        {
            _habilidadeRepository = new HabilidadeRepository();
        }

        /// <summary>
        /// Lista todas as habilidades
        /// </summary>
        /// <returns>Uma lista de classs e um status code 200 - Ok</returns>
        /// 
        [HttpGet]
        public IActionResult Get()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_habilidadeRepository.Listar());
        }



        /// <summary>
        /// Atualiza uma habilidade existente
        /// </summary>
        /// <param name="id">ID da habilidade que será atualizado</param>
        /// <param name="habilidadeAtualizada">Objeto habilidadeAtualizada com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Habilidade habilidadeAtualizada)
        {
            // Faz a chamada para o método
            _habilidadeRepository.Atualizar(id, habilidadeAtualizada);

            // Retorna um status code
            return StatusCode(204);
        }

        /// <summary>
        /// Busca uma habilidade através do seu ID
        /// </summary>
        /// <param name="id">ID da habilidade que será buscado</param>
        /// <returns>Um estúdio encontrado e um status code 200 - Ok</returns>
        /// http://localhost:5000/api/estudios/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_habilidadeRepository.BuscarPorId(id));
        }


        /// <summary>
        /// Cadastra uma nova habilidade
        /// </summary>
        /// <param name="novaHabilidade">Objeto novaHabilidade que será cadastrada</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Habilidade novaHabilidade)
        {
            // Faz a chamada para o método
            _habilidadeRepository.Cadastrar(novaHabilidade);

            // Retorna um status code
            return StatusCode(201);
        }

        /// <summary>
        /// Deleta uma habilidade existente
        /// </summary>
        /// <param name="id">ID da habilidade que será deletada</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método
            _habilidadeRepository.Deletar(id);

            // Retorna um status code
            return StatusCode(200);
        }

        /// <summary>
        /// Lista todas as habilidades com seus respectivos tipos
        /// </summary>
        /// <returns>Uma lista de classs e um status code 200 - Ok</returns>
        /// 
        [HttpGet("Tipos")]
        public IActionResult GetTipos()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_habilidadeRepository.ListarTiposHabilidades());
        }
    }
}

