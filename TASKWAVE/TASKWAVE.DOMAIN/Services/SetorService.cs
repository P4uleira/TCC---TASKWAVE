using TASKWAVE.DOMAIN.ENTITY;
using TASKWAVE.DOMAIN.Interfaces.Repositories;
using TASKWAVE.DOMAIN.Interfaces.Services;

namespace TASKWAVE.DOMAIN.Services
{
    public class SetorService : ISetorService
    {
        private readonly ISetorRepository _sectorRepository;

        public SetorService(ISetorRepository sectorRepository)
        {
            _sectorRepository = sectorRepository;
        }

        public async Task CreateSector(Setor sector)
        {
            await _sectorRepository.AddAsync(sector);
        }

        public async Task UpdateSector(Setor sector)
        {
            await _sectorRepository.UpdateAsync(sector);
        }

        public async Task DeleteSector(int idSector)
        {
            await _sectorRepository.DeleteAsync(idSector);
        }

        public async Task<IEnumerable<Setor>> GetAllSectors()
        {
            return await _sectorRepository.GetAllAsync();
        }

        public async Task<Setor> GetSectorById(int idSector)
        {
            return await _sectorRepository.GetByIdAsync(idSector);
        }
    }
}
