using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IPersonagemRepository
    {
        // <summary>
        /// Lista todos os personagems
        /// </summary>
        /// <returns>Uma lista de personagems</returns>
        List<Personagen> Listar();

        /// <summary>
        /// Busca um personagem através do seu ID
        /// </summary>
        /// <param name="id">ID do personagem que será buscado</param>
        /// <returns>Um personagem buscado</returns>
        Personagen BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo personagem
        /// </summary>
        /// <param name="novoPersonagen">Objeto novoPersonagen que será cadastrado</param>
        void Cadastrar(Personagen novoPersonagem);

        /// <summary>
        /// Atualiza um personagem existente
        /// </summary>
        /// <param name="id">ID do personagem que será atualizado</param>
        /// <param name="personagenAtualizado">Objeto personagenAtualizado com as novas informações</param>
        void Atualizar(int id, Personagen personagemAtualizado);

        /// <summary>
        /// Deleta um personagem existente
        /// </summary>
        /// <param name="id">ID do personagem que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Lista todos os personagens com seus respectivos jogos
        /// </summary>
        /// <returns>Uma lista de personagens com seus jogadores</returns>
        List<Personagen> ListarJogador();
    }
}
