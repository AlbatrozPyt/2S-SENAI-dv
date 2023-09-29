using web_api_health_clinic.Domains;

namespace web_api_health_clinic.Interfaces
{
    public interface IConsultaRepository
    {
        void Cadastrar(Consulta c);

        void Deletar(Guid id);

        void Atualizar(Consulta c, Guid id);

        Consulta BuscarPorID(Guid id);

        List<Consulta> ListarConsultas();
    }
}
