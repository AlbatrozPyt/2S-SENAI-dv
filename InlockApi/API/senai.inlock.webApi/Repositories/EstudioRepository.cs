using System.Data.SqlClient;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;

namespace senai.inlock.webApi.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private string StringConexao = "Data Source = DESKTOP-SF7B080; Initial Catalog = inlock_games; User Id = sa; Pwd = 1234";


        public void Cadastrar(EstudioDomain estudio)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "INSERT INTO Estudio VALUES(@Nome)";
                SqlDataReader rdr;
                con.Open();

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", estudio.Estudio);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<EstudioDomain> ListarEstudios()
        {
            EstudioDomain estudio = new EstudioDomain();
            JogoDomain jogo = new JogoDomain();
            List<EstudioDomain> listaEstudios = new List<EstudioDomain>();
            List<JogoDomain> listaJogos = new List<JogoDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "SELECT Estudio.IdEstudio, Estudio.Nome, Jogo.Nome AS jogo FROM Estudio INNER JOIN Jogo ON Jogo.IdEstudio = Estudio.IdEstudio";

                SqlDataReader rdr;

                con.Open();


                using (SqlCommand cmd = new SqlCommand(query, con))
                {

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        estudio = new EstudioDomain()
                        {
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            Estudio = rdr["Nome"].ToString()
                        };

                        jogo = new JogoDomain()
                        {
                            Nome = rdr["jogo"].ToString(),
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"])
                        };

                        
                        estudio.Jogo = jogo;

                        listaEstudios.Add(estudio);

                    }
                }
            }
            return listaEstudios;
        }
    }
}
