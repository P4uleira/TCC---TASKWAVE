using TASKWAVE.DOMAIN.ENTITY;
using TASKWAVE.DOMAIN.Interfaces.Repositories;
using TASKWAVE.DOMAIN.Interfaces.Services;

namespace TASKWAVE.DOMAIN.Services
{
    public class AmbienteService : IAmbienteService
    {
        private readonly IAmbienteRepository _ambienteRepository;

        public AmbienteService(IAmbienteRepository ambienteRepository)
        {
            _ambienteRepository = ambienteRepository;
        }

        public async Task CreateAmbiente(Ambiente ambiente)
        {
            await _ambienteRepository.AddAsync(ambiente);
        }

        public async Task UpdateAmbiente(Ambiente ambiente)
        {
            await _ambienteRepository.UpdateAsync(ambiente);
        }

        public async Task DeleteAmbiente(int id)
        {
            await _ambienteRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Ambiente>> GetAllAmbientes()
        {
            return await _ambienteRepository.GetAllAsync();
        }

        public async Task<Ambiente> GetAmbienteById(int id)
        {
            return await _ambienteRepository.GetByIdAsync(id);
        }
    }
}
