using TASKWAVE.API.Infrastructure.Model;

namespace TASKWAVE.DOMAIN.Interfaces.Services
{
    public interface IHistoricoTarefaService
    {
        Task InsertTaskHistory(HistoricoTarefa taskHistory, int idTask);
    }
}
