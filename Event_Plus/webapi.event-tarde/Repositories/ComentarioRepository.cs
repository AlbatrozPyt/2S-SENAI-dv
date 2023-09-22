using webapi.event_tarde.Contexts;
using webapi.event_tarde.Domains;
using webapi.event_tarde.Interfaces;

namespace webapi.event_tarde.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly EventContext ctx;

        public ComentarioRepository()
        {
            ctx = new EventContext();
        }

        public void Comentario(ComentarioEvento com)
        {
            ctx.ComentarioEvento.Add(com);
            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            ComentarioEvento comDelete = ctx.ComentarioEvento.FirstOrDefault(x => x.IdComentarioEvento == id)!;
            ctx.ComentarioEvento.Remove(comDelete);
            ctx.SaveChanges();
        }

        public List<ComentarioEvento> ListarComentariosUsuario(Guid id)
        {
            List<ComentarioEvento> comentarios = ctx.ComentarioEvento.Where(x => x.IdUsuario == id).ToList();

            return comentarios;
        }
    }
}
