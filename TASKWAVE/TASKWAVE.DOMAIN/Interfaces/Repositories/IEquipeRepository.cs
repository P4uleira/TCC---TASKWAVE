using TASKWAVE.API.Infrastructure.Model;

namespace TASKWAVE.DOMAIN.Interfaces.Repositories
{
    public interface IEquipeRepository : IBaseRepository<Equipe>
    {
        public Task InsertProjectToEquip(int idProjeto, int idEquipe);
        public Task InsertUserToEquip(int idUsuario, int idEquipe);
    }
}
