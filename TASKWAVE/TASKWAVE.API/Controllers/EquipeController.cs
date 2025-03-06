using Microsoft.AspNetCore.Mvc;
using TASKWAVE.API.Infrastructure.Model;
using TASKWAVE.API.Requests;
using TASKWAVE.API.Responses;
using TASKWAVE.DOMAIN.Interfaces.Services;

namespace TASKWAVE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipeController : ControllerBase
    {
        private readonly IEquipeService _equipeService;

        public EquipeController(IEquipeService equipeService)
        {
            _equipeService = equipeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipeResponse>>> GetAll()
        {
            var equipes = await _equipeService.GetAllEquipes();
            var response = equipes.Select(equipe => new EquipeResponse(equipe.NomeEquipe, equipe.DescricaoEquipe, equipe.SetorId));
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EquipeResponse>> GetById(int id)
        {
            var equipe = await _equipeService.GetEquipeById(id);
            if (equipe == null)
                return NotFound();
            return Ok(new EquipeResponse(equipe.NomeEquipe, equipe.DescricaoEquipe, equipe.SetorId));
        }

        [HttpPost]
        public async Task<ActionResult> Create(EquipeRequest request)
        {
            var equipe = new Equipe(request.nomeEquipe, request.descricaoEquipe, request.idSetor);
            await _equipeService.CreateEquipe(equipe);
            return CreatedAtAction(nameof(GetById), new { id = equipe.IdEquipe }, null);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, EquipeRequest request)
        {

            var equipeExiste = await _equipeService.GetEquipeById(id);
            if (equipeExiste == null)
            {
                return NotFound();
            }

            equipeExiste.NomeEquipe = request.nomeEquipe;
            equipeExiste.DescricaoEquipe = request.descricaoEquipe;
            equipeExiste.SetorId = request.idSetor;

            await _equipeService.UpdateEquipe(equipeExiste);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _equipeService.DeleteEquipe(id);
            return NoContent();
        }
    }
}
