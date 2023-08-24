using webapi.filmes.tarde.Domains;

namespace webapi.filmes.tarde.Interfaces
{
    public interface IFilmeRepository
    {
        /// <summary>
        /// Cadastrar um novo filme
        /// </summary>
        /// <param name="novoFilme"></param>
        void Cadastrar(FilmeDomain novoFilme);

        /// <summary>
        /// Listar todos os filmes
        /// </summary>
        /// <returns></returns>
        List<FilmeDomain> ListarTodos();

        /// <summary>
        /// Buscar filmes por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        FilmeDomain BuscarPorId(int id);

        /// <summary>
        /// Atualizar um objeto pelo corpo da requisicao
        /// </summary>
        /// <param name="filme"></param>
        void AtualizarIdCorpo(FilmeDomain filme);

        /// <summary>
        /// Atualizar um filme pela URL
        /// </summary>
        /// <param name="id"></param>
        /// <param name="filme"></param>
        void AtualizarIdUrl(int id, FilmeDomain filme);

        /// <summary>
        /// Deletar um filme
        /// </summary>
        /// <param name="id"></param>
        void Deletar(int id);
    }
}
