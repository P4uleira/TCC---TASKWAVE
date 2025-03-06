using TASKWAVE.API.Infrastructure.Model;

namespace TASKWAVE.DOMAIN.Interfaces.Services
{
    public interface IAmbienteService
    {
        Task CreateAmbiente(Ambiente ambiente);
        Task UpdateAmbiente(Ambiente ambiente);
        Task DeleteAmbiente(int id);
        Task<IEnumerable<Ambiente>> GetAllAmbientes();
        Task<Ambiente> GetAmbienteById(int id);
    }
}
