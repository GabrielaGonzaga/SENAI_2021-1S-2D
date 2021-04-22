using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Repositories
{

    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source=DESKTOP-RGIIP6F; initial catalog=inlock_games_manha; user Id= sa; pwd=Semprepea10";
        public void AtualizarIdCorpo(UsuarioDomain usuario)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, UsuarioDomain usuario)
        {
            throw new NotImplementedException();
        }

        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Define o comando a ser executado no banco de dados
                string querySelect = "SELECT idUsuario, email, senha FROM Usuarios WHERE email = @email AND senha = @senha;";

                // Define o comando cmd passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    // Define os valores dos parâmetros
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando e armazena os dados no objeto rdr
                    SqlDataReader rdr = cmd.ExecuteReader();

                    // Caso dados tenham sido obtidos
                    if (rdr.Read())
                    {
                        // Cria um objeto do tipo UsuarioDomain
                        UsuarioDomain usuarioBuscado = new UsuarioDomain
                        {
                            // Atribui às propriedades os valores das colunas do banco de dados
                            idUsuario = Convert.ToInt32(rdr["idUsuario"]),
                            email = rdr["email"].ToString(),
                            senha = rdr["senha"].ToString()
                        };

                        // Retorna o usuário buscado
                        return usuarioBuscado;
                    }

                    // Caso não encontre um email e senha correspondente, retorna null
                    return null;
                }
            }


        }

        public UsuarioDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(UsuarioDomain novoUsuario)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<UsuarioDomain> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
