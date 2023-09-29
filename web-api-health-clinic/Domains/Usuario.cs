using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_api_health_clinic.Domains
{
    [Table(nameof(Usuario))]
    [Index(nameof(Email), IsUnique = true)]

    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome do usuário é obrigatório !!!")]
        public string? Nome { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Email do usuário é obrigatorio !!!")]
        public string? Email { get; set; }

        [Column(TypeName = "CHAR(60)")]
        [Required(ErrorMessage = "Senha do usuário é obrigatorio !!!")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "Maxímo de caracteres 60 e mínimo")]
        public string? Senha { get; set;}

        [Required(ErrorMessage = "Tipo de Usuario é obrigatório !!!")]
        public Guid IdTiposUsuario { get; set; }

        [ForeignKey(nameof(IdTiposUsuario))]
        public TiposUsuario? TiposUsuario { get; set; }
    }
}
