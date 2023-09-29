using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_api_health_clinic.Domains
{
    [Table(nameof(Medico))]
    [Index(nameof(CRM), IsUnique = true)]

    public class Medico
    {
        [Key]
        public Guid IdMedico { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome do médico é obrigatório !!!")]
        public string? NomeMedico { get; set; }

        [Column(TypeName = "CHAR(6)")]
        [Required(ErrorMessage = "CRM do médico é obrigatório !!!")]
        [StringLength(6, ErrorMessage = "O CRM tem 6 caracteres !!!")]
        public string? CRM { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Especialização do médico é obrigatório !!!")]
        public string? Especializacao { get; set; }

        // IdClinica
        [Required(ErrorMessage = "Clinica é obrigatório !!!")]
        public Guid IdClinica { get; set; }

        [ForeignKey(nameof(IdClinica))]
        public Clinica? Clinica { get; set; }

        // IdUsuario
        [Required(ErrorMessage = "Usuario é obrigatório !!!")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }
    }
}
