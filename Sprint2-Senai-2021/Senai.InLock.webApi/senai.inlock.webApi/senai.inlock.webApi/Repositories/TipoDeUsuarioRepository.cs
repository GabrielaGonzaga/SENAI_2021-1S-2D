using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Repositories
{

    public class TipoDeUsuarioRepository : ITipoDeUsuarioRepository
    {
        private string stringConexao = "Data Source=DESKTOP-RGIIP6F; initial catalog=inlock_games_manha; user Id= sa; pwd=Semprepea10";

        public void AtualizarIdCorpo(TipoDeUsuarioDomain tipodeusuario)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada
                string queryUpdateIdBody = "UPDATE TiposDeUsuarios SET titulo = @titulo WHERE idTipoUsuario = @ID";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryUpdateIdBody, con))
                {
                    // Passa os valores para os parâmetros

                    cmd.Parameters.AddWithValue("@ID", tipodeusuario.idTipoUsuario);

                    cmd.Parameters.AddWithValue("@titulo", tipodeusuario.titulo);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int id, TipoDeUsuarioDomain tipodeusuario)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada
                string queryUpdateIdUrl = "UPDATE TiposDeUsuarios SET titulo = @titulo WHERE idTipoUsuario = @ID";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {
                    // Passa os valores para os parâmetros

                    cmd.Parameters.AddWithValue("@ID", id);

                    cmd.Parameters.AddWithValue("@titulo", tipodeusuario.titulo);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public TipoDeUsuarioDomain BuscarPorId(int id)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada
                string querySelectById = " SELECT idTipoUsuario, titulo FROM TiposDeUsuario WHERE idTipoUsuario = @ID ";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader rdr para receber os valores do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    // Passa o valor para o parâmetro @ID
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Verifica se o resultado da query retornou algum registro
                    if (rdr.Read())
                    {

                        TipoDeUsuarioDomain tipoDeUsuarioBuscado = new TipoDeUsuarioDomain()
                        {
                            idTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"]),

                            titulo = rdr["titulo"].ToString(),

                        };
                        return tipoDeUsuarioBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(TipoDeUsuarioDomain novoTipoDeUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                // Declara a query que será executada
                string queryInsert = "INSERT INTO TipoDeUsuario(titulo ) VALUES(@titulo) ";


                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa o valor para o parâmetro @Nome
                    cmd.Parameters.AddWithValue("@titulo", novoTipoDeUsuario.titulo);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada passando o valor como parâmetro
                string queryDelete = "DELETE FROM TiposDeUsuarios WHERE idTipoUsuario = @ID";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    // Define o valor do id recebido no método como o valor do parâmetro @ID
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<TipoDeUsuarioDomain> ListarTodos()
        {
            // Cria uma lista listaFuncionarios onde serão armazenados os dados
            List<TipoDeUsuarioDomain> listaTipoDeUsuario = new List<TipoDeUsuarioDomain>();

            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT idTipoUsuario, titulo FROM TiposDeUsuarios";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader rdr para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para serem lidos no rdr, o laço se repete
                    while (rdr.Read())
                    {
                        // Instacia um objeto funcionario do tipo FuncionarioDomain
                        TipoDeUsuarioDomain tipoDeUsuario = new TipoDeUsuarioDomain()
                        {
                            // Atribui à propriedade idfuncionario o valor da primeira coluna da tabela do banco de dados
                            idTipoUsuario = Convert.ToInt32(rdr[0]),

                            // Atribui à propriedade nome o valor da segunda coluna da tabela do banco de dados
                            titulo = rdr[1].ToString()
                        };

                        // Adiciona o objeto funcionario à lista listaFuncionarios
                        listaTipoDeUsuario.Add(tipoDeUsuario);
                    }
                }
            }

            // Retorna a lista de gêneros
            return listaTipoDeUsuario;
        }
    }
}

