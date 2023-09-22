using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.event_tarde.Domains;
using webapi.event_tarde.Interfaces;
using webapi.event_tarde.Repositories;
using webapi.event_tarde.ViewModels;

namespace webapi.event_tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel user)
        {
            try
            {
                Usuario usuarioLogin = _usuarioRepository.BuscarPorEmail(user.Email, user.Senha);

                if (usuarioLogin == null)
                {
                    return StatusCode(401, "Email ou Senha incorretos!!!");
                }


                var claims = new[]
               {
                   new Claim(JwtRegisteredClaimNames.Jti, usuarioLogin.IdUsuario.ToString()),
                   new Claim(JwtRegisteredClaimNames.Email, usuarioLogin.Email!),
                   new Claim(JwtRegisteredClaimNames.Name, usuarioLogin.Nome!.ToString()),
                   new Claim(ClaimTypes.Role, usuarioLogin.TipoUsuario!.Titulo!),
                   new Claim("Claim Personalizada", "Valor Personalizado")
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("webapi-chave-autenticacao-event-dev"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                (
                    issuer: "webapi.event-tarde",

                    audience: "webapi.event-tarde",
                
                    claims: claims,
                  
                    expires: DateTime.Now.AddMinutes(5),

                    signingCredentials: creds

                );

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }
}
