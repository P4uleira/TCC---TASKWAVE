using TASKWAVE.API.Infrastructure.Model;

namespace TASKWAVE.DOMAIN.Interfaces.Repositories
{
    public interface IHistoricoTarefaRepository
    {
        public Task InsertTaskHistory(HistoricoTarefa taskHistory, int idTask);
        public Task UpdateTaskHistory(Tarefa taskToUpdate);
    }
}
