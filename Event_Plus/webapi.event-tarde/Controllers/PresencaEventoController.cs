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

    public class PresencaEventoController : ControllerBase
    {
        private IPresencaEventoRepository _presencaEventoRepository;

        public PresencaEventoController()
        {
            _presencaEventoRepository = new PresencaEventoRepository();
        }

        [HttpPost("CadastarPresenca")]
        public IActionResult Post(PresencaEvento presenca)
        {
            try
            {
                _presencaEventoRepository.Cadastrar(presenca);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("PresencasUsuario")]
        public IActionResult Get(Guid id)
        {
            try
            {
                List<PresencaEvento> p = _presencaEventoRepository.ListarPresencas(id);
                return Ok(p);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("DeletarPresenca")]
        public IActionResult Delete(Guid id) 
        {
            try
            {
                _presencaEventoRepository.Deletar(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
