using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_tarde.Domains;
using webapi.event_tarde.Interfaces;
using webapi.event_tarde.Repositories;

namespace webapi.event_tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class ComentarioEventoController : ControllerBase
    {
        private IComentarioRepository _comentarioRepository;

        public ComentarioEventoController()
        {
            _comentarioRepository = new ComentarioRepository();
        }

        [HttpPost]
        public IActionResult Post(ComentarioEvento com)
        {
            try
            {
                _comentarioRepository.Comentario(com);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
