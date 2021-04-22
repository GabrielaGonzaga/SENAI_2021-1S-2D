using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        /// <summary>
        /// Objeto _usuarioRepository que irá receber todos os métodos definidos na interface IUsuarioRepository
        /// </summary>
        private IUsuarioRepository _usuarioRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _usuarioRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost("Login")]
        public IActionResult Login(UsuarioDomain login)
        {
            //Busca o usuário pelo e-mail e senha
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorEmailSenha(login.email, login.senha);

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
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.idUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.idTipoUsuario.ToString())

            };

            //Chave de acesso do token          Valor codificado
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Semprepea10_usuarios"));

            //Credenciais do token
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //Gera o token 
            var token = new JwtSecurityToken(

                issuer: "Inlock.webApi",                 // emissor do token
                audience: "Inlock.webApi",               // destinatário do token
                claims:  claims,                         // dados de definidos "claims (linha 51)"
                expires: DateTime.Now.AddMinutes(45),    // tempo de expiração (18:26)
                signingCredentials: creds                // credenciais do token 
            );

            //Retorna um satus code 200 (Token foi criado)
            return Ok(new { 

                token = new JwtSecurityTokenHandler().WriteToken(token)

            });

        }    
    }
}


