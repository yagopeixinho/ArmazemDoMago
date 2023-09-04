using ArmazemDoMago.DTOs;
using ArmazemDoMago.Models;
using ArmazemDoMago.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
            try
            {
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Senha);

                var usuario = new UsuarioModel
                {
                    Email = request.Email,
                    Senha = passwordHash
                };

                UsuarioModel novoUsuario = await _usuarioRepository.CriarAsync(usuario);

                return Ok(novoUsuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<UsuarioModel>> Login(UsuarioDTO request)
        {
            try
            {
                var usuarioValidado = await _autenticacaoRepository
                    .ValidarCredenciaisAsync(request);

                if (usuarioValidado == null)
                {
                    return BadRequest("Usuário não encontrado!");
                }

                if (!BCrypt.Net.BCrypt.Verify(request.Senha, usuarioValidado.Senha))
                {
                    return BadRequest("Senha incorreta!");
                }

                string token = CreateToken(usuarioValidado);

                return Ok(token);
            }
            catch (Exception ex)
            {
                // Registre a exceção ou retorne uma resposta HTTP apropriada
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        private string CreateToken(UsuarioModel usuario)
        {
            if (usuario.Email == null)
            {
                throw new ArgumentNullException(nameof(usuario));
            }

            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name, usuario.Email),
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
