using webapi.event_tarde.Contexts;
using webapi.event_tarde.Domains;
using webapi.event_tarde.Interfaces;

namespace webapi.event_tarde.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly EventContext ctx;
        
        public EventoRepository() 
        { 
            ctx = new EventContext();
        }

        public void Atualizar(Guid id, Evento evento)
        {
            throw new NotImplementedException();
        }

        public TipoEvento BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Evento evento)
        {
           ctx.Evento.Add(evento);
           ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<TipoEvento> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
