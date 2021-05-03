using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class TipoDeUsuarioRepository : ITipoDeUsuarioRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        HROADSContext ctx = new HROADSContext();
        public void Atualizar(int id, TiposDeUsuario tipoDeUsuarioAtualizado)
        {
            //Busca um personagem através do id
            TiposDeUsuario tipoDeUsuarioBuscado = ctx.TiposDeUsuarios.Find(id);

            // Verifica se o nome do personagem foi informado

            if (tipoDeUsuarioAtualizado.TipoUsuario != null)
            {
                // Atribui os novos valores aos campos existentes
                tipoDeUsuarioBuscado.TipoUsuario = tipoDeUsuarioAtualizado.TipoUsuario;
            }
            // Atualiza o personagem que foi buscado
            ctx.TiposDeUsuarios.Update(tipoDeUsuarioBuscado);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public TiposDeUsuario BuscarPorId(int id)
        {
            // Retorna o primeiro tipoHabilidade encontrado para o ID informado
            return ctx.TiposDeUsuarios.FirstOrDefault(t => t.IdTipoUsuario == id);
        }

        public void Cadastrar(TiposDeUsuario novoTipoDeUsuario)
        {
            // Adiciona este novoTipoHabilidade
            ctx.TiposDeUsuarios.Add(novoTipoDeUsuario);

            // Salva as informações para serem gravas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // Busca um tipoHabilidade através do seu id
            TiposDeUsuario tipoDeUsuarioBuscado = ctx.TiposDeUsuarios.Find(id);

            // Remove o personagem que foi buscado
            ctx.TiposDeUsuarios.Remove(tipoDeUsuarioBuscado);
            // Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        public List<TiposDeUsuario> Listar()
        {
            return ctx.TiposDeUsuarios.ToList();
        }
    }
}
