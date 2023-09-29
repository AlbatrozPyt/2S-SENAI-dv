using web_api_health_clinic.Contexts;
using web_api_health_clinic.Domains;
using web_api_health_clinic.Interfaces;

namespace web_api_health_clinic.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly EventContext ctx;

        public UsuarioRepository()
        {
            ctx = new EventContext();
        }

        public Usuario BuscarEmail(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Usuario user)
        {
            ctx.Usuarios!.Add(user);

            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Usuario user = ctx.Usuarios!.FirstOrDefault(x => x.IdUsuario == id)!;
            ctx.Usuarios!.Remove(user);
            ctx.SaveChanges();
        }
    }
}
