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
    public class TiposDeUsuarioController : ControllerBase
    {
            /// <summary>
            /// Objeto _TipoDeUsuarioRepository que irá receber todos os métodos definidos na interface ITipoDeUsuarioRepository
            /// </summary>
            private ITipoDeUsuarioRepository _tipoDeUsuarioRepository { get; set; }

            /// <summary>
            /// Instancia o objeto _TipoDeUsuarioRepository para que haja a referência aos métodos no repositório
            /// </summary>
            public TiposDeUsuarioController()
            {
                _tipoDeUsuarioRepository = new TipoDeUsuarioRepository();
            }



            /// <summary>
            /// Lista todos os tipoDeUsuarios
            /// </summary>
            /// <returns>Uma lista de tipoDeUsuarios e um status code</returns>
            /// http://localhost:5000/api/TiposDeUsuario


            [HttpGet("Lista")]
            public IActionResult Get()
            {
                // Cria uma lista nomeada listaTiposDeUsuario para receber os dados
                List<TipoDeUsuarioDomain> listaTipoDeUsuario = _tipoDeUsuarioRepository.ListarTodos();

                // Retorna o status code 200 (Ok) com a lista de tipoDeUsuarios no formato JSON
                return Ok(listaTipoDeUsuario);
            }


            /// <summary>
            /// Cadastra um novo tipoDeUsuario
            /// </summary>
            /// <param name="novoTipoDeUsuario">Objeto novoTipoDeUsuario recebido na requisição</param>
            /// <returns>Um status code 201 - Created</returns>
            /// http://localhost:5000/api/TiposDeUsuario
            /// 
            [HttpPost]
            public IActionResult Post(TipoDeUsuarioDomain novoTipoDeUsuario)
            {
                // Faz a chamada para o método .Cadastrar()
                _tipoDeUsuarioRepository.Cadastrar(novoTipoDeUsuario);

                // Retorna um status code 201 - Created
                return StatusCode(201);
            }


            /// <summary>
            /// Busca um tipoDeUsuario através do seu id
            /// </summary>
            /// <param name="id">id do tipoDeUsuario que será buscado</param>
            /// <returns>Um tipoDeUsuario buscado ou NotFound caso nenhum tipoDeUsuario seja encontrado</returns>
            /// http://localhost:5000/api/TiposDeUsuario/1
            
            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                // Cria um objeto tipoDeUsuarioBuscado que irá receber o tipoDeUsuario buscado no banco de dados
                TipoDeUsuarioDomain tipoDeUsuarioBuscado = _tipoDeUsuarioRepository.BuscarPorId(id);

                // Verifica se nenhum tipoDeUsuario foi encontrado
                if (tipoDeUsuarioBuscado == null)
                {
                    // Caso não seja encontrado, retorna um status code 404 - Not Found com a mensagem personalizada
                    return NotFound("Nenhum tipo de usuário foi encontrado!");
                }

                // Caso seja encontrado, retorna o tipoDeUsuario buscado com um status code 200 - Ok
                return Ok(tipoDeUsuarioBuscado);
            }



            /// <summary>
            /// Atualiza um tipoDeUsuario existente passando o seu id pelo corpo da requisição
            /// </summary>
            /// <param name="id">id do tipoDeUsuario que será atualizado</param>
            /// <param name="tipoDeUsuarioAtualizado">Objeto tipoDeUsuarioAtualizado com as novas informações</param>
            /// <returns>Um status code</returns>
            /// http://localhost:5000/api/tipoDeUsuarios/3
            
            [HttpPut("{id}")]
            public IActionResult PutIdUrl(int id, TipoDeUsuarioDomain tipoDeUsuarioAtualizado)
            {
                // Cria um objeto tipoDeUsuarioBuscado que irá receber o tipoDeUsuario buscado no banco de dados
                TipoDeUsuarioDomain tipoDeUsuarioBuscado = _tipoDeUsuarioRepository.BuscarPorId(id);

                // Caso não seja encontrado, retorna NotFound com uma mensagem personalizada
                // e um bool para apresentar que houve erro
                if (tipoDeUsuarioBuscado == null)
                {
                    return NotFound
                        (new
                        {
                            mensagem = "Tipo de usuário não encontrado!",
                            erro = true
                        }
                        );
                }

                // Tenta atualizar o registro
                try
                {
                    // Faz a chamada para o método .AtualizarIdUrl()
                    _tipoDeUsuarioRepository.AtualizarIdUrl(id, tipoDeUsuarioAtualizado);

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
            /// Atualiza um tipoDeUsuario existente passando o seu id pelo corpo da requisição
            /// </summary>
            /// <param name="tipoDeUsuarioAtualizado">Objeto tipoDeUsuarioAtualizado com as novas informações</param>
            /// <returns>Um status code</returns>
            [HttpPut]
            public IActionResult PutIdBody(TipoDeUsuarioDomain tipoDeUsuarioAtualizado)
            {
                // Cria um objeto tipoDeUsuarioBuscado que irá receber o tipoDeUsuario buscado no banco de dados
                TipoDeUsuarioDomain tipoDeUsuarioBuscado = _tipoDeUsuarioRepository.BuscarPorId(tipoDeUsuarioAtualizado.idTipoUsuario);

                // Verifica se algum tipoDeUsuario foi encontrado
                // ! -> negação (não)
                if (tipoDeUsuarioBuscado != null)
                {
                    // Se sim, tenta atualizar o registro
                    try
                    {
                        // Faz a chamada para o método .AtualizarIdCorpo()
                        _tipoDeUsuarioRepository.AtualizarIdCorpo(tipoDeUsuarioAtualizado);

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
                            mensagem = "TipoDeUsuario não encontrado!"
                        }
                    );
            }




            /// <summary>
            /// Deleta um tipoDeUsuario existente
            /// </summary>
            /// <param name="id">id do tipoDeUsuario que será deletado</param>
            /// <returns>Um status code 204 - No Content</returns>
            /// http://localhost:5000/api/tipoDeUsuarios/4
            
            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                // Faz a chamada para o método .Deletar()
                _tipoDeUsuarioRepository.Deletar(id);

                // Retorna um status code 204 - No Content
                return StatusCode(204);
            }
        
    }
}

