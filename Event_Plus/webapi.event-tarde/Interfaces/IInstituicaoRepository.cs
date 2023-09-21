using webapi.event_tarde.Domains;

namespace webapi.event_tarde.Interfaces
{
    public interface IInstituicaoRepository
    {
        void Cadastrar(Instituicao instituto);

        void Deletar(Guid id);

        List<Instituicao> Listar();

        Instituicao BuscarPorId(Guid id);

        void Atualizar(Guid id, Instituicao instituto);
    }
}
