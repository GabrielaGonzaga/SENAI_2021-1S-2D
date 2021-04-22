using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Controllers
{
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/Estudios
    [Route("api/[controller]")]

    [ApiController]
    public class EstudiosController : ControllerBase
    {
        /// <summary>
        /// Objeto _EstudioRepository que irá receber todos os métodos definidos na interface IEstudioRepository
        /// </summary>
        private IEstudioRepository _estudioRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _EstudioRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public EstudiosController()
        {
            _estudioRepository = new EstudioRepository();
        }


        /// <summary>
        /// Lista todos os estudios
        /// </summary>
        /// <returns>Uma lista de estudios e um status code</returns>
        /// http://localhost:18442/api/Estudios
        [HttpGet]
        public IActionResult Get()
        {
            // Cria uma lista nomeada listaEstudios para receber os dados
            List<EstudioDomain> listaEstudio = _estudioRepository.ListarTodos();

            // Retorna o status code 200 (Ok) com a lista de estudios no formato JSON
            return Ok(listaEstudio);
        }


        /// <summary>
        /// Cadastra um novo estudio
        /// </summary>
        /// <param name="novoEstudio">Objeto novoEstudio recebido na requisição</param>
        /// <returns>Um status code 201 - Created</returns>
        /// http://localhost:5000/api/Estudios
        [HttpPost]
        public IActionResult Post(EstudioDomain novoEstudio)
        {
            // Faz a chamada para o método .Cadastrar()
            _estudioRepository.Cadastrar(novoEstudio);

            // Retorna um status code 201 - Created
            return StatusCode(201);
        }


        /// <summary>
        /// Busca um estudio através do seu id
        /// </summary>
        /// <param name="id">id do estudio que será buscado</param>
        /// <returns>Um estudio buscado ou NotFound caso nenhum estudio seja encontrado</returns>
        /// http://localhost:5000/api/Estudios/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Cria um objeto estudioBuscado que irá receber o estudio buscado no banco de dados
            EstudioDomain estudioBuscado = _estudioRepository.BuscarPorId(id);

            // Verifica se nenhum estudio foi encontrado
            if (estudioBuscado == null)
            {
                // Caso não seja encontrado, retorna um status code 404 - Not Found com a mensagem personalizada
                return NotFound("Nenhum estúdio foi encontrado!");
            }

            // Caso seja encontrado, retorna o estudio buscado com um status code 200 - Ok
            return Ok(estudioBuscado);
        }



        /// <summary>
        /// Atualiza um estudio existente passando o seu id pelo corpo da requisição
        /// </summary>
        /// <param name="id">id do estudio que será atualizado</param>
        /// <param name="estudioAtualizado">Objeto estudioAtualizado com as novas informações</param>
        /// <returns>Um status code</returns>
        /// http://localhost:5000/api/estudios/3
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, EstudioDomain estudioAtualizado)
        {
            // Cria um objeto estudioBuscado que irá receber o estudio buscado no banco de dados
            EstudioDomain estudioBuscado = _estudioRepository.BuscarPorId(id);

            // Caso não seja encontrado, retorna NotFound com uma mensagem personalizada
            // e um bool para apresentar que houve erro
            if (estudioBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Estúdio não encontrado!",
                        erro = true
                    }
                    );
            }

            // Tenta atualizar o registro
            try
            {
                // Faz a chamada para o método .AtualizarIdUrl()
                _estudioRepository.AtualizarIdUrl(id, estudioAtualizado);

                // Retorna um status code 204 - No Content
                return NoContent();
            }
            // Caso ocorra algum erro
            catch (Exception erro)
            {
                // Retorna um status 400 - BadRequest e o código do erro
                return BadRequest(erro);
            }
        }



        /// <summary>
        /// Atualiza um estudio existente passando o seu id pelo corpo da requisição
        /// </summary>
        /// <param name="estudioAtualizado">Objeto estudioAtualizado com as novas informações</param>
        /// <returns>Um status code</returns>
        [HttpPut]
        public IActionResult PutIdBody(EstudioDomain estudioAtualizado)
        {
            // Cria um objeto estudioBuscado que irá receber o estudio buscado no banco de dados
            EstudioDomain estudioBuscado = _estudioRepository.BuscarPorId(estudioAtualizado.idEstudio);

            // Verifica se algum estudio foi encontrado
            // ! -> negação (não)
            if (estudioBuscado != null)
            {
                // Se sim, tenta atualizar o registro
                try
                {
                    // Faz a chamada para o método .AtualizarIdCorpo()
                    _estudioRepository.AtualizarIdCorpo(estudioAtualizado);

                    // Retorna um status code 204 - No Content
                    return NoContent();
                }
                // Caso ocorra algum erro
                catch (Exception erro)
                {
                    // Retorna um BadRequest e o código do erro
                    return BadRequest(erro);
                }
            }

            // Caso não seja encontrado, retorna NotFoun com uma mensagem personalizada
            return NotFound
                (
                    new
                    {
                        mensagem = "Estúdio não encontrado!"
                    }
                );
        }




        /// <summary>
        /// Deleta um estudio existente
        /// </summary>
        /// <param name="id">id do estudio que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// http://localhost:5000/api/estudios/4
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método .Deletar()
            _estudioRepository.Deletar(id);

            // Retorna um status code 204 - No Content
            return StatusCode(204);
        }
    }


}

