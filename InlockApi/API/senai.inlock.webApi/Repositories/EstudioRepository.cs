using System.Data.SqlClient;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;

namespace senai.inlock.webApi.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        // private string StringConexao = "Data Source = DESKTOP-SF7B080; Initial Catalog = inlock_games; User Id = sa; Pwd = 1234";

        private string StringConexao = "Data Source = NOTE20-S15; Initial Catalog = inlock_games; User Id = sa; Pwd = Senai@134";


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

            List<EstudioDomain> listaEstudios = new List<EstudioDomain>();

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

                        listaEstudios.Add(estudio);
                    }
                }
            }
            return listaEstudios;
        }

        public List<EstudioDomain> ListarJogos(int id)
        {
            EstudioDomain estudio = new EstudioDomain();
            JogoDomain jogo = new JogoDomain();
            List<EstudioDomain> list = new List<EstudioDomain>();

            using (SqlConnection conE = new SqlConnection(StringConexao))
            {
                string queryEstudios = "SELECT * FROM Estudio";
                conE.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryEstudios, conE))
                {
                    rdr = cmd.ExecuteReader();

                    List<JogoDomain> listaJogos = new List<JogoDomain>();

                    while (rdr.Read())
                    {
                        estudio = new EstudioDomain()
                        {
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            Estudio = rdr["Nome"].ToString()
                        };

                        using (SqlConnection conJ = new SqlConnection(StringConexao))
                        {
                            string queryJogos = "SELECT * FROM Jogo WHERE Jogo.IdEstudio = @Id";
                            conJ.Open();
                            SqlDataReader rdrJ;

                            using (SqlCommand cmdJ = new SqlCommand(queryJogos, conJ))
                            {
                                cmdJ.Parameters.AddWithValue("@Id", id);

                                rdrJ = cmdJ.ExecuteReader();

                                while (rdrJ.Read())
                                {
                                    jogo = new JogoDomain()
                                    {
                                        IdEstudio = Convert.ToInt32(rdrJ["IdEstudio"]),
                                        IdJogo = Convert.ToInt32(rdrJ["IdJogo"]),
                                        Nome = rdrJ["Nome"].ToString(),
                                        Descricao = rdrJ["Descricao"].ToString(),
                                        DataLancamento = Convert.ToDateTime(rdrJ["DataLancamento"]),
                                        Valor = Convert.ToDouble(rdrJ["Valor"])
                                    };

                                    listaJogos.Add(jogo);
                                }
                            }

                        }

                    }

                    estudio.ListaJogos = listaJogos;
                    list.Add(estudio);
                }
                return list;

            }
        }
    }
}
