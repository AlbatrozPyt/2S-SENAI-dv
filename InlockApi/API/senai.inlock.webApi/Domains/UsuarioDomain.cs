namespace senai.inlock.webApi.Domains
{
    public class UsuarioDomain
    {

        public int IdUsuario { get; set; }

        public int IdTiposDeUsuario { get; set; }

        public string? Email { get; set; }

        public string? Senha { get; set; }

        public TiposDeUsuarioDomain TiposDeUsuario { get; set; }
    }
}
