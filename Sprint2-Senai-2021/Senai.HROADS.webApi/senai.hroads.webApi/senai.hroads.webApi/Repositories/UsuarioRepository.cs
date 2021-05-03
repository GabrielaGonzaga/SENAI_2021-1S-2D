using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        HROADSContext ctx = new HROADSContext();

        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            //Busca um personagem através do id
            Usuario usuarioBuscado = ctx.Usuarios .Find(id);

            // Verifica se o nome do personagem foi informado

            if (usuarioAtualizado != null)
            {
                // Atribui os novos valores aos campos existentes
                usuarioBuscado = usuarioAtualizado;
            }
            // Atualiza o personagem que foi buscado
            ctx.Usuarios.Update(usuarioBuscado);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public Usuario BuscarPorId(int id)
        {
            // Retorna o primeiro usuario encontrado para o ID informado
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            // Adiciona este novoUsuario
            ctx.Usuarios.Add(novoUsuario);

            // Salva as informações para serem gravas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // Busca um usuario através do seu id
            Usuario usuarioBuscado = ctx.Usuarios.Find(id);

            // Remove o personagem que foi buscado
            ctx.Usuarios.Remove(usuarioBuscado);

            // Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }

        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="email">e-mail do usuário</param>
        /// <param name="senha">senha do usuário</param>
        /// <returns>Um objeto do tipo Usuario que foi buscado</returns>
        public Usuario Login(string email, string senha)
        {
            // Retorna o usuário encontrado através do e-mail e da senha
            return ctx.Usuarios.FirstOrDefault(l => l.Email == email && l.Senha == senha);
        }
    }
}
