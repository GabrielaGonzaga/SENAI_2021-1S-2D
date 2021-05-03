using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface ITipoHabilidadeRepository
    {
        /// <summary>
        /// Lista todos os tiposHabilidades
        /// </summary>
        /// <returns>Uma lista de tiposHabilidades</returns>
        List<TipoHabilidade> Listar();

        /// <summary>
        /// Busca um tipoHabilidade através do seu ID
        /// </summary>
        /// <param name="id">ID do tipoHabilidade que será buscado</param>
        /// <returns>Um tipoHabilidade buscado</returns>
        TipoHabilidade BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo tipoHabilidade
        /// </summary>
        /// <param name="novoTipoHabilidade">Objeto novoTipoHabilidade que será cadastrado</param>
        void Cadastrar(TipoHabilidade novoTipoHabilidade);

        /// <summary>
        /// Atualiza um tipoHabilidade existente
        /// </summary>
        /// <param name="id">ID do tipoHabilidade que será atualizado</param>
        /// <param name="tipoHabilidadeAtualizado">Objeto tipoHabilidadeAtualizado com as novas informações</param>
        void Atualizar(int id, TipoHabilidade tipoHabilidadeAtualizado);

        /// <summary>
        /// Deleta um tipoHabilidade existente
        /// </summary>
        /// <param name="id">ID do tipoHabilidade que será deletado</param>
        void Deletar(int id);

    }
}

