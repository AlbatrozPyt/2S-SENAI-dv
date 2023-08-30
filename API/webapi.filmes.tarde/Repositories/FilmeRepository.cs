using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        /// <summary>
        /// String de conexao com o banco de dados, que recebe os seguintes parametros:
        /// Data Source: Nome do servidor do banco
        /// Initial Catalog: Nome do banco de dados
        /// Autenticacao:
        ///     - Windons: Integrated  Security True
        ///     - Sql Server: User Id = sa; Pwd = senha;
        /// </summary>

        private string StringConexao = "Data Source = NOTE20-S15; Initial Catalog = Filmes_Tarde; User Id = sa; Pwd = Senai@134";

        public void AtualizarIdCorpo(FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "UPDATE Filme SET Titulo = @Titulo WHERE IdFilme = @IdFilme";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                    cmd.Parameters.AddWithValue("@IdFilme", filme.IdFilme);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int id, FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "UPDATE Filme SET Titulo = @Titulo WHERE IdFilme = @Id";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                    cmd.Parameters.AddWithValue("@Id", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public FilmeDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsertById = "SELECT Filme.IdFilme, Filme.IdGenero, Genero.Nome, Filme.Titulo FROM Filme LEFT JOIN  Genero on Genero.IdGenero = Filme.IdGenero WHERE IdFilme = @IdFilme";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryInsertById, con))
                {
                    cmd.Parameters.AddWithValue("@IdFilme", id);

                    con.Open();

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain()
                        {
                            IdFilme = Convert.ToInt32(rdr[0]),
                            IdGenero = Convert.ToInt32(rdr[1]),
                            Titulo = rdr[2].ToString()
                        };

                        GeneroDomain genero = new GeneroDomain()
                        {
                            IdGenero = Convert.ToInt32(rdr[1]),
                            Nome = rdr["Nome"].ToString()
                        };

                        filme.Genero = genero;

                        return filme;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(FilmeDomain novoFilme)
        {
            // Declara o SqlConnection passando a string conexao
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a query que sera executada
                string queryInsert = "INSERT INTO Filme(IdGenero, Titulo) VALUES(@IdGenero, @Titulo)";


                // Declara o SqlCommand
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", novoFilme.IdGenero);
                    cmd.Parameters.AddWithValue("@Titulo", novoFilme.Titulo);

                    // Abre a conexao com o banco de dados
                    con.Open();

                    // Executa a query(INSERT, UPDATE e DELETE)
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {

                string queryInsert = "DELETE  FROM Filme WHERE IdFilme = @IdFilme";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@IdFilme", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<FilmeDomain> ListarTodos()
        {
            // Cria uma lista de filmes
            List<FilmeDomain> listaFilme = new List<FilmeDomain>();

            // Using usa e encerra o recurso
            // Declara a Sql Connection passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a instrucao a ser executada
                //  string querySelectAll = " SELECT IdFilme, IdGenero, Titulo FROM Filme";
                string querySelectAll = " SELECT Filme.IdFilme, Filme.IdGenero, Genero.Nome, Filme.Titulo FROM Filme LEFT JOIN  Genero on Genero.IdGenero = Filme.IdGenero";

                // Abre a conexao com o banco de dados
                con.Open();

                // Declara o SqlDataReader para percorrer(ler) a tabela no banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand passando a query que sera executada e a conexao.
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    // Executa a query e armazena os dados rdr
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para serem lidos no rdr
                    // O laco se repetira
                    while (rdr.Read())
                    {
                      
                        FilmeDomain filme = new FilmeDomain()
                        {
                            IdFilme = Convert.ToInt32(rdr[0]),
                            IdGenero = Convert.ToInt32(rdr[1]),
                            Titulo = rdr["Titulo"].ToString(),
                        };

                        GeneroDomain genero = new GeneroDomain()
                        {
                            IdGenero = Convert.ToInt32(rdr[1]),
                            Nome = rdr["Nome"].ToString()
                        };

                        filme.Genero = genero;

                        // Adiciona o objeto a lista
                        listaFilme.Add(filme);
                    }
                }
            }

            // Retorna a lista de generos
            return listaFilme;
        }
    }
}
