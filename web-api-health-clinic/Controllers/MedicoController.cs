using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_api_health_clinic.Domains;
using web_api_health_clinic.Interfaces;
using web_api_health_clinic.Repositories;

namespace web_api_health_clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class MedicoController : ControllerBase
    {
        private IMedicoRepository _medicoRepository;

        public MedicoController()
        {
            _medicoRepository = new MedicoRepository();
        }

        [HttpGet("ListarMedicos")]
        public IActionResult Get()
        {
            try
            {
                List<Medico> medicos = _medicoRepository.ListarMedicos();

                return StatusCode(200, medicos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("CadastrarMedico")]
        public IActionResult Post(Medico medico) 
        {
            try
            {
                _medicoRepository.Cadastrar(medico);
                return StatusCode(200);
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
                Medico medico = _medicoRepository.BuscarPorId(id);
                return StatusCode(200, medico);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("AtualizarMedico")]
        public IActionResult Put(Medico medico, Guid id) 
        {
            try
            {
                _medicoRepository.Atualizar(medico, id);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("DeletarMedico")]
        public IActionResult Delete(Guid id) 
        {
            try
            {
                _medicoRepository.Deletar(id);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("ListarConsultasRelacionadas")]
        public IActionResult GetConsultas(Guid id) 
        {
            try
            {
                List<Consulta> consultas = _medicoRepository.Consultas(id);
                return StatusCode(200, consultas);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
