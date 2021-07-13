using senai.SPMEG.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SPMEG.webApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Lista todos os tiposs de Perfis
        /// </summary>
        /// <returns>Uma lista de tiposUsuario</returns>
        List<TiposUsuario> Listar();

        /// <summary>
        /// Busca um tiposUsuario através do seu ID
        /// </summary>
        /// <param name="id">ID do tiposUsuario que será buscado</param>
        /// <returns>Um tiposUsuario buscado</returns>
        TiposUsuario BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo tiposUsuario
        /// </summary>
        /// <param name="novotiposUsuario">Objeto novotiposUsuario que será cadastrado</param>
        void Cadastrar(TiposUsuario novotiposUsuario);

        /// <summary>
        /// Atualiza um tiposUsuario existente
        /// </summary>
        /// <param name="id">ID do tiposUsuario que será atualizado</param>
        /// <param name="tiposUsuarioAtualizado">Objeto tiposUsuarioAtualizado com as novas informações</param>
        void Atualizar(int id, TiposUsuario tiposUsuarioAtualizado);

        /// <summary>
        /// Deleta um tiposUsuario existente
        /// </summary>
        /// <param name="id">ID do tiposUsuario que será deletado</param>
        void Deletar(int id);

    }
}
