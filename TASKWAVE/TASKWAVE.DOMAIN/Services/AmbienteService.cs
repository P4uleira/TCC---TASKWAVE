using TASKWAVE.API.Infrastructure.Model;
using TASKWAVE.DOMAIN.Interfaces.Repositories;
using TASKWAVE.DOMAIN.Interfaces.Services;

namespace TASKWAVE.DOMAIN.Services
{
    public class AmbienteService : IAmbienteService
    {
        public readonly IAmbienteRepository _ambienteRepository;

        public AmbienteService(IAmbienteRepository ambienteRepository)
        {
            _ambienteRepository = ambienteRepository;
        }

        public void CriarAmbiente() 
        {
            Ambiente ambienteTeste = new Ambiente();
            _ambienteRepository.AddAsync(ambienteTeste);
        }
    }
}
