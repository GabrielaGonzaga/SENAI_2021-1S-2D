using senai.inlock.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Interfaces
{
    interface ITipoDeUsuarioRepository
    {
        /// <summary>
        /// Interface responsável pelo repositório TipoDeUsuariosRepository
        /// </summary>


        /// <summary>
        /// Retorna todos os TipoDeUsuarios
        /// </summary>
        /// <returns>Uma lista com os TipoDeUsuarios</returns>
        List<TipoDeUsuarioDomain> ListarTodos();

        /// <summary>
        /// Busca um TipoDeUsuario através do seu id
        /// </summary>
        /// <param name="id">id do tipodeusuario que será buscado</param>
        /// <returns>Um objeto do tipo TipoDeUsuariosDomain que foi buscado</returns>
        TipoDeUsuarioDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo TipoDeUsuario
        /// </summary>
        /// <param name="novoTipoDeUsuario">Objeto novotipodeusuario que será cadastrado</param>
        void Cadastrar(TipoDeUsuarioDomain novoTipoDeUsuario);


        /// <summary>
        /// Atualiza um TipoDeUsuario existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="tipodeusuario">Objeto tipodeusuario com as novas informações</param>
        void AtualizarIdCorpo(TipoDeUsuarioDomain tipodeusuario);

        /// <summary>
        /// Atualiza um TipoDeUsuario existente passando o id pela url da requisição
        /// </summary>
        /// /// <param name="id">id do TipoDeUsuario que será atualizado</param>
        /// <param name="tipodeusuario">Objeto tipodeusuario com as novas informações</param>
        void AtualizarIdUrl(int id, TipoDeUsuarioDomain tipodeusuario);

        /// <summary>
        /// Deleta um TipoDeUsuario
        /// </summary>
        /// <param name="id">id do TipoDeUsuario que será deletado</param>
        void Deletar(int id);
    }
}
