using web_api_health_clinic.Domains;

namespace web_api_health_clinic.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario user);

        void Deletar(Guid id);

        Usuario BuscarEmail(string email, string senha);
    }
}