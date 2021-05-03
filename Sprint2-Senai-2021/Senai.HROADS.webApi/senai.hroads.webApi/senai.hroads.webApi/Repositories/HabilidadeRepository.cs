using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class HabilidadeRepository : IHabilidadeRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        HROADSContext ctx = new HROADSContext();

        public void Atualizar(int id, Habilidade habilidadeAtualizada)
        {
            Habilidade habilidadeBuscada = ctx.Habilidades.Find(id);

            // Verifica se o nome do tipo de habilidade foi informado
            if (habilidadeAtualizada.Nome != null)
            {
                // Atribui os novos valores aos campos existentes
                habilidadeBuscada.Nome = habilidadeAtualizada.Nome;
            }

            // Atualiza o tipo de habilidade que foi buscado
            ctx.Habilidades.Update(habilidadeBuscada);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public Habilidade BuscarPorId(int id)
        {
            // Retorna o primeiro habilidade encontrada para o ID informado
            return ctx.Habilidades.FirstOrDefault(c => c.IdHabilidade == id);
        }

        public void Cadastrar(Habilidade novaHabilidade)
        {
            // Adiciona este novaHabilidade
            ctx.Habilidades.Add(novaHabilidade);

            // Salva as informações para serem gravas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // Busca uma habilidade através do seu id
            Habilidade habilidadeBuscada = ctx.Habilidades.Find(id);

            // Remove o estúdio que foi buscado
            ctx.Habilidades.Remove(habilidadeBuscada);

            // Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        public List<Habilidade> Listar()
        {
            return ctx.Habilidades.ToList();
        }

        public List<Habilidade> ListarTiposHabilidades()
        {
            // Retorna uma lista de habilidades com seus tipos

            return (List<Habilidade>)ctx.Habilidades.Include(t => t.IdTipoHabilidadeNavigation.Nome.ToList());
        }
    }
}
