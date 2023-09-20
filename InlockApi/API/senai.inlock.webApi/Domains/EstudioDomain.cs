namespace senai.inlock.webApi.Domains
{
    public class EstudioDomain
    {
        public int IdEstudio { get; set; }
        public string Estudio { get; set; }
        public List<JogoDomain> ListaJogos { get; set; }

    }
}
