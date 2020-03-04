using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using InLock.WebAPI.Domains;
using InLock.WebAPI.Interfaces;
using InLock.WebAPI.Repositories;
using InLock.WebAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace InLock.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private UsuarioRepository _usuarioRepository { get; set; }

      
        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

      
        [HttpPost]
        public IActionResult Post(LoginViewModel login)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarEmailSenha(login.Email, login.Senha);

            if (usuarioBuscado.Email == null)
            {  
                return NotFound("E-MAIL OU SENHA INVÁLIDOS");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.FK_IdTipoUsuario.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-key-authentication"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    
            var token = new JwtSecurityToken(
                issuer: "InLock.WebAPI",                
                audience: "InLock.WebAPI",              
                claims: claims,                          
                expires: DateTime.Now.AddMinutes(30),    
                signingCredentials: creds                
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }

    }
}