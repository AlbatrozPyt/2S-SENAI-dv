using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = "Data Source = NOTE20-S15; Initial Catalog = Filmes_Tarde; User Id = sa; Pwd = Senai@134";

        public UsuarioDomain Login(string email, string senha)
        {
            UsuarioDomain user = new UsuarioDomain();
            TiposDeUsuarioDomain tipo = new TiposDeUsuarioDomain();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryLogin = "SELECT Usuario.IdUsuario, Usuario.Email FROM Usuario WHERE Usuario.Email = @Email AND  Usuario.Senha = @Senha";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryLogin, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    con.Open();

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        user = new UsuarioDomain()
                        {
                            Email = rdr["Email"].ToString(),
                            Senha = rdr["Senha"].ToString(),
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"])
                        };
                    }
                }
            }
            return user;
        }
    }
}
