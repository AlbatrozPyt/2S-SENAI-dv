using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;

namespace senai.inlock.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            try
            {
                UsuarioDomain user = _usuarioRepository.Login(email, senha);

                if (user == null)
                {
                    return NotFound("O usuario nao foi encontrado, email ou senha incorretos !!!");
                }

                // Caso encontre o user, prossegue para a criacao do token

                // 1 - Definir as informacoes (claims) que serao fornecidas ao token (payload)
                var claims = new[]
                {
                    // Formato claim(tipo, valor)
                   new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, user.IdUsuario.ToString()),
                   new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Email, user.Email),
                   new Claim(ClaimTypes.Role, user.TiposDeUsuario.Titulo),
                   // Claim Personalizada
                   new Claim("Claim Personalizada", "Valor Personalizado")
                };

                // 2 - Definir a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-chave-autenticacao-webapi-dev"));

                // 3 - Definir as credenciais do Token (header)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // 4 - Gerar o token
                var token = new JwtSecurityToken
                (
                    // emissor do token
                    issuer: "senai.inlock.webapi",

                    // destinatario
                    audience: "senai.inlock.webapi",

                    // dados definidos nas claims (Payload)
                    claims: claims,

                    // tempo de expiracao
                    expires: DateTime.Now.AddMinutes(5),

                    // credenciais do token
                    signingCredentials: creds

                );

                // 5 - retorna o token criado
                return Ok
                (
                    new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token)
                    }
                );

            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }

        }

    }
}
