using ArmazemDoMago.DTOs;
using ArmazemDoMago.Models;
using ArmazemDoMago.Repositories;
using ArmazemDoMago.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ArmazemDoMago.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        public static UsuarioModel usuario = new UsuarioModel();
        private readonly IAutenticacaoRepository _autenticacaoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IConfiguration _configuration;

        public AutenticacaoController(
            IConfiguration configuration,
            IAutenticacaoRepository autenticacaoRepository, 
            IUsuarioRepository usuarioRepository)
        {
            _autenticacaoRepository = autenticacaoRepository;
            _usuarioRepository = usuarioRepository;
            _configuration = configuration;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<UsuarioModel>> Registrar(UsuarioDTO request)
        {
            string passwordHash
                = BCrypt.Net.BCrypt.HashPassword(request.Senha);

            usuario.Email = request.Email;
            usuario.SenhaHash = passwordHash;

            UsuarioModel novoUsuario = await _usuarioRepository.Adicionar(usuario);

            return Ok(novoUsuario);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UsuarioModel>> Login(UsuarioDTO request)
        {
            var usuarioValidado = await _autenticacaoRepository.ValidarCredenciais(request);

            if (usuario == null)
            {
                return BadRequest("Usuário não encontrado!");            
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Senha, usuarioValidado.SenhaHash))
            {
              return BadRequest("Wrong password!");
            }

            string token = CreateToken(usuario);
          
            return Ok(token);
        }

        private string CreateToken(UsuarioModel usuario)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, "peixinhoyago@gmail.com"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
