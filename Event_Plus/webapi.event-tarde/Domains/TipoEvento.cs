using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_tarde.Domains
{
    [Table(nameof(TipoEvento))]


    public class TipoEvento
    {

        [Key]
        public Guid IdTipoEvento { get; set; } =  Guid.NewGuid();


        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Titulo do tipo de evento obrigatorio !!!")]
        public string? Titulo { get; set; }


    }
}
