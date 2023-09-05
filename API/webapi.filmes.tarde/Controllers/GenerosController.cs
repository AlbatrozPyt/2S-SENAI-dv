using Microsoft.AspNetCore.Authorization;
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

    [Authorize] // Precisa estar logado para acessar a rota

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
                GeneroDomain genero = _generoRepository.BuscarPorId(id);

                if (genero == null)
                {
                    return NotFound("O genero buscado nao foi encontrado !!!");
                }


                return StatusCode(200, genero);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }



        /// <summary>
        /// EndPoint que acessa o metodo cadastrar generos
        /// </summary>
        /// <returns>Cadastro de generos e status code</returns>
        [HttpPost]
        [Authorize(Roles = "Administrador")]
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


        /// <summary>
        /// EndPoint que substitui um genero pelo ID 
        /// </summary>
        /// <param name="id">ID do objeto que sera substituido</param>
        /// <param name="novoGenero">Novo geenro</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult PutId(int id, GeneroDomain novoGenero)
        {
            try
            {
                _generoRepository.AtualizarIdUrl(id, novoGenero);

                return StatusCode(201, id);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// EndPoint que substitui um genero pelo corpo
        /// </summary>
        /// <param name="novoGenero"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult PutIdCorpo(GeneroDomain novoGenero)
        {
            try
            {
                GeneroDomain generoBuscado = _generoRepository.BuscarPorId(novoGenero.IdGenero);

                if (generoBuscado != null)
                {
                    try
                    {
                        _generoRepository.AtualizarIdCorpo(novoGenero);

                        return StatusCode(201, novoGenero);
                    }
                    catch (Exception erro)
                    {
                        return BadRequest(erro.Message);
                    }
                }

                return NotFound("Genero nao encontrado !!!");
            }

            catch(Exception erro)
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
                _generoRepository.Deletar(id);

                return StatusCode(201, id);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

    }
}
