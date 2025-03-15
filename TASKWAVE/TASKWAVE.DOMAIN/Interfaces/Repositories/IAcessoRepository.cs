using TASKWAVE.API.Infrastructure.Model;

namespace TASKWAVE.DOMAIN.Interfaces.Repositories
{
    public interface IAcessoRepository : IBaseRepository<Acesso>
    {
        public Task InsertAccessToUser(int idAccess, int idUser);
    }
}
