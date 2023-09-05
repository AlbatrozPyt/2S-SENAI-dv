using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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

        /// <summary>
        /// Endpoint que traz o metodo Login do Usuario
        /// </summary>
        /// <param name="Senha"></param>
        /// <param name="Email"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult LoginUser(string Email, string Senha)
        {
            try
            {
                UsuarioDomain user = _usuarioRepository.Login(Email, Senha);

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
                   new Claim(ClaimTypes.Role, user.Permissao),
                   // Claim Personalizada
                   new Claim("Claim Personalizada", "Valor Personalizado")
                };

                // 2 - Definir a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev"));

                // 3 - Definir as credenciais do Token (header)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // 4 - Gerar o token
                var token = new JwtSecurityToken
                (
                    // emissor do token
                    issuer: "webapi.filmes.tarde",

                    // destinatario
                    audience: "webapi.filmes.tarde",

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
