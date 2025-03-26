using TASKWAVE.DOMAIN.ENTITY;

namespace TASKWAVE.DOMAIN.Interfaces.Services
{
    public interface IAmbienteService
    {
        Task CreateEnvironment(Ambiente environment);
        Task UpdateEnvironment(Ambiente environment);
        Task DeleteEnvironment(int idEnvironment);
        Task<IEnumerable<Ambiente>> GetAllEnvironments();
        Task<Ambiente> GetEnvironmentById(int idEnvironment);
    }
}
