using webapi.event_tarde.Domains;

namespace webapi.event_tarde.Interfaces
{
    public interface IComentarioRepository
    {
        void Comentario(ComentarioEvento com);

        List<ComentarioEvento> ListarComentariosUsuario(Guid id);

        void Deletar(Guid id);
    }
}
