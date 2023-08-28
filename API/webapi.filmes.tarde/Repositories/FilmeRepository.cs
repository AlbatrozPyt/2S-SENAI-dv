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
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, FilmeDomain filme)
        {
            throw new NotImplementedException();
        }

        public FilmeDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(FilmeDomain novoFilme)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<FilmeDomain> ListarTodos()
        {
            // Cria uma lista de generos onde sera armazenados os generos
            List<GeneroDomain> listaGenero = new List<GeneroDomain>();

            // Cria uma lista de filmes
            List<FilmeDomain> listaFilme = new List<FilmeDomain>();

            // Using usa e encerra o recurso
            // Declara a Sql Connection passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a instrucao a ser executada
                string querySelectAll = "SELECT IdGenero, Nome FROM Genero";

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
                        GeneroDomain genero = new GeneroDomain()
                        {
                            // Atribui a propriedade IdGenero o valor da primeira coluna da primeira tabela
                            IdGenero = Convert.ToInt32(rdr[0]),

                            // Atribui a propriedade Nome o valor da coluna
                            Nome = (rdr[1]).ToString()
                        };

                        // Adiciona o objeto a lista
                        listaGenero.Add(genero);
                    }
                }
            }

            // Retorna a lista de generos
            return listaGenero;
        }
    }
}
    }
}
