using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface ITipoDeUsuarioRepository
    {
        /// <summary>
        /// Lista todos os tipossDeUsuarios
        /// </summary>
        /// <returns>Uma lista de tipossDeUsuarios</returns>
        List<TiposDeUsuario> Listar();

        /// <summary>
        /// Busca um tiposDeUsuario através do seu ID
        /// </summary>
        /// <param name="id">ID do tiposDeUsuario que será buscado</param>
        /// <returns>Um tiposDeUsuario buscado</returns>
        TiposDeUsuario BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo tiposDeUsuario
        /// </summary>
        /// <param name="novoTipoDeUsuario">Objeto novoTiposDeUsuario que será cadastrado</param>
        void Cadastrar(TiposDeUsuario novoTipoDeUsuario);

        /// <summary>
        /// Atualiza um tiposDeUsuario existente
        /// </summary>
        /// <param name="id">ID do tiposDeUsuario que será atualizado</param>
        /// <param name="tipoDeUsuarioAtualizado">Objeto tiposDeUsuarioAtualizado com as novas informações</param>
        void Atualizar(int id, TiposDeUsuario tipoDeUsuarioAtualizado);

        /// <summary>
        /// Deleta um tiposDeUsuario existente
        /// </summary>
        /// <param name="id">ID do tiposDeUsuario que será deletado</param>
        void Deletar(int id);

    }
}

