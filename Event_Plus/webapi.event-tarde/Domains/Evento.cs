using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_tarde.Domains
{
    [Table(nameof(Evento))]

    public class Evento
    {
        [Key]
        public Guid IdEvento { get; set; } = Guid.NewGuid();


        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Data do evento obrigatoria!!!")]
        public DateTime DataEvento { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome do evento obrigatorio!!!")]
        public string? NomeEvento { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Descricao do evento obrigatorio!!!")]
        public string? Descricao { get; set; }

        // ref. da tabela TipoEvento(FK)
        [Required(ErrorMessage = "TipoEvento obrigatorio!!!")]
        public Guid IdTipoEvento { get; set; }

        [ForeignKey(nameof(IdTipoEvento))]
        public TipoEvento? TipoEvento { get; set; }

        // ref. da tabela Instituicao(FK)
        [Required(ErrorMessage = "Instituicao obrigatoria!!!")]
        public Guid IdInstituicao { get; set; }

        [ForeignKey(nameof(IdInstituicao))]
        public Instituicao? Instituicao { get; set; }
    }
}
