using Microsoft.EntityFrameworkCore;
using web_api_health_clinic.Domains;

namespace web_api_health_clinic.Contexts
{
    public class EventContext : DbContext
    {
        public DbSet<TiposUsuario>? TiposUsuarios { get; set; }
        public DbSet<Usuario>? Usuarios { get; set; }
        public DbSet<Clinica>? Clinicas { get; set; }
        public DbSet<Medico>? Medicos { get; set; }
        public DbSet<Paciente>? Pacientes { get; set; }
        public DbSet<Consulta>? Consultas { get; set; }
        public DbSet<Feedback>? Feedbacks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE20-S15; Database=Web_Api_Health-Clinic; User Id=sa; Pwd=Senai@134; TrustServerCertificate=true;");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
