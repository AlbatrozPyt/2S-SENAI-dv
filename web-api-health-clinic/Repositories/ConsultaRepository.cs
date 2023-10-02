using web_api_health_clinic.Contexts;
using web_api_health_clinic.Domains;
using web_api_health_clinic.Interfaces;

namespace web_api_health_clinic.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly EventContext ctx;

        public ConsultaRepository()
        {
            ctx = new EventContext();
        }

        public void Atualizar(Consulta c, Guid id)
        {
            Consulta consultaBuscada = ctx.Consultas!.FirstOrDefault(x => x.IdConsulta == id)!;

            if(consultaBuscada != null) 
            {
                consultaBuscada.Descricao = c.Descricao;
                consultaBuscada.DataConsulta = c.DataConsulta;
                consultaBuscada.IdMedico = c.IdMedico;
                consultaBuscada.IdPaciente = c.IdPaciente;
                consultaBuscada.Paciente = c.Paciente;
                consultaBuscada.Medico = c.Medico;
            }

            ctx.Consultas!.Update(consultaBuscada!);
            ctx.SaveChanges();
        }

        public Consulta BuscarPorID(Guid id)
        {
            Consulta consulta = ctx.Consultas!.Select(x => new Consulta
            {
                IdMedico = x.IdMedico,
                DataConsulta = x.DataConsulta,
                Descricao = x.Descricao,
                IdConsulta = x.IdConsulta,
                IdPaciente = x.IdPaciente,

                Medico = new Medico()
                {
                    IdMedico = x.IdMedico,
                    CRM = x.Medico.CRM,
                    Especializacao = x.Medico.Especializacao,
                    IdUsuario = x.Medico.IdUsuario,
                    IdClinica = x.Medico.IdClinica,
                    NomeMedico = x.Medico.NomeMedico,

                    Clinica = new Clinica()
                    {
                        RazaoSocial = x.Medico.Clinica.RazaoSocial,
                        NomeFantasia = x.Medico.Clinica.NomeFantasia,
                        CNPJ = x.Medico.Clinica!.CNPJ,
                        Endereco = x.Medico.Clinica.Endereco,
                        HorarioAbertura = x.Medico.Clinica.HorarioAbertura,
                        HorarioFechamento = x.Medico.Clinica.HorarioFechamento,
                        IdClinica = x.Medico.IdClinica
                    }
                },

                Paciente = new Paciente()
                {
                    IdPaciente = x.IdPaciente,
                    IdUsuario = x.Paciente.IdUsuario,
                    DataNascimento = x.Paciente.DataNascimento,
                    Descricao = x.Paciente.Descricao,
                    NomePaciente = x.Paciente.NomePaciente
                }

            }).FirstOrDefault(x => x.IdConsulta == id)!;

            return consulta;
        }

        public void Cadastrar(Consulta c)
        {
            ctx.Consultas!.Add(c);
            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Consulta c = ctx.Consultas!.FirstOrDefault(x => x.IdConsulta == id)!;
            ctx.Consultas!.Remove(c);
            ctx.SaveChanges();
        }

        public List<Consulta> ListarConsultas()
        {
            List<Consulta> consultas = ctx.Consultas!.Select(x => new Consulta
            {
                IdMedico = x.IdMedico,
                DataConsulta = x.DataConsulta,
                Descricao = x.Descricao,
                IdConsulta = x.IdConsulta,
                IdPaciente = x.IdPaciente,

                Medico = new Medico()
                {
                    IdMedico = x.IdMedico,
                    CRM = x.Medico.CRM,
                    Especializacao = x.Medico.Especializacao,
                    IdUsuario = x.Medico.IdUsuario,
                    IdClinica = x.Medico.IdClinica,
                    NomeMedico = x.Medico.NomeMedico,

                    Clinica = new Clinica()
                    {
                        RazaoSocial = x.Medico.Clinica.RazaoSocial,
                        NomeFantasia = x.Medico.Clinica.NomeFantasia,
                        CNPJ = x.Medico.Clinica!.CNPJ,
                        Endereco = x.Medico.Clinica.Endereco,
                        HorarioAbertura = x.Medico.Clinica.HorarioAbertura,
                        HorarioFechamento = x.Medico.Clinica.HorarioFechamento,
                        IdClinica = x.Medico.IdClinica
                    }
                },

                Paciente = new Paciente() 
                {
                    IdPaciente = x.IdPaciente,
                    IdUsuario = x.Paciente.IdUsuario,
                    DataNascimento = x.Paciente.DataNascimento,
                    Descricao = x.Paciente.Descricao,
                    NomePaciente = x.Paciente.NomePaciente
                }

            }).ToList();

            return consultas;
        }
    }
}
