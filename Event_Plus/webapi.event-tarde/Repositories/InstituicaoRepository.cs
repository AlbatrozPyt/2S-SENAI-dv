using webapi.event_tarde.Contexts;
using webapi.event_tarde.Domains;
using webapi.event_tarde.Interfaces;

namespace webapi.event_tarde.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private readonly EventContext ctx;

        public InstituicaoRepository()
        {
            ctx = new EventContext();
        }

        public void Atualizar(Guid id, Instituicao instituto)
        {
            Instituicao instituicaoAntiga = ctx.Instituicao.FirstOrDefault(x => x.IdInstituicao == id)!;
            
            if (instituicaoAntiga != null) 
            {
                instituicaoAntiga.NomFantasia = instituto.NomFantasia;
                instituicaoAntiga.CNPJ = instituto.CNPJ;
                instituicaoAntiga.Endereco = instituto.Endereco;
            }

            ctx.Instituicao.Update(instituicaoAntiga);
            ctx.SaveChanges();
        }

        public Instituicao BuscarPorId(Guid id)
        {
            List<Instituicao> instituicaos = ctx.Instituicao.ToList();
            Instituicao instituto = instituicaos.FirstOrDefault(x => x.IdInstituicao == id)!;
            return instituto!;
        }

        public void Cadastrar(Instituicao instituto)
        {
            ctx.Instituicao.Add(instituto);
            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Instituicao instituicao = ctx.Instituicao.FirstOrDefault(x => x.IdInstituicao == id)!;
            ctx.Instituicao.Remove(instituicao);
            ctx.SaveChanges();
        }

        public List<Instituicao> Listar()
        {
            List<Instituicao> instituicoes = ctx.Instituicao.ToList();

            return instituicoes;
        }
    }
}
