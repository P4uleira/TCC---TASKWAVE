using TASKWAVE.API.Infrastructure.Model;
using TASKWAVE.DOMAIN.Interfaces.Repositories;
using TASKWAVE.DOMAIN.Interfaces.Services;

namespace TASKWAVE.DOMAIN.Services
{
    public class AcessoService : IAcessoService
    {
        private readonly IAcessoRepository _acessoRepository;

        public AcessoService(IAcessoRepository acessoRepository)
        {
            _acessoRepository = acessoRepository;
        }

        public async Task CreateAccess(Acesso Access)
        {
            await _acessoRepository.AddAsync(Access);
        }

        public async Task InsertAccessToUser(int idAcess, int idUser)
        {
            await _acessoRepository.InsertAccessToUser(idAcess, idUser);
        }
        public async Task UpdateAccess(Acesso Access)
        {
            await _acessoRepository.UpdateAsync(Access);
        }

        public async Task DeleteAccess(int id)
        {
            await _acessoRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Acesso>> GetAllAccesses()
        {
            return await _acessoRepository.GetAllAsync();
        }

        public async Task<Acesso> GetAccessById(int id)
        {
            return await _acessoRepository.GetByIdAsync(id);
        }
    }
}
