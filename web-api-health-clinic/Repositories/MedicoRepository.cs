using web_api_health_clinic.Contexts;
using web_api_health_clinic.Domains;
using web_api_health_clinic.Interfaces;

namespace web_api_health_clinic.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly EventContext ctx;

        public MedicoRepository()
        {
            ctx = new EventContext();
        }

        public void Atualizar(Medico m, Guid id)
        {
            Medico medicoBuscado = ctx.Medicos!.FirstOrDefault(x => x.IdMedico == id)!;

            if (medicoBuscado != null) 
            { 
                medicoBuscado.IdClinica = m.IdClinica;
                medicoBuscado.Clinica = m.Clinica;
                medicoBuscado.Especializacao = m.Especializacao;
                medicoBuscado.CRM = m.CRM;
                medicoBuscado.NomeMedico = m.NomeMedico;
            }

            ctx.Medicos!.Update(medicoBuscado!);
            ctx.SaveChanges();
        }

        public Medico BuscarPorId(Guid id)
        {
            Medico medico = ctx.Medicos!.Select(x => new Medico
            {
                IdMedico = x.IdMedico,
                CRM = x.CRM,
                Especializacao = x.Especializacao,
                IdUsuario = x.IdUsuario,
                IdClinica = x.IdClinica,
                NomeMedico = x.NomeMedico,

                Usuario = new Usuario()
                {
                    IdUsuario = x.IdUsuario,
                    IdTiposUsuario = x.Usuario.IdTiposUsuario,
                    Email = x.Usuario.Email,
                    Nome = x.Usuario.Nome
                },

                Clinica = new Clinica()
                {
                    RazaoSocial = x.Clinica.RazaoSocial,
                    NomeFantasia = x.Clinica.NomeFantasia,
                    CNPJ = x.Clinica!.CNPJ,
                    Endereco = x.Clinica.Endereco,
                    HorarioAbertura = x.Clinica.HorarioAbertura,
                    HorarioFechamento = x.Clinica.HorarioFechamento,
                    IdClinica = x.IdClinica
                }

            }).FirstOrDefault(x => x.IdMedico == id)!;



            return medico;
        }

        public void Cadastrar(Medico m)
        {
            ctx.Medicos!.Add(m);
            ctx.SaveChanges();
        }

        public List<Consulta> Consultas(Guid id)
        {
            List<Consulta> consultas = ctx.Consultas!.Where(x => x.IdMedico == id).ToList();
            return consultas;
        }

        public void Deletar(Guid id)
        {
            Medico medico = ctx.Medicos!.FirstOrDefault(x => x.IdMedico == id)!;
            ctx.Medicos.Remove(medico);
            ctx.SaveChanges();
        }

        public List<Medico> ListarMedicos()
        {
            List<Medico> medicos = ctx.Medicos!.Select(x => new Medico
            {
                IdMedico = x.IdMedico,
                CRM = x.CRM,
                Especializacao = x.Especializacao,
                IdUsuario = x.IdUsuario,
                IdClinica = x.IdClinica,
                NomeMedico = x.NomeMedico,

                Usuario = new Usuario()
                {
                    IdUsuario = x.IdUsuario,
                    IdTiposUsuario = x.Usuario.IdTiposUsuario,
                    Email = x.Usuario.Email,
                    Nome = x.Usuario.Nome  
                },

                Clinica = new Clinica()
                {
                    RazaoSocial = x.Clinica.RazaoSocial,
                    NomeFantasia = x.Clinica.NomeFantasia,
                    CNPJ = x.Clinica!.CNPJ,
                    Endereco = x.Clinica.Endereco,
                    HorarioAbertura = x.Clinica.HorarioAbertura,
                    HorarioFechamento = x.Clinica.HorarioFechamento,
                    IdClinica = x.IdClinica
                }

            }).ToList();

            return medicos;
        }
    }
}
