using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class TipoHabilidadeRepository : ITipoHabilidadeRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        HROADSContext ctx = new HROADSContext();

        public void Atualizar(int id, TipoHabilidade tipoHabilidadeAtualizado)
        {
            //Busca um personagem através do id
            TipoHabilidade tipoHabilidadeBuscado = ctx.TipoHabilidades.Find(id);

            // Verifica se o nome do personagem foi informado

            if (tipoHabilidadeAtualizado.Nome != null)
            {
                // Atribui os novos valores aos campos existentes
                tipoHabilidadeBuscado.Nome = tipoHabilidadeAtualizado.Nome;
            }
            // Atualiza o personagem que foi buscado
            ctx.TipoHabilidades.Update(tipoHabilidadeBuscado);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();

        }

        public TipoHabilidade BuscarPorId(int id)
        {
            // Retorna o primeiro tipoHabilidade encontrado para o ID informado
            return ctx.TipoHabilidades.FirstOrDefault(t => t.IdTipoHabilidade== id);
        }

        public void Cadastrar(TipoHabilidade novoTipoHabilidade)
        {
            // Adiciona este novoTipoHabilidade
            ctx.TipoHabilidades.Add(novoTipoHabilidade);

            // Salva as informações para serem gravas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // Busca um tipoHabilidade através do seu id
           TipoHabilidade tipoHabilidadeBuscado = ctx.TipoHabilidades.Find(id);

            // Remove o personagem que foi buscado
            ctx.TipoHabilidades.Remove(tipoHabilidadeBuscado);

            // Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        public List<TipoHabilidade> Listar()
        {
            return ctx.TipoHabilidades.ToList();
        }
    }
}
