using webapi.CodeFirst.Domains;

namespace webapi.CodeFirst.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario Login(string email, string senha);

        void Cadastrar(Usuario usuario);
    }
}
