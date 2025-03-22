using TASKWAVE.API.Infrastructure.Model;

namespace TASKWAVE.DOMAIN.Interfaces.Services
{
    public interface IHistoricoTarefaService
    {
        public Task InsertTaskHistory(HistoricoTarefa taskHistory);
        public Task UpdateTaskHistory(HistoricoTarefa taskToUpdate);
    }
}
