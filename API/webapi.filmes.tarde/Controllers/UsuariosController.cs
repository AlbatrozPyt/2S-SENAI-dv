using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;
using webapi.filmes.tarde.Repositories;

namespace webapi.filmes.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult LoginUser(string Senha, string Email) 
        {
            try
            {
                 UsuarioDomain user = _usuarioRepository.Login(Email, Senha);

                if (user != null)
                {
                    return StatusCode(200, user);
                }

                else
                {
                    return Unauthorized();
                }


                
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

    }
}
