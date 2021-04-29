using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class PersonagemRepository : IPersonagemRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        HROADSContext ctx = new HROADSContext();

        public void Atualizar(int id, Personagen personagemAtualizado)
        {
            //Busca um personagem através do id
            Personagen personagemBuscado = ctx.Personagens.Find(id);

            // Verifica se o nome do personagem foi informado
            if (personagemAtualizado.Nome != null)
            {
                // Atribui os novos valores aos campos existentes
                personagemBuscado.Nome = personagemAtualizado.Nome;
                personagemBuscado.IdClasse = personagemAtualizado.IdClasse;
                personagemBuscado.CapacidadeMaVida = personagemAtualizado.CapacidadeMaVida;
                personagemBuscado.CapacidadeMaMana = personagemAtualizado.CapacidadeMaMana;
                personagemBuscado.DataAtualizacao = personagemAtualizado.DataAtualizacao;
                personagemBuscado.DataCriacao = personagemAtualizado.DataCriacao;
                personagemBuscado.IdUsuario = personagemAtualizado.IdUsuario;
            }

            // Atualiza o personagem que foi buscado
            ctx.Personagens.Update(personagemBuscado);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public Personagen BuscarPorId(int id)
        {
            // Retorna o primeiro estúdio encontrado para o ID informado
            return ctx.Personagens.FirstOrDefault(p=> p.IdPersonagem == id);
        }

        public void Cadastrar(Personagen novoPersonagem)
        {
            // Adiciona este novoEstudio
            ctx.Personagens.Add(novoPersonagem);

            // Salva as informações para serem gravas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // Busca um estúdio através do seu id
            Personagen personagemBuscado = ctx.Personagens.Find(id);

            // Remove o estúdio que foi buscado
            ctx.Personagens.Remove(personagemBuscado);

            // Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        public List<Personagen> Listar()
        {
            return ctx.Personagens.ToList();
        }

        public List<Personagen> ListarJogador()
        {
            throw new NotImplementedException();
        }
    }
}
