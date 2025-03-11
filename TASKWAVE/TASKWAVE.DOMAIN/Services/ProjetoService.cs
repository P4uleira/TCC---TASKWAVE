using TASKWAVE.API.Infrastructure.Model;
using TASKWAVE.DOMAIN.Interfaces.Repositories;
using TASKWAVE.DOMAIN.Interfaces.Services;

namespace TASKWAVE.DOMAIN.Services
{
    public class ProjetoService : IProjetoService
    {
        private readonly IProjetoRepository _projetoRepository;
        private readonly IEquipeRepository _equipeRepository;

        public ProjetoService(IProjetoRepository projetoRepository)
        {
            _projetoRepository = projetoRepository;
        }

        public async Task CreateProjeto(Projeto projeto)
        {
            await _projetoRepository.AddAsync(projeto);
        }

        public async Task CreateProjectToEquip(Projeto projeto, int idEquipe)
        {
            await _projetoRepository.CreateProjectToEquip(projeto, idEquipe);
        }

        public async Task UpdateProjeto(Projeto projeto)
        {
            await _projetoRepository.UpdateAsync(projeto);
        }

        public async Task DeleteProjeto(int id)
        {
            await _projetoRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Projeto>> GetAllProjetos()
        {
            return await _projetoRepository.GetAllAsync();
        }

        public async Task<Projeto> GetProjetoById(int id)
        {
            return await _projetoRepository.GetByIdAsync(id);
        }
    }
}
