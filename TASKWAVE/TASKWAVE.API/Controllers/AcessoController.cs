using Microsoft.AspNetCore.Mvc;
using TASKWAVE.DOMAIN.ENTITY;
using TASKWAVE.API.Requests;
using TASKWAVE.API.Responses;
using TASKWAVE.DOMAIN.Interfaces.Services;
using TASKWAVE.DOMAIN.Services;

namespace TASKWAVE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcessoController : ControllerBase
    {
        private readonly IAcessoService _accessService;

        public AcessoController(IAcessoService accessService)
        {
            _accessService = accessService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcessoResponse>>> GetAll()
        {
            var access = await _accessService.GetAllAccesses();
            var accessResponse = access.Select(access => new AcessoResponse(access.NomeAcesso, access.DescricaoAcesso, access.DataCriacaoAcesso));
            return Ok(accessResponse);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AcessoResponse>> GetById(int id)
        {
            var access = await _accessService.GetAccessById(id);
            if (access == null)
                return NotFound();
            return Ok(new AcessoResponse(access.NomeAcesso, access.DescricaoAcesso, access.DataCriacaoAcesso));
        }

        [HttpPost]
        public async Task<ActionResult> Create(AcessoRequest accessRequest)
        {
            var access = new Acesso(accessRequest.NomeAcesso, accessRequest.DescricaoAcesso, accessRequest.DataCriacaoAcesso);
            await _accessService.CreateAccess(access);
            return CreatedAtAction(nameof(GetById), new { id = access.IdAcesso }, null);
        }

        [HttpPost("AddAccessToUser/{idAccess}/{idUser}")]
        public async Task InsertAccessToUser(int idAccess, int idUser)
        {
            await _accessService.InsertAccessToUser(idAccess, idUser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, AcessoRequest accessRequest)
        {

            var accessExist = await _accessService.GetAccessById(id);
            if (accessExist == null)
            {
                return NotFound();
            }

            accessExist.NomeAcesso = accessRequest.NomeAcesso;
            accessExist.DescricaoAcesso = accessRequest.DescricaoAcesso;

            await _accessService.UpdateAccess(accessExist);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _accessService.DeleteAccess(id);
            return NoContent();
        }
    }
}
