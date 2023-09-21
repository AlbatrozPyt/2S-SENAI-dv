using webapi.event_tarde.Domains;

namespace webapi.event_tarde.Interfaces
{
    public interface IPresencaEventoRepository
    {
        List<PresencaEvento> ListarPresencas(Guid id);

        void Cadastrar(PresencaEvento presencaEvento);

        void Deletar(Guid id);
    }
}
