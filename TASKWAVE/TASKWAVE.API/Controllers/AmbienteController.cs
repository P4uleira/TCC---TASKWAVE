using Microsoft.AspNetCore.Mvc;
using TASKWAVE.API.Infrastructure.Model;
using TASKWAVE.API.Requests;
using TASKWAVE.API.Responses;
using TASKWAVE.DOMAIN.Interfaces.Services;

namespace TASKWAVE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmbienteController : ControllerBase
    {
        private readonly IAmbienteService _ambienteService;

        public AmbienteController(IAmbienteService ambienteService)
        {
            _ambienteService = ambienteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AmbienteResponse>>> GetAll()
        {
            var ambientes = await _ambienteService.GetAllAmbientes();
            var response = ambientes.Select(ambiente => new AmbienteResponse(ambiente.NomeAmbiente, ambiente.DescricaoAmbiente));
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AmbienteResponse>> GetById(int id)
        {
            var ambiente = await _ambienteService.GetAmbienteById(id);
            if (ambiente == null)
                return NotFound();
            return Ok(new AmbienteResponse(ambiente.NomeAmbiente, ambiente.DescricaoAmbiente));
        }

        [HttpPost]
        public async Task<ActionResult> Create(AmbienteRequest request)
        {
            var ambiente = new Ambiente(request.nomeAmbiente, request.descricaoAmbiente);
            await _ambienteService.CreateAmbiente(ambiente);
            return CreatedAtAction(nameof(GetById), new { id = ambiente.IdAmbiente }, null);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, AmbienteRequest request)
        {

            var ambienteExistente = await _ambienteService.GetAmbienteById(id);
            if (ambienteExistente == null)
            {
                return NotFound();
            }

            ambienteExistente.NomeAmbiente = request.nomeAmbiente;
            ambienteExistente.DescricaoAmbiente = request.descricaoAmbiente;
            
            await _ambienteService.UpdateAmbiente(ambienteExistente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _ambienteService.DeleteAmbiente(id);
            return NoContent();
        }
    }
}
