using TASKWAVE.DOMAIN.ENTITY;
using TASKWAVE.DOMAIN.Interfaces.Repositories;
using TASKWAVE.DOMAIN.Interfaces.Services;

namespace TASKWAVE.DOMAIN.Services
{
    public class AmbienteService : IAmbienteService
    {
        private readonly IAmbienteRepository _environmentRepository;

        public AmbienteService(IAmbienteRepository environmentRepository)
        {
            _environmentRepository = environmentRepository;
        }

        public async Task CreateEnvironment(Ambiente environment)
        {
            await _environmentRepository.AddAsync(environment);
        }

        public async Task UpdateEnvironment(Ambiente environment)
        {
            await _environmentRepository.UpdateAsync(environment);
        }

        public async Task DeleteEnvironment(int idEnvironment)
        {
            await _environmentRepository.DeleteAsync(idEnvironment);
        }

        public async Task<IEnumerable<Ambiente>> GetAllEnvironments()
        {
            return await _environmentRepository.GetAllAsync();
        }

        public async Task<Ambiente> GetEnvironmentById(int idEnvironment)
        {
            return await _environmentRepository.GetByIdAsync(idEnvironment);
        }
    }
}
