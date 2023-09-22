using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.CodeFirst.Domains;
using webapi.CodeFirst.Interfaces;
using webapi.CodeFirst.Repository;
using webapi.CodeFirst.ViewModels;

namespace webapi.CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel user)
        {
            try
            {
                Usuario usuarioLogin = _usuarioRepository.Login(user.Email, user.Senha);

                if (usuarioLogin == null)
                {
                    return StatusCode(401, "Email ou Senha incorretos !!!");
                }



                var claims = new[]
                {
                    // Formato claim(tipo, valor)
                   new Claim(JwtRegisteredClaimNames.Jti, usuarioLogin.IdUsuario.ToString()),  
                   new Claim(JwtRegisteredClaimNames.Email, usuarioLogin.Email),
                   new Claim(ClaimTypes.Role, usuarioLogin.TipoUsuario.Titulo),
                   // Claim Personalizada
                   new Claim("Claim Personalizada", "Valor Personalizado")
                };

                // 2 - Definir a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("webapi-chave-autenticacao-codefirst-dev"));

                // 3 - Definir as credenciais do Token (header)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // 4 - Gerar o token
                var token = new JwtSecurityToken
                (
                    // emissor do token
                    issuer: "webapi.CodeFirst",

                    // destinatario
                    audience: "webapi.CodeFirst",

                    // dados definidos nas claims (Payload)
                    claims: claims,

                    // tempo de expiracao
                    expires: DateTime.Now.AddMinutes(5),

                    // credenciais do token
                    signingCredentials: creds

                );

                // 5 - retorna o token criado
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
