using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_api_health_clinic.Domains
{
    [Table(nameof(TiposUsuario))]

    public class TiposUsuario
    {
        [Key]
        public Guid IdTiposUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O título do tipo usuario é obrigatório !!!")]
        public string? Titulo { get; set; }
    }
}
