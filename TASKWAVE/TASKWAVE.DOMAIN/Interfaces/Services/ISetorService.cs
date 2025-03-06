using TASKWAVE.API.Infrastructure.Model;

namespace TASKWAVE.DOMAIN.Interfaces.Services
{
    public interface ISetorService
    {
        Task CreateSetor(Setor setor);
        Task UpdateSetor(Setor setor);
        Task DeleteSetor(int id);
        Task<IEnumerable<Setor>> GetAllSetores();
        Task<Setor> GetSetorById(int id);
    }
}
