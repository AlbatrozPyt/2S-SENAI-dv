using web_api_health_clinic.Domains;

namespace web_api_health_clinic.Interfaces
{
    public interface IClinicaRepository
    {
        void Cadastrar(Clinica clinica);

        void Deletar(Guid id);

        void Atualizar(Clinica clinica, Guid id);

        Clinica BuscarPorId(Guid id);

        List<Clinica> ListarClinicas();
    }
}
