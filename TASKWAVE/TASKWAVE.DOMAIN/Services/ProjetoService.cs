using TASKWAVE.DOMAIN.ENTITY;
using TASKWAVE.DOMAIN.Interfaces.Repositories;
using TASKWAVE.DOMAIN.Interfaces.Services;

namespace TASKWAVE.DOMAIN.Services
{
    public class ProjetoService : IProjetoService
    {
        private readonly IProjetoRepository _projectRepository;

        public ProjetoService(IProjetoRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task CreateProject(Projeto project)
        {
            await _projectRepository.AddAsync(project);
        }

        public async Task CreateProjectToTeam(Projeto project, int teamId)
        {
            await _projectRepository.CreateProjectToTeam(project, teamId);
        }

        public async Task UpdateProject(Projeto project)
        {
            await _projectRepository.UpdateAsync(project);
        }

        public async Task DeleteProject(int idProject)
        {
            await _projectRepository.DeleteAsync(idProject);
        }

        public async Task<IEnumerable<Projeto>> GetAllProjects()
        {
            return await _projectRepository.GetAllAsync();
        }

        public async Task<Projeto> GetProjectById(int idProject)
        {
            return await _projectRepository.GetByIdAsync(idProject);
        }
    }
}
