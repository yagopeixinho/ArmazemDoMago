using ArmazemDoMago.Models;
using ArmazemDoMago.Repositories;
using ArmazemDoMago.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace ArmazemDoMago.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [DisplayName("Usuários")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository ?? 
                throw new ArgumentNullException(nameof(usuarioRepository));
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> ListarTodosAsync()
        {
            try
            {
                List<UsuarioModel> usuarios = await _usuarioRepository.ListarTodosAsync();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> EncontrarPorIdAsync(int id)
        {
            try
            {
                UsuarioModel usuario = await _usuarioRepository.EncontrarPorIdAsync(id);
                if (usuario == null)
                {
                    return NotFound($"Usuário com ID {id} não encontrado.");
                }
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> CriarAsync([FromBody] UsuarioModel usuarioModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                UsuarioModel usuario = await _usuarioRepository.CriarAsync(usuarioModel);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> AtualizarAsync([FromBody] UsuarioModel usuarioModel, int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                usuarioModel.Id = id;
                UsuarioModel usuario = await _usuarioRepository.AtualizarAsync(usuarioModel, id);
                if (usuario == null)
                {
                    return NotFound($"Usuário com ID {id} não encontrado.");
                }
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> ExcluirAsync(int id)
        {
            try
            {
                bool apagado = await _usuarioRepository.ExcluirAsync(id);
                if (!apagado)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
}
