using ArmazemDoMago.Migrations;
using ArmazemDoMago.Models;
using ArmazemDoMago.Repositories;
using ArmazemDoMago.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
            _armazemRepository = armazemRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ArmazemModel>>> BuscarTodosItems()
        {
            List<ArmazemModel> armazem = await _armazemRepository.BuscarTodosItems();
            return Ok(armazem);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ArmazemModel>> BuscarPorId(int id)
        {
            ArmazemModel armazem = await _armazemRepository.BuscarPorId(id);
            return Ok(armazem);
        }

        [HttpGet("verificarItens")]
        public async Task<ActionResult<ArmazemModel>> AlertaItemsArmazem()
        {
            var mensagemAlerta = await _armazemRepository.AlertaUnidadeItems();
            return Ok(mensagemAlerta);
        }

        [HttpPost]
        public async Task<ActionResult<ArmazemModel>> Cadastrar([FromBody] ArmazemModel armazemModel)
        {
            ArmazemModel armazem = await _armazemRepository.Adicionar(armazemModel);
            return Ok(armazem);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ArmazemModel>> Atualizar([FromBody] ArmazemModel armazemModel, int id)
        {
            armazemModel.Id = id;
            ArmazemModel armazem = await _armazemRepository.Atualizar(armazemModel, id);
            return Ok(armazem);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Excluir(int id)
        {
            bool apagado = await _armazemRepository.Apagar(id);
            return Ok(apagado);
        }

    }
}


