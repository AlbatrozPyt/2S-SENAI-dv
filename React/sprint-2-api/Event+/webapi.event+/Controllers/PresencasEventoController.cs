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

    public class PresencasEventoController : ControllerBase
    {
        private IPresencasEventoRepository _presencasEventoRepository;

        public PresencasEventoController()
        {
            _presencasEventoRepository = new PresencaRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_presencasEventoRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        public IActionResult Post(PresencasEvento presencasEvento)
        {
            try
            {
                _presencasEventoRepository.Inscrever(presencasEvento);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("ListarMinhas/{id}")]
        public IActionResult GetMy(Guid id)
        {
            try
            {
                return Ok(_presencasEventoRepository.ListarMinhas(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
