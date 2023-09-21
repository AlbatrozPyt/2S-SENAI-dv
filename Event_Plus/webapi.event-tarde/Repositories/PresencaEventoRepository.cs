using webapi.event_tarde.Contexts;
using webapi.event_tarde.Domains;
using webapi.event_tarde.Interfaces;

namespace webapi.event_tarde.Repositories
{
    public class PresencaEventoRepository : IPresencaEventoRepository
    {
        private readonly EventContext ctx;

        public PresencaEventoRepository()
        {
            ctx = new EventContext();
        }

        public void Cadastrar(PresencaEvento presencaEvento)
        {
            ctx.PresencaEvento.Add(presencaEvento);
            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            PresencaEvento presencaEvento = ctx.PresencaEvento.FirstOrDefault(x => x.IdPresencaEvento == id)!;
            ctx.PresencaEvento.Remove(presencaEvento);
            ctx.SaveChanges();
        }

        public List<PresencaEvento> ListarPresencas(Guid id)
        {
            List<PresencaEvento> presencaEventos = ctx.PresencaEvento.Where(x => x.IdUsuario == id).ToList();
            
            return presencaEventos;
        }
    }
}
