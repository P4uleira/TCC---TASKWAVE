using Microsoft.AspNetCore.Mvc;
using TASKWAVE.DOMAIN.ENTITY;
using TASKWAVE.API.Requests;
using TASKWAVE.API.Responses;
using TASKWAVE.DOMAIN.Interfaces.Services;

namespace TASKWAVE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetorController : ControllerBase
    {
        private readonly ISetorService _sectorService;

        public SetorController(ISetorService sectorService)
        {
            _sectorService = sectorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SetorResponse>>> GetAll()
        {
            var sectors = await _sectorService.GetAllSectors();
            var response = sectors.Select(sector => new SetorResponse(sector.NomeSetor, sector.DescricaoSetor, sector.AmbienteId));
            return Ok(response);
        }

        [HttpGet("{idsector}")]
        public async Task<ActionResult<SetorResponse>> GetById(int idSector)
        {
            var sector = await _sectorService.GetSectorById(idSector);
            if (sector == null)
                return NotFound();
            return Ok(new SetorResponse(sector.NomeSetor, sector.DescricaoSetor, sector.AmbienteId));
        }

        [HttpPost]
        public async Task<ActionResult> Create(SetorRequest sectorRequest)
        {
            var sector = new Setor(sectorRequest.sectorName, sectorRequest.sectorDescription, sectorRequest.environmentId);
            await _sectorService.CreateSector(sector);
            return CreatedAtAction(nameof(GetById), new { idsector = sector.IdSetor }, null);
        }


        [HttpPut("{idSector}")]
        public async Task<ActionResult> Update(int idSector, SetorRequest sectorRequest)
        {

            var existingSector = await _sectorService.GetSectorById(idSector);
            if (existingSector == null)
            {
                return NotFound();
            }

            existingSector.NomeSetor = sectorRequest.sectorName;
            existingSector.DescricaoSetor = sectorRequest.sectorDescription;
            existingSector.AmbienteId = sectorRequest.environmentId;

            await _sectorService.UpdateSector(existingSector);
            return NoContent();
        }

        [HttpDelete("{idSector}")]
        public async Task<ActionResult> Delete(int idSector)
        {
            await _sectorService.DeleteSector(idSector);
            return NoContent();
        }
    }
}
