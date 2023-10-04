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

    public class ConsultaController : ControllerBase
    {
        private IConsultaRepository _consultaRepository;

        public ConsultaController() 
        {
            _consultaRepository = new ConsultaRepository();
        }

        /// <summary>
        /// Listar todas as consultas
        /// </summary>
        /// <returns></returns>
        [HttpGet("ListarConsultas")]
        public IActionResult Get()
        {
            try
            {
                List<Consulta> consultas = _consultaRepository.ListarConsultas();

                return StatusCode(200, consultas);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Cadastrar uma nova consulta
        /// </summary>
        /// <param name="consulta">Consulta</param>
        /// <returns></returns>
        [HttpPost("CadastrarConsulta")]
        public IActionResult Post(Consulta consulta)
        {
            try
            {
                _consultaRepository.Cadastrar(consulta);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Busca consulta pelo id
        /// </summary>
        /// <param name="id">Id da consulta</param>
        /// <returns></returns>
        [HttpGet("BuscarPorId")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Consulta consulta = _consultaRepository.BuscarPorID(id);
                return StatusCode(200, consulta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Atualizar consulta existente
        /// </summary>
        /// <param name="consulta">Nova consulta</param>
        /// <param name="id">Id da conslta</param>
        /// <returns></returns>
        [HttpPut("AtualizarConsulta")]
        public IActionResult Put(Consulta consulta, Guid id)
        {
            try
            {
                _consultaRepository.Atualizar(consulta, id);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Excluir consulta
        /// </summary>
        /// <param name="id">Id da consulta</param>
        /// <returns></returns>
        [HttpDelete("DeletarConsulta")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _consultaRepository.Deletar(id);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
