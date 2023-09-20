using webapi.event_tarde.Contexts;
using webapi.event_tarde.Domains;
using webapi.event_tarde.Interfaces;

namespace webapi.event_tarde.Repositories
{
    public class TipoEventoRepository : ITipoEventoRepository
    {
        private readonly EventContext ctx;

        public TipoEventoRepository()
        {
            ctx = new EventContext();
        }

        public void Atualizar(Guid id, TipoEvento tipoEvento)
        {
            TipoEvento tipoBuscado = ctx.TipoEvento.FirstOrDefault(x => x.IdTipoEvento == id)!;

            if (tipoBuscado != null) 
            {
                tipoBuscado.Titulo = tipoEvento.Titulo;
            }

            ctx.TipoEvento.Update(tipoBuscado!);
            ctx.SaveChanges();
        }

        public TipoEvento BuscarPorId(Guid id)
        {
            List<TipoEvento> tipoEventos = ctx.TipoEvento.ToList();

            TipoEvento tipoEvento = tipoEventos.FirstOrDefault(x => x.IdTipoEvento == id)!;

            return tipoEvento;
        }

        public void Cadastrar(TipoEvento tipoEvento)
        {
            try
            {
                ctx.TipoEvento.Add(tipoEvento);
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            TipoEvento tipo = ctx.TipoEvento.FirstOrDefault(x => x.IdTipoEvento == id)!;
            ctx.TipoEvento.Remove(tipo!);
            ctx.SaveChanges();
        }

        public List<TipoEvento> Listar()
        {
            List<TipoEvento> tipoEventos = ctx.TipoEvento.ToList();

            return tipoEventos;
        }

    }
}
