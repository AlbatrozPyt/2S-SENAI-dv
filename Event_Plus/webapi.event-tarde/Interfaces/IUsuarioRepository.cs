using webapi.event_tarde.Domains;

namespace webapi.event_tarde.Interfaces
{
    public interface IUsuarioRepository
    {

        void Cadastrar(Usuario usuario);

        Usuario BuscarPorId(Guid id);

        Usuario BuscarPorEmail(string email, string senha);
    }
}
