using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.event_tarde.Domains;
using webapi.event_tarde.Interfaces;
using webapi.event_tarde.Repositories;

namespace webapi.event_tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class TipoEventoController : ControllerBase
    {
        private ITipoEventoRepository _tipoEventoRepository;

        public TipoEventoController() 
        {
            _tipoEventoRepository = new TipoEventoRepository();
        }

        [HttpPost("CadastrarTipoEvento")]
        public IActionResult Post(TipoEvento tipoEvento)
        {
            try
            {
                _tipoEventoRepository.Cadastrar(tipoEvento);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);       
            }
        }

        
        [HttpGet("ListarTipoEvento")]
        public IActionResult Get()
        {
            try
            {
                List<TipoEvento> tipoEventos = _tipoEventoRepository.Listar();

                return Ok(tipoEventos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("BuscarPorId")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                TipoEvento tipo = _tipoEventoRepository.BuscarPorId(id);

                return Ok(tipo);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpDelete("ExcluirTipoEvento")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _tipoEventoRepository.Deletar(id);

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        public IActionResult Put(Guid id, TipoEvento tipoEvento)
        {
            try
            {
                _tipoEventoRepository.Atualizar(id, tipoEvento);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
