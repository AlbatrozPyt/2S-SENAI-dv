using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = "Data Source = NOTE20-S15; Initial Catalog = Filmes_Tarde; User Id = sa; Pwd = Senai@134";

        public UsuarioDomain Login(string Email, string Senha)
        {

            UsuarioDomain user = new UsuarioDomain();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "SELECT IdUsuario, Nome, Email, Permissao FROM Usuario WHERE Usuario.Email = @Email AND Usuario.Senha = @Senha";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {

                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Senha", Senha);
                    con.Open();
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        user = new UsuarioDomain()
                        {
                            IdUsuario = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString(),
                            Email = rdr["Email"].ToString(),
                            Permissao = rdr["Permissao"].ToString()
                        };

                    }
                }
            }
            return user;
        }
    }
}







