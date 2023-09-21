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
            Evento eventoAntigo = ctx.Evento.FirstOrDefault(x => x.IdEvento == id)!;

            if (eventoAntigo != null)
            {
                eventoAntigo.IdInstituicao = evento.IdInstituicao;
                eventoAntigo.IdTipoEvento = evento.IdTipoEvento;
                eventoAntigo.DataEvento = evento.DataEvento;
                eventoAntigo.Descricao = evento.Descricao;
                eventoAntigo.NomeEvento = evento.NomeEvento;
            }

            ctx.Evento.Update(eventoAntigo!);
            ctx.SaveChanges();
        }

        public Evento BuscarPorId(Guid id)
        {
            List<Evento> eventos = ctx.Evento.ToList();
            Evento evento = eventos.FirstOrDefault(x => x.IdEvento == id);
            return evento!;
        }

        public void Cadastrar(Evento evento)
        {
           ctx.Evento.Add(evento);
           ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Evento evento = ctx.Evento.FirstOrDefault(x => x.IdEvento == id)!;
            ctx.Evento.Remove(evento);
            ctx.SaveChanges();
        }

        public List<Evento> Listar()
        {
            List<Evento> eventos = ctx.Evento.ToList();
            return eventos;
        }
    }
}
