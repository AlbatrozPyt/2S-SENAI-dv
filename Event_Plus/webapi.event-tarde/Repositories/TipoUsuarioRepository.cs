using Microsoft.EntityFrameworkCore;
using webapi.event_tarde.Contexts;
using webapi.event_tarde.Domains;
using webapi.event_tarde.Interfaces;

namespace webapi.event_tarde.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly EventContext ctx;

        public TipoUsuarioRepository()
        {
            ctx = new EventContext();
        }



        public void Atualizar(Guid id, TipoUsuario tipoUsuario)
        {
            TipoUsuario tipoBuscado = ctx.TipoUsuario.FirstOrDefault(x => x.IdTipoUsuario == id)!;

            if (tipoBuscado != null)
            {
                tipoBuscado.Titulo = tipoUsuario.Titulo; 
            }

            ctx.TipoUsuario.Update(tipoBuscado!);

            ctx.SaveChanges();
        }

        public TipoUsuario BuscarPorId(Guid id)
        {
            List<TipoUsuario> tipoUsuarios = ctx.TipoUsuario.ToList();

            TipoUsuario tipoUsuario = tipoUsuarios.FirstOrDefault(x => x.IdTipoUsuario == id)!;

            return tipoUsuario;
        }

        public void Cadastrar(TipoUsuario tipoUsuario)
        {
            try
            {
                ctx.TipoUsuario.Add(tipoUsuario);
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            TipoUsuario tipoUsuario = ctx.TipoUsuario.FirstOrDefault(x => x.IdTipoUsuario == id)!;

            ctx.TipoUsuario.Remove(tipoUsuario);

            ctx.SaveChanges();
            
        }

        public List<TipoUsuario> Listar()
        {
            List<TipoUsuario> tipoUsuarios = ctx.TipoUsuario.ToList();

            return tipoUsuarios;
        }
    }
}
