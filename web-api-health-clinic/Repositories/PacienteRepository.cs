using web_api_health_clinic.Contexts;
using web_api_health_clinic.Domains;
using web_api_health_clinic.Interfaces;

namespace web_api_health_clinic.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly EventContext ctx;

        public PacienteRepository()
        {
            ctx = new EventContext();
        }

        public void Atualizar(Paciente p, Guid id)
        {
            Paciente pacienteBuscado = ctx.Pacientes!.FirstOrDefault(x => x.IdPaciente == id)!;

            if (pacienteBuscado != null)
            {
                pacienteBuscado.NomePaciente = p.NomePaciente;
                pacienteBuscado.Descricao = p.Descricao;
                pacienteBuscado.DataNascimento = p.DataNascimento;
            }

            ctx.Pacientes!.Update(pacienteBuscado!);
            ctx.SaveChanges();
        }

        public Paciente BuscarPorId(Guid id)
        {
            Paciente paciente = ctx.Pacientes!.Select(x => new Paciente
            {
               IdPaciente = x.IdPaciente,
               IdUsuario = x.IdUsuario,
               DataNascimento = x.DataNascimento,
               Descricao = x.Descricao,
               NomePaciente = x.NomePaciente,

                Usuario = new Usuario()
                {
                    IdUsuario = x.Usuario.IdUsuario,
                    IdTiposUsuario = x.Usuario.IdTiposUsuario,
                    Email = x.Usuario.Email,
                    Nome = x.Usuario.Nome
                },

            }).FirstOrDefault(x => x.IdUsuario == id)!;



            return paciente;
        }

        public void Cadastrar(Paciente p)
        {
            throw new NotImplementedException();
        }

        public List<Consulta> Consultas(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Paciente> ListarPacientes()
        {
            throw new NotImplementedException();
        }
    }
}
