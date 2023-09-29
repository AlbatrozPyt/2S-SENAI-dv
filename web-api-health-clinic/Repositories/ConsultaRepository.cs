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
            throw new NotImplementedException();
        }

        public Consulta BuscarPorID(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Consulta c)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Consulta> ListarConsultas()
        {
            throw new NotImplementedException();
        }
    }
}
