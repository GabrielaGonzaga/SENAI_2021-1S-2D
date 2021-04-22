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
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class JogosController : ControllerBase
    {
        /// <summary>
        /// Objeto _JogoRepository que irá receber todos os métodos definidos na interface IJogoRepository
        /// </summary>
        private IJogoRepository _jogoRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _JogoRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public JogosController()
        {
            _jogoRepository = new JogoRepository();
        }



        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        /// <returns>Uma lista de jogos e um status code</returns>
        /// http://localhost:5000/api/Jogos
        /// o usuário precisa estar logado para a ação acontecer
        
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            // Cria uma lista nomeada listaJogos para receber os dados
            List<JogoDomain> listaJogo = _jogoRepository.ListarTodos();

            // Retorna o status code 200 (Ok) com a lista de jogos no formato JSON
            return Ok(listaJogo);
        }


        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="novoJogo">Objeto novoJogo recebido na requisição</param>
        /// <returns>Um status code 201 - Created</returns>
        /// http://localhost:5000/api/Jogos
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(JogoDomain novoJogo)
        {
            // Faz a chamada para o método .Cadastrar()
            _jogoRepository.Cadastrar(novoJogo);

            // Retorna um status code 201 - Created
            return StatusCode(201);
        }


        /// <summary>
        /// Busca um jogo através do seu id
        /// </summary>
        /// <param name="id">id do jogo que será buscado</param>
        /// <returns>Um jogo buscado ou NotFound caso nenhum jogo seja encontrado</returns>
        /// http://localhost:5000/api/Jogos/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Cria um objeto jogoBuscado que irá receber o jogo buscado no banco de dados
            JogoDomain jogoBuscado = _jogoRepository.BuscarPorId(id);

            // Verifica se nenhum jogo foi encontrado
            if (jogoBuscado == null)
            {
                // Caso não seja encontrado, retorna um status code 404 - Not Found com a mensagem personalizada
                return NotFound("Nenhum jogo foi encontrado!");
            }

            // Caso seja encontrado, retorna o jogo buscado com um status code 200 - Ok
            return Ok(jogoBuscado);
        }



        /// <summary>
        /// Atualiza um jogo existente passando o seu id pelo corpo da requisição
        /// </summary>
        /// <param name="id">id do jogo que será atualizado</param>
        /// <param name="jogoAtualizado">Objeto jogoAtualizado com as novas informações</param>
        /// <returns>Um status code</returns>
        /// http://localhost:5000/api/jogos/3
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, JogoDomain jogoAtualizado)
        {
            // Cria um objeto jogoBuscado que irá receber o jogo buscado no banco de dados
            JogoDomain jogoBuscado = _jogoRepository.BuscarPorId(id);

            // Caso não seja encontrado, retorna NotFound com uma mensagem personalizada
            // e um bool para apresentar que houve erro
            if (jogoBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Jogo não encontrado!",
                        erro = true
                    }
                    );
            }

            // Tenta atualizar o registro
            try
            {
                // Faz a chamada para o método .AtualizarIdUrl()
                _jogoRepository.AtualizarIdUrl(id, jogoAtualizado);

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
        /// Atualiza um jogo existente passando o seu id pelo corpo da requisição
        /// </summary>
        /// <param name="jogoAtualizado">Objeto jogoAtualizado com as novas informações</param>
        /// <returns>Um status code</returns>
        [HttpPut]
        public IActionResult PutIdBody(JogoDomain jogoAtualizado)
        {
            // Cria um objeto jogoBuscado que irá receber o jogo buscado no banco de dados
            JogoDomain jogoBuscado = _jogoRepository.BuscarPorId(jogoAtualizado.idJogo);

            // Verifica se algum jogo foi encontrado
            // ! -> negação (não)
            if (jogoBuscado != null)
            {
                // Se sim, tenta atualizar o registro
                try
                {
                    // Faz a chamada para o método .AtualizarIdCorpo()
                    _jogoRepository.AtualizarIdCorpo(jogoAtualizado);

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
                        mensagem = "Jogo não encontrado!"
                    }
                );
        }




        /// <summary>
        /// Deleta um jogo existente
        /// </summary>
        /// <param name="id">id do jogo que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// http://localhost:5000/api/jogos/4
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método .Deletar()
            _jogoRepository.Deletar(id);

            // Retorna um status code 204 - No Content
            return StatusCode(204);
        }
    }
}
