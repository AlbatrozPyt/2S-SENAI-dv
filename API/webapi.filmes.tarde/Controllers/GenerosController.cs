using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
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

    public class GenerosController : ControllerBase
    {
        /// <summary>
        /// Objeto que ira receber os metodos definidos na interface
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        /// <summary>
        /// Instancia do objeto _generoRepository para que haja referencia aos metodos dos repositorios
        /// </summary>
        public GenerosController()
        {
            _generoRepository = new GeneroRepository();
        }

        /// <summary>
        /// EndPoint que acessa o metodo de listar os generos
        /// </summary>
        /// <returns>Lista de generos e status code</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Cria uma lista para receber os generos
                List<GeneroDomain> listaGeneros = _generoRepository.ListarTodos();

                // Retorna o status code 200(Ok) e a lista de generos no formato JSON
                return StatusCode(200, listaGeneros);
            }
            catch (Exception erro)
            {
                // Retorna um status code 400 - BadRequest e a mensagem de erro
                return BadRequest(erro.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            try
            {
                _generoRepository.Cadastrar(novoGenero);

                return StatusCode(201, novoGenero.Nome);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
