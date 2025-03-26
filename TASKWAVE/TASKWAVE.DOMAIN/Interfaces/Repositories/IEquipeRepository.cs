using TASKWAVE.DOMAIN.ENTITY;

namespace TASKWAVE.DOMAIN.Interfaces.Repositories
{
    public interface IEquipeRepository : IBaseRepository<Equipe>
    {
        public Task InsertProjectToEquip(int idProjeto, int idEquipe);
        public Task InsertUserToEquip(int idUsuario, int idEquipe);
    }
}
