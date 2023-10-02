using web_api_health_clinic.Contexts;
using web_api_health_clinic.Domains;
using web_api_health_clinic.Interfaces;
using web_api_health_clinic.Utils;

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
            try
            {
                Usuario usuarioBuscado = ctx.Usuarios!.Select(x => new Usuario
                {
                    IdUsuario = x.IdUsuario,
                    IdTiposUsuario = x.IdTiposUsuario,
                    Nome = x.Nome,
                    Email = x.Email,
                    Senha = x.Senha,

                    TiposUsuario = new TiposUsuario()
                    {
                        IdTiposUsuario = x.IdTiposUsuario,
                        Titulo = x.TiposUsuario!.Titulo
                    }

                }).FirstOrDefault(y => y.Email == email)!;

                if(usuarioBuscado != null) 
                {
                    bool verifica = Criptografia.CompararHash(senha, usuarioBuscado.Senha);

                    if(verifica) 
                    {
                        return usuarioBuscado;
                    }


                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Usuario user)
        {
            user.Senha = Criptografia.GerarHash(user.Senha!);

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
