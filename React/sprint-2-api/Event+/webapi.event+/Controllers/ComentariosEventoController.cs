using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.ContentModerator;
using System.Text;
using webapi.event_.Domains;
using webapi.event_.Interfaces;
using webapi.event_.Repositories;

namespace webapi.event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class ComentariosEventoController : ControllerBase
    {

        // Acesso dos metodos do repositorio
        ComentariosEventoRepository _comentariosEvento = new ComentariosEventoRepository();

        // Armazena dados da Api Externa
        private readonly ContentModeratorClient _contentModeratorClient;


        /// <summary>
        /// Construtor que recebe os dados para o acesso ao servico externo
        /// </summary>
        /// <param name="contentModeratorClient">objeto contentModeratorCLient</param>
        public ComentariosEventoController(ContentModeratorClient contentModeratorClient)
        {
            _contentModeratorClient = contentModeratorClient;
        }

        [HttpPost("CadastroIA")]
        public async Task<IActionResult> PostIA(ComentariosEvento comentario)
        {
            try
            {
                // Se a descricao do comentario nao for passado no objeto
                if (string.IsNullOrEmpty(comentario.Descricao))
                {
                    return BadRequest("O comentario nao pode ser vazio");
                }

                // Converte a string (descricao do comentario em um Memory Stream)
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(comentario.Descricao));

                // Realiza a moderacao do conteudo (Descricao do comentario)
                var moderationResult = await _contentModeratorClient.TextModeration
                    .ScreenTextAsync("text/plain", stream, "por", false, false, null, true);


                // Se existir termos ofensivos 
                if (moderationResult.Terms != null)
                {
                    comentario.Exibe = false;  // Atribui false para EXIBE

                    _comentariosEvento.Cadastrar(comentario); // Cadastra o comentario
                }
                else
                {
                    comentario.Exibe = true; // Atribui true para EXIBE

                    _comentariosEvento.Cadastrar(comentario); // Cadastra o comentario
                }

                return StatusCode(201, comentario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        [HttpGet("ListarSomenteExibe")]
        public IActionResult GetIA()
        {
            try
            {
                return StatusCode(200, _comentariosEvento.ListarSomenteExibe());
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return StatusCode(200, _comentariosEvento.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


        [HttpGet("BuscarPorIdUsuario")]
        public IActionResult GetByUserId(Guid idEvento, Guid idUsuario)
        {
            try
            {
                return StatusCode(200, _comentariosEvento.BuscarPorIdUsuario(idUsuario, idEvento));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return StatusCode(200, _comentariosEvento.BuscarPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        public IActionResult Post(ComentariosEvento c)
        {
            try
            {
                _comentariosEvento.Cadastrar(c);
                return StatusCode(201, c);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("DeletarComentario/{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _comentariosEvento.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
