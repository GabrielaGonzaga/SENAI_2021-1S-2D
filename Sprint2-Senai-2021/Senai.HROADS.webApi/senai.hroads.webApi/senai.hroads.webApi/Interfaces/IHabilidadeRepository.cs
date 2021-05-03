using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IHabilidadeRepository
    {
        /// <summary>
        /// Lista todas as habilidades
        /// </summary>
        /// <returns>Uma lista de habilidades</returns>
        List<Habilidade> Listar();

        /// <summary>
        /// Busca uma habilidade através do seu ID
        /// </summary>
        /// <param name="id">ID da habilidade que será buscada</param>
        /// <returns>Uma habilidade buscada</returns>
        Habilidade BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma nova habilidade
        /// </summary>
        /// <param name="novaHabilidade">Objeto novoHabilidade que será cadastrado</param>
        void Cadastrar(Habilidade novaHabilidade);

        /// <summary>
        /// Atualiza uma habilidade existente
        /// </summary>
        /// <param name="id">ID da habilidade que será atualizada</param>
        /// <param name="habilidadeAtualizada">Objeto habilidadeAtualizada com as novas informações</param>
        void Atualizar(int id, Habilidade habilidadeAtualizada);

        /// <summary>
        /// Deleta uma habilidade existente
        /// </summary>
        /// <param name="id">ID da habilidade que será deletada</param>
        void Deletar(int id);

        /// <summary>
        /// Lista todas as habilidades com seus respectivos tipos
        /// </summary>
        /// <returns>Uma lista de habilidades com seus tipos</returns>
        List<Habilidade> ListarTiposHabilidades();

    }
}


