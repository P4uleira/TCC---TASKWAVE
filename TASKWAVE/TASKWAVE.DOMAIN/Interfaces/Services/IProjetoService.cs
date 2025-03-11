using TASKWAVE.API.Infrastructure.Model;

namespace TASKWAVE.DOMAIN.Interfaces.Services
{
    public interface IProjetoService
    {
        Task CreateProjeto(Projeto projeto);
        Task UpdateProjeto(Projeto projeto);
        Task DeleteProjeto(int id);
        Task<IEnumerable<Projeto>> GetAllProjetos();
        Task<Projeto> GetProjetoById(int id);

        Task CreateProjectToEquip(Projeto projeto, int idEquipe);
    }
}
