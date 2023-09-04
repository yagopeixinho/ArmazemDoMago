using ArmazemDoMago.Models;
using ArmazemDoMago.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArmazemDoMago.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ArmazemController : ControllerBase
    {
        private readonly IArmazemRepository _armazemRepository;

        public ArmazemController(IArmazemRepository armazemRepository)
        {
            _armazemRepository = armazemRepository ??
                throw new ArgumentNullException(nameof(armazemRepository));
        }

        [HttpGet]
        public async Task<ActionResult<List<ArmazemModel>>> ListarTodosAsync()
        {
            try
            {
                List<ArmazemModel> armazem = await _armazemRepository.ListarTodosAsync();
                return Ok(armazem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ArmazemModel>> EncontrarPorIdAsync(int id)
        {
            try
            {
                ArmazemModel armazem = await _armazemRepository.EncontrarPorIdAsync(id);
                if (armazem == null)
                {
                    return NotFound($"Armazém com ID {id} não encontrado.");
                }
                return Ok(armazem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ArmazemModel>> CriarAsync([FromBody] ArmazemModel armazemModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                ArmazemModel armazem = await _armazemRepository.CriarAsync(armazemModel);
                return Ok(armazem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ArmazemModel>> AtualizarAsync(int id, [FromBody] ArmazemModel armazemModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                armazemModel.Id = id;
                ArmazemModel armazem = await _armazemRepository.AtualizarAsync(armazemModel, id);
                if (armazem == null)
                {
                    return NotFound($"Armazém com ID {id} não encontrado.");
                }
                return Ok(armazem);
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
                bool apagado = await _armazemRepository.ExcluirAsync(id);
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

        [HttpGet("notificacao_baixo_estoque")]
        public async Task<ActionResult<string>> NotificacaoBaixoEstoque()
        {
            try
            {
                var mensagemAlerta = await _armazemRepository.NotificacaoBaixoEstoque();
                return Ok(mensagemAlerta);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
}
