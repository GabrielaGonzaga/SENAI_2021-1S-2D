using senai.inlock.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Interfaces
{
    interface IJogoRepository
    {
        /// <summary>
        /// Interface responsável pelo repositório JogosRepository
        /// </summary>


        /// <summary>
        /// Retorna todos os Jogos
        /// </summary>
        /// <returns>Uma lista com os Jogos</returns>
        List<JogoDomain> ListarTodos();

        /// <summary>
        /// Busca um Jogo através do seu id
        /// </summary>
        /// <param name="id">id do jogo que será buscado</param>
        /// <returns>Um objeto do tipo JogosDomain que foi buscado</returns>
        JogoDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo Jogo
        /// </summary>
        /// <param name="novoJogo">Objeto novojogo que será cadastrado</param>
        void Cadastrar(JogoDomain novoJogo);


        /// <summary>
        /// Atualiza um Jogo existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="jogo">Objeto jogo com as novas informações</param>
        void AtualizarIdCorpo(JogoDomain jogo);

        /// <summary>
        /// Atualiza um Jogo existente passando o id pela url da requisição
        /// </summary>
        /// /// <param name="id">id do Jogo que será atualizado</param>
        /// <param name="jogo">Objeto jogo com as novas informações</param>
        void AtualizarIdUrl(int id, JogoDomain jogo);

        /// <summary>
        /// Deleta um Jogo
        /// </summary>
        /// <param name="id">id do Jogo que será deletado</param>
        void Deletar(int id);


    }
}

