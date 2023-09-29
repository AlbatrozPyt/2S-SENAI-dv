using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_api_health_clinic.Domains
{
    [Table(nameof(Feedback))]

    public class Feedback
    {
        [Key]
        public Guid IdFeedback { get; set; } = Guid.NewGuid();

        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "Exibe é obrigatório !!!")]
        public bool Exibe { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Comentario é obrigatório !!!")]
        public string? Comentario { get; set; }

        // IdConsulta
        [Required(ErrorMessage = "Consulta é obrigatório !!!")]
        public Guid IdConsulta { get; set;}

        [ForeignKey(nameof(IdConsulta))]
        public Consulta? Consulta { get; set; }
    }
}
