using senai.inlock.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Interface responsável pelo repositório UsuariosRepository
        /// </summary>


        /// <summary>
        /// Retorna todos os Usuarios
        /// </summary>
        /// <returns>Uma lista com os Usuarios</returns>
        List<UsuarioDomain> ListarTodos();

        /// <summary>
        /// Busca um Usuario através do seu id
        /// </summary>
        /// <param name="id">id do usuario que será buscado</param>
        /// <returns>Um objeto do tipo UsuariosDomain que foi buscado</returns>
        UsuarioDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo Usuario
        /// </summary>
        /// <param name="novoUsuario">Objeto novousuario que será cadastrado</param>
        void Cadastrar(UsuarioDomain novoUsuario);


        /// <summary>
        /// Atualiza um Usuario existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="usuario">Objeto usuario com as novas informações</param>
        void AtualizarIdCorpo(UsuarioDomain usuario);

        /// <summary>
        /// Atualiza um Usuario existente passando o id pela url da requisição
        /// </summary>
        /// /// <param name="id">id do Usuario que será atualizado</param>
        /// <param name="usuario">Objeto usuario com as novas informações</param>
        void AtualizarIdUrl(int id, UsuarioDomain usuario);

        /// <summary>
        /// Deleta um Usuario
        /// </summary>
        /// <param name="id">id do Usuario que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Valida o usuario
        /// </summary>
        /// <param name="email">email do usuario</param>
        /// <param name="senha">senha do usuario</param>
        /// <returns>Um objeto do tipo UsuarioDomain que foi buscado</returns>
        UsuarioDomain BuscarPorEmailSenha(string email, string senha);


    }
}
