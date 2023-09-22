using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.CodeFirst.Domains;
using webapi.CodeFirst.Interfaces;
using webapi.CodeFirst.Repository;

namespace webapi.CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);

                return Ok(usuario);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
