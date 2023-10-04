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

        /// <summary>
        /// Listar todos os medicos
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Cadastro de medicos
        /// </summary>
        /// <param name="medico">Medico</param>
        /// <returns></returns>
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

        /// <summary>
        /// Buscar medico por id
        /// </summary>
        /// <param name="id">Id do medico</param>
        /// <returns></returns>
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

        /// <summary>
        /// Atualizar medico existente
        /// </summary>
        /// <param name="medico">medico novo</param>
        /// <param name="id">id do medico</param>
        /// <returns></returns>
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

        /// <summary>
        /// Deletar medico pelo id
        /// </summary>
        /// <param name="id">id do medico</param>
        /// <returns></returns>
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

        /// <summary>
        /// Listar todas as consultas do medico
        /// </summary>
        /// <param name="id">Id do medico</param>
        /// <returns></returns>
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
