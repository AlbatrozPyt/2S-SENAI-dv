using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;

namespace senai.inlock.webApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    //[Authorize]

    public class EstudioController : ControllerBase
    {
        private IEstudioRepository _estudioRepository {get; set;}

        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<EstudioDomain> lista = _estudioRepository.ListarEstudios();
                return Ok(lista);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Post(EstudioDomain estudio)
        {
            try
            {
                _estudioRepository.Cadastrar(estudio);
                return Ok(estudio);
            }
            catch (Exception erro)
            { 
                return BadRequest(erro.Message);
            }
        }
    }
}