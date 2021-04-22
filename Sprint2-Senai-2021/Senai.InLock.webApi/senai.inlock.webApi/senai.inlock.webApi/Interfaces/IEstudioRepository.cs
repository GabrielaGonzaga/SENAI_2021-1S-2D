using senai.inlock.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Interfaces
{
    interface IEstudioRepository
    {
        /// <summary>
        /// Interface responsável pelo repositório EstudiosRepository
        /// </summary>
        
      
        /// <summary>
        /// Retorna todos os Estúdios
        /// </summary>
        /// <returns>Uma lista com os Estúdios</returns>
        List<EstudioDomain> ListarTodos();

        /// <summary>
        /// Busca um Estúdio através do seu id
        /// </summary>
        /// <param name="id">id do estudio que será buscado</param>
        /// <returns>Um objeto do tipo EstudiosDomain que foi buscado</returns>
        EstudioDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo Estúdio
        /// </summary>
        /// <param name="novoEstudio">Objeto novoestudio que será cadastrado</param>
        void Cadastrar(EstudioDomain novoEstudio);


        /// <summary>
        /// Atualiza um Estúdio existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="estudio">Objeto estudio com as novas informações</param>
        void AtualizarIdCorpo(EstudioDomain estudio);

        /// <summary>
        /// Atualiza um Estúdio existente passando o id pela url da requisição
        /// </summary>
        /// /// <param name="id">id do Estúdio que será atualizado</param>
        /// <param name="estudio">Objeto estudio com as novas informações</param>
        void AtualizarIdUrl(int id, EstudioDomain estudio);

        /// <summary>
        /// Deleta um Estúdio
        /// </summary>
        /// <param name="id">id do Estúdio que será deletado</param>
        void Deletar(int id);


    }
}
