using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;
using webapi.filmes.tarde.Repositories;

namespace webapi.filmes.tarde.Controllers
{
   

    /// <summary>
    /// Define que a rota de uma requsicao sera no seguinte formato:
    /// dominio/api/nomeController
    /// exemplo: http://localhost:5000/api/Genero
    /// </summary>
    [Route("api/[controller]")]

    /// <summary>
    /// Define que e um controlador de API
    /// </summary>
    [ApiController]


    /// <summary>
    /// Define que o tipo da resposta da API e JSON
    /// </summary>
    [Produces("application/json")]

    [Authorize] // Precisa estar logado para acessar a rota

    public class FilmesController : ControllerBase
    {
        private IFilmeRepository _filmeRepository { get; set; }

        public FilmesController()
        {
            _filmeRepository = new FilmeRepository();
        }

        /// <summary>
        /// EndPoint que acessa o metodo de listar os filmes
        /// </summary>
        /// <returns>Lista de filmes e status code</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Cria uma lista para receber os generos
                List<FilmeDomain> listaFilmes = _filmeRepository.ListarTodos();

                // Retorna o status code 200(Ok) e a lista de generos no formato JSON
                return StatusCode(200, listaFilmes);
            }
            catch (Exception erro)
            {
                // Retorna um status code 400 - BadRequest e a mensagem de erro
                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// EndPoint para acessar o metodo de Buscar por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            try
            {
                FilmeDomain filme = _filmeRepository.BuscarPorId(id);

                if (filme == null)
                {
                    return NotFound("O filme buscado nao foi encontrado !!!");
                }


                return StatusCode(200, filme);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }




        /// <summary>
        /// EndPoint que substitui um filme pelo corpo
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public IActionResult PutIdCorpo(FilmeDomain filme)
        {
            try
            {
                FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(filme.IdFilme);

                if (filmeBuscado != null)
                {
                    try
                    {
                        _filmeRepository.AtualizarIdCorpo(filme);

                        return StatusCode(201, filme);
                    }
                    catch (Exception erro)
                    {
                        return BadRequest(erro.Message);
                    }
                }

                return NotFound("Filme nao encontrado !!!");
            }

            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// EndPoint que substitui um genero pelo ID 
        /// </summary>
        /// <param name="id">ID do objeto que sera substituido</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult PutId(int id, FilmeDomain filme)
        {
            try
            {
                _filmeRepository.AtualizarIdUrl(id, filme);

                return StatusCode(201, id);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// EndPoint que acessa o metodo cadastrar filmes
        /// </summary>
        /// <returns>Cadastro de filmes e status code</returns>
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Post(FilmeDomain novoFilme)
        {
            try
            {
                _filmeRepository.Cadastrar(novoFilme);

                return StatusCode(201, novoFilme);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }



        /// <summary>
        /// EndPoint que acessa o metodo para deletar pelo ID
        /// </summary>
        /// <param name="id">Id que sera deleltado</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _filmeRepository.Deletar(id);

                return StatusCode(201, id);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
