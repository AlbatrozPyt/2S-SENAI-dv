using web_api_health_clinic.Domains;

namespace web_api_health_clinic.Interfaces
{
    public interface IPacienteRepository
    {
        void Cadastrar(Paciente p);

        void Deletar(Guid id);

        void Atualizar(Paciente p, Guid id);

        Paciente BuscarPorId(Guid id);

        List<Paciente> ListarPacientes();

        List<Consulta> Consultas(Guid id);
    }
}
