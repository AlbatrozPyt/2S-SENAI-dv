using webapi.event_tarde.Contexts;
using webapi.event_tarde.Domains;
using webapi.event_tarde.Interfaces;

namespace webapi.event_tarde.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly EventContext ctx;

        ComentarioRepository()
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
            throw new NotImplementedException();
        }

        public List<ComentarioEvento> ListarComentariosUsuario(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
