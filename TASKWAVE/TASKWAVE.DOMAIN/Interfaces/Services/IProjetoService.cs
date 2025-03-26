using TASKWAVE.DOMAIN.ENTITY;

namespace TASKWAVE.DOMAIN.Interfaces.Services
{
    public interface IProjetoService
    {
        Task CreateProject(Projeto project);
        Task UpdateProject(Projeto project);
        Task DeleteProject(int idProject);
        Task<IEnumerable<Projeto>> GetAllProjects();
        Task<Projeto> GetProjectById(int idProject);
        Task CreateProjectToTeam(Projeto project, int teamId);

    }
}
