using webapi.event_tarde.Domains;

namespace webapi.event_tarde.Interfaces
{
    public interface IEventoRepository
    {
        void Cadastrar(Evento evento);

        void Deletar(Guid id);

        List<Evento> Listar();

        Evento BuscarPorId(Guid id);

        void Atualizar(Guid id, Evento evento);
    }
}
