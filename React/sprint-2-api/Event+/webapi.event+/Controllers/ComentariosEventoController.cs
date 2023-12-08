using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        ComentariosEventoRepository _comentariosEvento = new ComentariosEventoRepository();


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
