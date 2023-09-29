using web_api_health_clinic.Domains;

namespace web_api_health_clinic.Interfaces
{
    public interface IMedicoRepository
    {
        void Cadastrar(Medico m);

        void Deletar(Guid id);

        void Atualizar(Medico m, Guid id);

        Medico BuscarPorId(Guid id);

        List<Medico> ListarMedicos();

        List<Consulta> Consultas(Guid id);
    }
}
