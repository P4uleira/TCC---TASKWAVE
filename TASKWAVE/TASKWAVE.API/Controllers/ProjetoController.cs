using Azure;
using Microsoft.AspNetCore.Mvc;
using TASKWAVE.API.Infrastructure.Model;
using TASKWAVE.API.Requests;
using TASKWAVE.API.Responses;
using TASKWAVE.DOMAIN.Interfaces.Services;

namespace TASKWAVE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoService _projetoService;

        public ProjetoController(IProjetoService projetoService)
        {
            _projetoService = projetoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjetoResponse>>> GetAll()
        {
            var projetos = await _projetoService.GetAllProjetos();
            var response = projetos.Select(projeto => new ProjetoResponse(projeto.NomeProjeto, projeto.DescricaoProjeto, projeto.DataCriacaoProjeto));
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjetoResponse>> GetById(int id)
        {
            var projeto = await _projetoService.GetProjetoById(id);
            if (projeto == null)
                return NotFound();
            return Ok(new ProjetoResponse(projeto.NomeProjeto, projeto.DescricaoProjeto, projeto.DataCriacaoProjeto));
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProjetoRequest request)
        {
            var projeto = new Projeto(request.nomeProjeto, request.descricaoProjeto, request.dataCriacaoProjeto);
            await _projetoService.CreateProjeto(projeto);
            return CreatedAtAction(nameof(GetById), new { id = projeto.IdProjeto }, null);
        }

        [HttpPost("AddProjectInEquip")]
        public async Task CreateProjectToEquip(ProjetoRequest projeto, int idEquipe)
        {
            var newProjeto = new Projeto(projeto.nomeProjeto, projeto.descricaoProjeto, projeto.dataCriacaoProjeto);
            await _projetoService.CreateProjectToEquip(newProjeto, idEquipe);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, ProjetoRequest request)
        {

            var projetoExistente = await _projetoService.GetProjetoById(id);
            if (projetoExistente == null)
            {
                return NotFound();
            }

            projetoExistente.NomeProjeto = request.nomeProjeto;
            projetoExistente.DescricaoProjeto = request.descricaoProjeto;

            await _projetoService.UpdateProjeto(projetoExistente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _projetoService.DeleteProjeto(id);
            return NoContent();
        }
    }
}
