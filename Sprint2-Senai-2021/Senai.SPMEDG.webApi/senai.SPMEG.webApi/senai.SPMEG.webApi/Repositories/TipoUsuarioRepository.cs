using senai.SPMEG.webApi.Contexts;
using senai.SPMEG.webApi.Domains;
using senai.SPMEG.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SPMEG.webApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        SPMEDGContext ctx = new SPMEDGContext();
       
        public void Atualizar(int id, TiposUsuario tiposUsuarioAtualizado)
        {
            // Busca um tipo de Usuario através do id
            TiposUsuario tipoUsuarioBuscado = ctx.TiposUsuarios.Find(id);

            // Verifica se o título do tipo de Usuario foi informado
            if (tiposUsuarioAtualizado.TituloTipoUsuario != null)
            {
                // Atribui os novos valores ao campos existentes
                tipoUsuarioBuscado.TituloTipoUsuario = tiposUsuarioAtualizado.TituloTipoUsuario;
            }

            // Atualiza o tipo de Usuario que foi buscado
            ctx.TiposUsuarios.Update(tipoUsuarioBuscado);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        public TiposUsuario BuscarPorId(int id)
        {
            return ctx.TiposUsuarios.FirstOrDefault(tu => tu.IdTipoUsuario == id);
        }

        public void Cadastrar(TiposUsuario novoTipoUsuario)
        {
            // Adiciona este novoTipUsuario
            ctx.TiposUsuarios.Add(novoTipoUsuario);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // Busca um tipo de Usuario através do id
            TiposUsuario tipoUsuarioBuscado = ctx.TiposUsuarios.Find(id);

            // Remove o tipo de Usuario que foi buscado
            ctx.TiposUsuarios.Remove(tipoUsuarioBuscado);

            // Salva as alterações
            ctx.SaveChanges();
        }

        public List<TiposUsuario> Listar()
        {
            // Retorna uma lista com todas as informações dos tipos de usuários
            return ctx.TiposUsuarios.ToList();
        }
    }
}
