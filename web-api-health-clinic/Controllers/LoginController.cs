using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using web_api_health_clinic.Domains;
using web_api_health_clinic.Interfaces;
using web_api_health_clinic.Repositories;
using web_api_health_clinic.ViewModels;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace web_api_health_clinic.Controllers
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

        [HttpPost("Login")]
        public IActionResult Login(LoginViewModel user)
        {
            try
            {
                Usuario usuarioLogin = _usuarioRepository.BuscarEmail(user.Email, user.Senha);

                if (usuarioLogin == null)
                {
                    return StatusCode(400, "Senha ou Email incorretos!!!");
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioLogin.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuarioLogin.Email!.ToString()),
                    new Claim(JwtRegisteredClaimNames.Name, usuarioLogin.Nome!.ToString()),
                    new Claim(ClaimTypes.Role, usuarioLogin.TiposUsuario!.Titulo!.ToString())
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("webapi-chave-autenticacao-health-clinic"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                (
                     issuer: "webapi.healthClinic-tarde",

                    audience: "webapi.healthClinic-tarde",

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
