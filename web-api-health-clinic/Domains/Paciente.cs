using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_api_health_clinic.Domains
{
    [Table(nameof(Paciente))]

    public class Paciente
    {
        [Key]
        public Guid IdPaciente { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome do paciente é obrigatório !!!")]
        public string? NomePaciente { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Data de nascimento do paciente é obrigatório !!!")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "0:dd/MM/yyyy")]
        public DateTime? DataNascimento { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome do paciente é obrigatório !!!")]
        public string? Descricao { get; set; }

        // IdUsuario
        [Required(ErrorMessage = "Usuario é obrigatório !!!")]
        public Guid? IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }
    }
}
