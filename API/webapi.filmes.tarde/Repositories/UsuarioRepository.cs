using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = "Data Source = NOTE20-S15; Initial Catalog = Filmes_Tarde; User Id = sa; Pwd = Senai@134";

        public UsuarioDomain Login(UsuarioDomain user)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "SELECT Usuario.Nome, Usuario.Email, TiposDeUsuario.TiposDeUsuario FROM Usuario INNER JOIN TiposDeUsuario ON TiposDeUsuario.IdTiposDeUsuario = Usuario.IdTiposDeUsuario WHERE Usuario.Email = @Email AND Usuario.Senha = @Senha";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(con, query))
                {

                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Senha", user.Senha);
                    con.Open();
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                    }
                }
            }
        }

        public UsuarioDomain Login(UsuarioDomain user)
        {
            throw new NotImplementedException();
        }
    }
}
