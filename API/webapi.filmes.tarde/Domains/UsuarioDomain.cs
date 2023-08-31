using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.tarde.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        public string? Permissao { get; set; }

        public string? Nome { get; set; }

        [Required(ErrorMessage = "O Email é obrigatorio !!!")]
        public string? Email { get; set; }

        [StringLength(20, MinimumLength = 8, ErrorMessage = "A senha percisa ter no minimo 8 caracteres e no maximo 50")]
        [Required(ErrorMessage = "A Senha é obrigatorio !!!")]
        public string? Senha { get; set; }
    }
}
