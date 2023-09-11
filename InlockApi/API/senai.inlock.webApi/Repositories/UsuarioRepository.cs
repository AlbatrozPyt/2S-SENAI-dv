using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        //private string StringConexao = "Data Source = DESKTOP-SF7B080; Initial Catalog = inlock_games; User Id = sa; Pwd = 1234";

        private string StringConexao = "Data Source = NOTE20-S15; Initial Catalog = inlock_games; User Id = sa; Pwd = Senai@134";

        public UsuarioDomain Login(string email, string senha)
        {
            UsuarioDomain user = null;
            TiposDeUsuarioDomain tipo = null;

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryLogin = "SELECT Usuario.IdUsuario, Usuario.IdTipoUsuario, TiposUsuario.Titulo, Usuario.Email FROM Usuario LEFT JOIN TiposUsuario ON TiposUsuario.IdTipoUsuario = Usuario.IdTipoUsuario WHERE Usuario.Email = @Email AND Usuario.Senha = @Senha";

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
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                            IdTiposDeUsuario = Convert.ToInt32(rdr[1])  
                        };

                        tipo = new TiposDeUsuarioDomain()
                        {
                            IdTiposDeUsuario = Convert.ToInt32(rdr[0]),
                            Titulo = rdr[2].ToString()
                        };

                        user.TiposDeUsuario = tipo;
                    }
                }
            }
            return user;
        }
    }
}
