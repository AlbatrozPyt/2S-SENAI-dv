using webapi.filmes.tarde.Domains;

namespace webapi.filmes.tarde.Interfaces
{
    /// <summary>
    /// É uma interface responsavel pelo repositorio GeneroRepository
    /// Define os metodos que serão implementados pelo repositorio
    /// </summary>
    public interface IGeneroRepository
    {
        // CRUD

        // TipoDeRetorno NomeMetodo(TipoParametro NomeDoParametro)

        /// <summary>
        ///  Cadastrar um novo genero
        /// </summary>
        /// <param name="novoGenero">Objeto que sera cadastrado</param>
        void Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        /// Retornar todos os generos cadastrados 
        /// </summary>
        /// <returns>Uma lista de generos</returns>
        List<GeneroDomain> ListarTodos();

        /// <summary>
        /// Buscar um objeto atraves do seu id
        /// </summary>
        /// <param name="id">id do objeto que sera buscado</param>
        /// <returns>Objeto que foi buscado</returns>
        GeneroDomain BuscarPorId(int id);

        /// <summary>
        ///  Atualizar um genero existente passando o id pelo corpo da reqisição
        /// </summary>
        /// <param name="genero">Objeto com as novas informacoes</param>
        void AtualizarIdCorpo(GeneroDomain genero);

        /// <summary>
        /// Atualizar um genero existente passando o id pela URL da reqisição
        /// </summary>
        /// <param name="id">Id do objeto a ser atualizado</param>
        /// <param name="genero">Objeto com as novas informacoes</param>
        void AtualizarIdUrl(int id, GeneroDomain genero);

        /// <summary>
        /// Deletar um genero existente
        /// </summary>
        /// <param name="id">Id do objeto que sera deletado</param>
        void Deletar(int id);
    }
}
