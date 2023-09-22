using webapi.CodeFirst.Contexts;
using webapi.CodeFirst.Domains;
using webapi.CodeFirst.Interfaces;
using webapi.CodeFirst.Utils;

namespace webapi.CodeFirst.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly InlockContext ctx;

        public UsuarioRepository()
        {
            ctx = new InlockContext();
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                ctx.Usuario.Add(usuario);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuario Login(string email, string senha)    
        {
            try
            {
                var usuarioBuscado = ctx.Usuario.FirstOrDefault(x => x.Email == email);

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha);

                    if (confere)
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
    }
}
