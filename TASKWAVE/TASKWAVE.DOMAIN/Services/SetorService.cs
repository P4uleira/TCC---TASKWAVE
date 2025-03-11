using TASKWAVE.API.Infrastructure.Model;
using TASKWAVE.DOMAIN.Interfaces.Repositories;
using TASKWAVE.DOMAIN.Interfaces.Services;

namespace TASKWAVE.DOMAIN.Services
{
    public class SetorService : ISetorService
    {
        private readonly ISetorRepository _setorRepository;

        public SetorService(ISetorRepository setorRepository)
        {
            _setorRepository = setorRepository;
        }

        public async Task CreateSetor(Setor setor)
        {
            await _setorRepository.AddAsync(setor);
        }

        public async Task UpdateSetor(Setor setor)
        {
            await _setorRepository.UpdateAsync(setor);
        }

        public async Task DeleteSetor(int id)
        {
            await _setorRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Setor>> GetAllSetores()
        {
            return await _setorRepository.GetAllAsync();
        }

        public async Task<Setor> GetSetorById(int id)
        {
            return await _setorRepository.GetByIdAsync(id);
        }
    }
}
