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

    public class PacienteController : ControllerBase
    {
        private IPacienteRepository _pacienteRepository;

        public PacienteController() 
        { 
            _pacienteRepository = new PacienteRepository();
        }


        /// <summary>
        /// Listar todos os pacientes
        /// </summary>
        /// <returns></returns>
        [HttpGet("ListarPacientes")]
        public IActionResult Get()
        {
            try
            {
                List<Paciente> pacientes = _pacienteRepository.ListarPacientes();

                return StatusCode(200, pacientes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Cadastro de pacientes
        /// </summary>
        /// <param name="medico">Paciente</param>
        /// <returns></returns>
        [HttpPost("CadastrarPacientes")]
        public IActionResult Post(Paciente paciente)
        {
            try
            {
                _pacienteRepository.Cadastrar(paciente);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Buscar paciente por id
        /// </summary>
        /// <param name="id">Id do paciente</param>
        /// <returns></returns>
        [HttpGet("BuscarPorId")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Paciente paciente = _pacienteRepository.BuscarPorId(id);
                return StatusCode(200, paciente);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Atualizar paciente existente
        /// </summary>
        /// <param name="medico">paciente novo</param>
        /// <param name="id">id do paciente</param>
        /// <returns></returns>
        [HttpPut("AtualizarPaciente")]
        public IActionResult Put(Paciente paciente, Guid id)
        {
            try
            {
                _pacienteRepository.Atualizar(paciente, id);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Deletar paciente pelo id
        /// </summary>
        /// <param name="id">id do paciente</param>
        /// <returns></returns>
        [HttpDelete("DeletarPaciente")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _pacienteRepository.Deletar(id);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Listar todas as consultas do paciente
        /// </summary>
        /// <param name="id">Id do paciente</param>
        /// <returns></returns>
        [HttpGet("ListarConsultasRelacionadas")]
        public IActionResult GetConsultas(Guid id)
        {
            try
            {
                List<Consulta> consultas = _pacienteRepository.Consultas(id);
                return StatusCode(200, consultas);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
