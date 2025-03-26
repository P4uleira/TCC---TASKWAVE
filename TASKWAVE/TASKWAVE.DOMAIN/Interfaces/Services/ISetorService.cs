using TASKWAVE.DOMAIN.ENTITY;

namespace TASKWAVE.DOMAIN.Interfaces.Services
{
    public interface ISetorService
    {
        Task CreateSector(Setor sector);
        Task UpdateSector(Setor sector);
        Task DeleteSector(int idSector);
        Task<IEnumerable<Setor>> GetAllSectors();
        Task<Setor> GetSectorById(int idSector);

    }
}
