using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    public class GeneroRepository : IGeneroRepository
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

        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///  Esse metodo cadastra um novo genero
        /// </summary>
        /// <param name="novoGenero"></param>
        /// <exception cref="NotImplementedException">Objeto com as informacoes que serao cadastradas</exception>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            // Declara o SqlConnection passando a string conexao
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a query que sera executada
                string queryInsert = "INSERT INTO Genero(Nome) VALUES('" + novoGenero.Nome + "')";


                // Declara o SqlCommand
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Abre a conexao com o banco de dados
                    con.Open();

                    // Executa a query(INSERT, UPDATE e DELETE)
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Listar todos os objetos do tipo genero
        /// </summary>
        /// <returns>Lista de objetos do tipo genero</returns>
        public List<GeneroDomain> ListarTodos()
        {
            // Cria uma lista de generos onde sera armazenados os generos
           List<GeneroDomain> listaGenero = new List<GeneroDomain>();

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
