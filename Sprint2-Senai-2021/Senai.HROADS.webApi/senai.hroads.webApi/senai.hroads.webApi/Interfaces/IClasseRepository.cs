using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IClasseRepository
    {
        /// <summary>
        /// Lista todas as classes
        /// </summary>
        /// <returns>Uma lista de classes</returns>
        List<Class> Listar();

        /// <summary>
        /// Busca uma classe através do seu ID
        /// </summary>
        /// <param name="id">ID da classe que será buscada</param>
        /// <returns>Uma classe buscada</returns>
        Class BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma nova classe
        /// </summary>
        /// <param name="novaClasse">Objeto novoClasse que será cadastrado</param>
        void Cadastrar(Class novaClasse);

        /// <summary>
        /// Atualiza uma classe existente
        /// </summary>
        /// <param name="id">ID da classe que será atualizada</param>
        /// <param name="classeAtualizada">Objeto classeAtualizada com as novas informações</param>
        void Atualizar(int id, Class classeAtualizada);

        /// <summary>
        /// Deleta uma classe existente
        /// </summary>
        /// <param name="id">ID da classe que será deletada</param>
        void Deletar(int id);

    }
}
