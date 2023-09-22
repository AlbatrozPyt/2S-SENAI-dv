using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.CodeFirst.Domains
{

    [Table("Usuario")]
    [Index(nameof(Email), IsUnique = true)]

    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = new Guid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O email do usuario é obrigatorio!!!")]
        public string? Email { get; set; }

        [Column(TypeName = "VARCHAR(200)")]
        [Required(ErrorMessage = "A senha do usuario é obrigatorio!!!")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "O minímo de caracteres é 6 e o maxímo é 60 !!!")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Tipo do usuario é obrigatorio!!!")]
        public Guid IdTiposUsuario { get; set; }

        [ForeignKey("IdTiposUsuario")]
        public TiposUsuario? TipoUsuario { get; set; }
    }
}
