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

            }).FirstOrDefault(x => x.IdPaciente == id)!;



            return paciente;
        }

        public void Cadastrar(Paciente p)
        {
            ctx.Pacientes!.Add(p);
            ctx.SaveChanges();
        }

        public List<Consulta> Consultas(Guid id)
        {
            List<Consulta> consultas = ctx.Consultas!.Where(x => x.IdPaciente == id).ToList();
            return consultas;
        }

        public void Deletar(Guid id)
        {
            Paciente paciente = ctx.Pacientes!.FirstOrDefault(x => x.IdPaciente == id)!;
            ctx.Pacientes.Remove(paciente);
            ctx.SaveChanges();
        }

        public List<Paciente> ListarPacientes()
        {
            List<Paciente> pacientes = ctx.Pacientes!.Select(x => new Paciente
            {
                IdPaciente = x.IdPaciente,
                IdUsuario = x.IdUsuario,
                NomePaciente = x.NomePaciente,
                DataNascimento = x.DataNascimento,
                Descricao = x.Descricao,

                Usuario = new Usuario()
                {
                    IdUsuario = x.Usuario!.IdUsuario,
                    IdTiposUsuario = x.Usuario.IdTiposUsuario,
                    Email = x.Usuario.Email,
                    Nome = x.Usuario.Nome
                }

            }).ToList();

            return pacientes;

        }
    }
}
