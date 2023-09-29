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

    public class ClinicaController : ControllerBase
    {
        private IClinicaRepository _clinicaRepository;

        public ClinicaController()
        {
            _clinicaRepository = new ClinicaRepository();
        }

        [HttpPost("CadastrarClinica")]
        public IActionResult Post(Clinica c)
        {
            try
            {
                _clinicaRepository.Cadastrar(c);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("DeletarClinica")]
        public IActionResult Delete(Guid id) 
        {
            try
            {
                _clinicaRepository.Deletar(id);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("ListarClinicas")]
        public IActionResult Get() 
        {
            try
            {
                List<Clinica> lista = _clinicaRepository.ListarClinicas();
                return Ok(lista);
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
                Clinica clinica = _clinicaRepository.BuscarPorId(id);

                return StatusCode(200, clinica);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("AtualizarClinica")]
        public IActionResult Put(Clinica clinica, Guid id)
        {
            try
            {
                _clinicaRepository.Atualizar(clinica, id);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
