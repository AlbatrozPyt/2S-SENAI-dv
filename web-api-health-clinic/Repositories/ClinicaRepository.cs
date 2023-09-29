using web_api_health_clinic.Contexts;
using web_api_health_clinic.Domains;
using web_api_health_clinic.Interfaces;

namespace web_api_health_clinic.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        private readonly EventContext ctx;

        public ClinicaRepository()
        {
            ctx = new EventContext();
        }

        public void Atualizar(Clinica clinica, Guid id)
        {
            Clinica clinicaBuscada = ctx.Clinicas!.FirstOrDefault(x => x.IdClinica == id)!;

            if(clinicaBuscada != null) 
            {
                clinicaBuscada.RazaoSocial = clinica.RazaoSocial;
                clinica.NomeFantasia = clinica.NomeFantasia;
                clinicaBuscada.CNPJ = clinica.CNPJ;
                clinicaBuscada.HorarioAbertura = clinica.HorarioAbertura;
                clinicaBuscada.HorarioFechamento = clinica.HorarioFechamento;
                clinicaBuscada.Endereco = clinica.Endereco;
            }

            ctx.Clinicas!.Update(clinicaBuscada!);
            ctx.SaveChanges();
        }

        public Clinica BuscarPorId(Guid id)
        {
            Clinica clinica = ctx.Clinicas!.FirstOrDefault(x => x.IdClinica == id)!;
            
            return clinica;
        
        }

        public void Cadastrar(Clinica clinica)
        {
            ctx.Clinicas!.Add(clinica);
            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Clinica clinica = ctx.Clinicas!.FirstOrDefault(x => x.IdClinica == id)!;
            ctx.Clinicas!.Remove(clinica);
            ctx.SaveChanges();
        }

        public List<Clinica> ListarClinicas()
        {
            List<Clinica> clinicas = ctx.Clinicas.ToList();

            return clinicas;
        }

    }
}
