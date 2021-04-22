using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi_.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
                       //Criação string/ Nome do servidor/             Nome do banco de dados/ Usuário/    Senha 

        private string stringConexao = "Data Source=DESKTOP-RGIIP6F; initial catalog=inlock_games_manha; user Id= sa; pwd=Semprepea10";
        //WINDOWS = private string stringConexao = "Data Source=DESKTOP-RGIIP6F; initial catalog=inlock_games_manha; integrated security=true";


        public void AtualizarIdCorpo(EstudioDomain estudio)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada
                string queryUpdateIdBody = "UPDATE Estudios SET nomeEstudio = @nomeE WHERE idEstudio = @ID";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryUpdateIdBody, con))
                {
                    // Passa os valores para os parâmetros

                    cmd.Parameters.AddWithValue("@ID", estudio.idEstudio);

                    cmd.Parameters.AddWithValue("@nomeE", estudio.nomeEstudio);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int id, EstudioDomain estudio)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada
                string queryUpdateIdUrl = "UPDATE Estudios SET nomeEstudio = @nomeE WHERE idEstudio = @ID";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {
                    // Passa os valores para os parâmetros

                    cmd.Parameters.AddWithValue("@ID", id);

                    cmd.Parameters.AddWithValue("@nomeE", estudio.nomeEstudio);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }

        }

            public EstudioDomain BuscarPorId(int id)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada
                string querySelectById = " SELECT idEstudio, nomeEstudio FROM Estudios WHERE idEstudio = @ID ";

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
                        // Se sim, instancia um novo objeto FuncionarioBuscado do tipo FuncionarioDomain
                        EstudioDomain estudioBuscado = new EstudioDomain()
                        {
                            // Atribui à propriedade idFuncionario o valor da coluna "idFuncionario" da tabela do banco de dados
                            idEstudio = Convert.ToInt32(rdr["idEstudio"]),

                            // Atribui à propriedade nome o valor da coluna "nome" da tabela do banco de dados
                            nomeEstudio = rdr["nomeEstudio"].ToString(),

                        };

                        // Retorna o estudioBuscado com os dados obtidos
                        return estudioBuscado;
                    }

                    // Se não, retorna null
                    return null;
                }
            }
        }

        public void Cadastrar(EstudioDomain novoEstudio)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                // Declara a query que será executada
                string queryInsert = "INSERT INTO Estudios(nomeEstudio ) VALUES(@nomeE) ";


                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa o valor para o parâmetro @Nome
                    cmd.Parameters.AddWithValue("@nomeE", novoEstudio.nomeEstudio);

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
                string queryDelete = "DELETE FROM Estudios WHERE idEstudio = @ID";

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

        public List<EstudioDomain> ListarTodos()
        {
            // Cria uma lista listaFuncionarios onde serão armazenados os dados
            List<EstudioDomain> listaEstudio = new List<EstudioDomain>();

            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT idEstudio, nomeEstudio FROM Estudios";

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
                        EstudioDomain estudio = new EstudioDomain()
                        {
                            // Atribui à propriedade idfuncionario o valor da primeira coluna da tabela do banco de dados
                            idEstudio= Convert.ToInt32(rdr[0]),

                            // Atribui à propriedade nome o valor da segunda coluna da tabela do banco de dados
                            nomeEstudio = rdr[1].ToString()
                        };

                        // Adiciona o objeto funcionario à lista listaFuncionarios
                        listaEstudio.Add(estudio);
                    }
                }
            }

            // Retorna a lista de gêneros
            return listaEstudio;
        }
    }
}
