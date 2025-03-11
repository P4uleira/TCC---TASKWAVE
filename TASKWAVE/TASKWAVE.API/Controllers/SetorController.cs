using Microsoft.AspNetCore.Mvc;
using TASKWAVE.API.Infrastructure.Model;
using TASKWAVE.API.Requests;
using TASKWAVE.API.Responses;
using TASKWAVE.DOMAIN.Interfaces.Services;

namespace TASKWAVE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetorController : ControllerBase
    {
        private readonly ISetorService _setorService;

        public SetorController(ISetorService setorService)
        {
            _setorService = setorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SetorResponse>>> GetAll()
        {
            var setores = await _setorService.GetAllSetores();
            var response = setores.Select(setor => new SetorResponse(setor.NomeSetor, setor.DescricaoSetor, setor.AmbienteId));
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SetorResponse>> GetById(int id)
        {
            var setor = await _setorService.GetSetorById(id);
            if (setor == null)
                return NotFound();
            return Ok(new SetorResponse(setor.NomeSetor, setor.DescricaoSetor, setor.AmbienteId));
        }

        [HttpPost]
        public async Task<ActionResult> Create(SetorRequest request)
        {
            var setor = new Setor(request.nomeSetor, request.descricaoSetor, request.idAmbiente);
            await _setorService.CreateSetor(setor);
            return CreatedAtAction(nameof(GetById), new { id = setor.IdSetor }, null);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, SetorRequest request)
        {

            var setorExistente = await _setorService.GetSetorById(id);
            if (setorExistente == null)
            {
                return NotFound();
            }

            setorExistente.NomeSetor = request.nomeSetor;
            setorExistente.DescricaoSetor = request.descricaoSetor;
            setorExistente.AmbienteId = request.idAmbiente;

            await _setorService.UpdateSetor(setorExistente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _setorService.DeleteSetor(id);
            return NoContent();
        }
    }
}
