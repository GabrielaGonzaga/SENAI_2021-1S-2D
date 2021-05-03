using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using senai.hroads.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class LoginsController : ControllerBase
    {
        /// <summary>
        /// Objeto _usuarioRepository que irá receber todos os métodos definidos na interface IUsuarioRepository
        /// </summary>
        private IUsuarioRepository _usuarioRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _usuarioRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public LoginsController()
        {
            _usuarioRepository = new UsuarioRepository();
        }


        [HttpPost]
        public IActionResult Login(Usuario login)
        {
            //Busca o usuário pelo e-mail e senha
            Usuario usuarioBuscado = _usuarioRepository.Login(login.Email, login.Senha);

            //Caso não encontre nenhum usuário com o e-mail e senha informados
            if (usuarioBuscado == null)
            {
                //retorna NotFound com uma mensagem personalizada
                return NotFound("E-mail ou senha inválidos!");
            }

            //Caso encontre um token será criado

            //Dados fornceidos no token (Payload)
            var claims = new[]
            {
                                              //Tipo da claim + seu valor
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.idTipoUsuario.ToString())

            };

            //Chave de acesso do token          Valor codificado
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Semprepea10_usuarios"));

            //Credenciais do token
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //Gera o token 
            var token = new JwtSecurityToken(

                issuer: "HROADS.webApi",                 // emissor do token
                audience: "HROADS.webApi",               // destinatário do token
                claims: claims,                         // dados de definidos "claims (linha 53)"
                expires: DateTime.Now.AddMinutes(45),    // tempo de expiração (05:38)
                signingCredentials: creds                // credenciais do token 
            );

            //Retorna um satus code 200 (Token foi criado)
            return Ok(new
            {

                token = new JwtSecurityTokenHandler().WriteToken(token)

            });

        }
    }
}
