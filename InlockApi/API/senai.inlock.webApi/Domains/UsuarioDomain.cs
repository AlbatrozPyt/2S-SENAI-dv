using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    public class UsuarioDomain
    {

        public int IdUsuario { get; set; }

        public int IdTiposDeUsuario { get; set; }

        [Required(ErrorMessage = "O Email é obrigatório !!!")]
        public string? Email { get; set; }

        [StringLength(20, MinimumLength = 8, ErrorMessage = "A senha precisa ter no minámo 8 caracteres e no máximo 50")]
        [Required(ErrorMessage = "A Senha é obrigatória !!!")]
        public string? Senha { get; set; }

        public TiposDeUsuarioDomain TiposDeUsuario { get; set; }
    }
}
