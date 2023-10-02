﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_api_health_clinic.Domains;
using web_api_health_clinic.Interfaces;
using web_api_health_clinic.Repositories;

namespace web_api_health_clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class FeedbackController : ControllerBase
    {
        private IFeedbackRepository _feedbackRepository;

        public FeedbackController()
        {
            _feedbackRepository = new FeedbackRepository();
        }

        [HttpPost("ComentarConsultas")]
        public IActionResult Post(Feedback f)
        {
            try
            {
                _feedbackRepository.Comentar(f);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        [HttpGet("ListarFeedbacks")]
        public IActionResult Get(string nomeDoPaciente)
        {
            try
            {
               List<Feedback> feedbacks = _feedbackRepository.ListarComentarios(nomeDoPaciente);

                return StatusCode(200, feedbacks);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
