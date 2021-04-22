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
    public class JogoRepository : IJogoRepository
    {
                       //Criação string/ Nome do servidor/             Nome do banco de dados/ Usuário/    Senha 

        private string stringConexao = "Data Source=DESKTOP-RGIIP6F; initial catalog=inlock_games_manha; user Id= sa; pwd=Semprepea10";
        //WINDOWS = private string stringConexao = "Data Source=DESKTOP-RGIIP6F; initial catalog=inlock_games_manha; integrated security=true";


        public void AtualizarIdCorpo(JogoDomain jogo)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada
                string queryUpdateIdBody = "UPDATE Jogos SET nomeJogo, descricao, dataLancamento, valor, idEstudio = @nomeJ, @descricao, @dataL, @valor, @idE WHERE idJogo = @ID";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryUpdateIdBody, con))
                {
                    // Passa os valores para os parâmetros

                    cmd.Parameters.AddWithValue("@ID", jogo.idJogo);

                    cmd.Parameters.AddWithValue("@nomeJ", jogo.nomeJogo);

                    cmd.Parameters.AddWithValue("@descricao", jogo.descricao);

                    cmd.Parameters.AddWithValue("@dataL", jogo.dataLancamento);

                    cmd.Parameters.AddWithValue("@valor", jogo.valor);

                    cmd.Parameters.AddWithValue("@idE", jogo.idEstudio);
                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void AtualizarIdUrl(int id, JogoDomain jogo)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada
                string queryUpdateIdUrl = "UPDATE Jogos SET nomeJogo, descricao, dataLancamento, valor, idEstudio = @nomeJ, @descricao, @dataL, @valor, @idE WHERE idJogo = @ID";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {
                    // Passa os valores para os parâmetros

                    cmd.Parameters.AddWithValue("@ID", id);

                    cmd.Parameters.AddWithValue("@nomeJ", jogo.nomeJogo);

                    cmd.Parameters.AddWithValue("@descricao", jogo.descricao);

                    cmd.Parameters.AddWithValue("@dataL", jogo.dataLancamento);

                    cmd.Parameters.AddWithValue("@valor", jogo.valor);

                    cmd.Parameters.AddWithValue("@idE", jogo.idEstudio);
                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public JogoDomain BuscarPorId(int id)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada
                string querySelectById = " SELECT idJogo, nomeJogo, descricao, dataLancamento, valor, idEstudio FROM Jogos WHERE idJogo = @ID";

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
                        JogoDomain jogoBuscado = new JogoDomain()
                        {
                            // Atribui à propriedade idFuncionario o valor da coluna "idFuncionario" da tabela do banco de dados
                            idJogo = Convert.ToInt32(rdr["idJogo"]),

                            // Atribui à propriedade nome o valor da coluna "nome" da tabela do banco de dados
                            nomeJogo = rdr["nomeJogo"].ToString(),

                            // Atribui à propriedade nome o valor da coluna "descricao" da tabela do banco de dados
                            descricao = rdr["descricao"].ToString(),

                            // Atribui à propriedade nome o valor da coluna "dataLancamento" da tabela do banco de dados
                            dataLancamento = Convert.ToDateTime(value: rdr["dataLancamento"]),

                            // Atribui à propriedade nome o valor da coluna "valor" da tabela do banco de dados
                            valor = rdr["valor"].ToString(),

                            // Atribui à propriedade idFuncionario o valor da coluna "idEstudio" da tabela do banco de dados
                            idEstudio = Convert.ToInt32(rdr["idEstudio"])
                        };

                        // Retorna o jogoBuscado com os dados obtidos
                        return jogoBuscado;
                    }

                    // Se não, retorna null
                    return null;
                }
            }
        }

        public void Cadastrar(JogoDomain novoJogo)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                // Declara a query que será executada
                string queryInsert = "INSERT INTO Jogos(nomeJogo, descricao, dataLancamento, valor, idEstudio  ) VALUES(@nomeJ, @descricao, @dataL, @valor, @idE) ";


                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa o valor para o parâmetros

                    cmd.Parameters.AddWithValue("@nomeJ", novoJogo.nomeJogo);

                    cmd.Parameters.AddWithValue("@descricao", novoJogo.descricao);

                    cmd.Parameters.AddWithValue("@dataL", novoJogo.dataLancamento);

                    cmd.Parameters.AddWithValue("@valor", novoJogo.valor);

                    cmd.Parameters.AddWithValue("@idE", novoJogo.idEstudio);

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
                string queryDelete = "DELETE FROM Jogos WHERE idJogo = @ID";

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

        public List<JogoDomain> ListarTodos()
        {
            // Cria uma lista listaFuncionarios onde serão armazenados os dados
            List<JogoDomain> listaJogo = new List<JogoDomain>();

            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT idJogo, nomeJogo, descricao, dataLancamento, valor, idEstudio FROM Jogos";

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
                        JogoDomain jogo = new JogoDomain()
                        {
                            // Atribui à propriedade idFuncionario o valor da coluna "idFuncionario" da tabela do banco de dados
                            idJogo = Convert.ToInt32(rdr["idJogo"]),

                            // Atribui à propriedade nome o valor da coluna "nome" da tabela do banco de dados
                            nomeJogo = rdr["nomeJogo"].ToString(),

                            // Atribui à propriedade nome o valor da coluna "descricao" da tabela do banco de dados
                            descricao = rdr["descricao"].ToString(),

                            // Atribui à propriedade nome o valor da coluna "dataLancamento" da tabela do banco de dados
                            dataLancamento = Convert.ToDateTime(value: rdr["dataLancamento"]),

                            // Atribui à propriedade nome o valor da coluna "valor" da tabela do banco de dados
                            valor = rdr["valor"].ToString(),

                            // Atribui à propriedade idFuncionario o valor da coluna "idEstudio" da tabela do banco de dados
                            idEstudio = Convert.ToInt32(rdr["idEstudio"])
                        };

                        // Adiciona o objeto funcionario à lista listaFuncionarios
                        listaJogo.Add(jogo);
                    }
                }
            }

            // Retorna a lista de gêneros
            return listaJogo;
        }
    }
}
    

