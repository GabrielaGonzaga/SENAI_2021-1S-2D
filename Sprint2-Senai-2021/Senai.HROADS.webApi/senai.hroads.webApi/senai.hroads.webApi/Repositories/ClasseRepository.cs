using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class ClasseRepository : IClasseRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        HROADSContext ctx = new HROADSContext();

        public void Atualizar(int id, Class classeAtualizada)
        {
            Class classeBuscada = ctx.Classes.Find(id);

            // Verifica se o nome do tipo de evento foi informado
            if (classeAtualizada.Nome != null)
            {
                // Atribui os novos valores aos campos existentes
                classeBuscada.Nome = classeAtualizada.Nome;
            }

            // Atualiza o tipo de evento que foi buscado
            ctx.Classes.Update(classeBuscada);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public Class BuscarPorId(int id)
        {
            // Retorna o primeiro classe encontrada para o ID informado
            return ctx.Classes.FirstOrDefault(c => c.IdClasse == id);
        }

        public void Cadastrar(Class novaClasse)
        {
            // Adiciona este novaClass
            ctx.Classes.Add(novaClasse);

            // Salva as informações para serem gravas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // Busca uma classe através do seu id
            Class classeBuscada = ctx.Classes.Find(id);

            // Remove o estúdio que foi buscado
            ctx.Classes.Remove(classeBuscada);

            // Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        public List<Class> Listar()
        {
            return ctx.Classes.ToList();
        }

        
    }
}
