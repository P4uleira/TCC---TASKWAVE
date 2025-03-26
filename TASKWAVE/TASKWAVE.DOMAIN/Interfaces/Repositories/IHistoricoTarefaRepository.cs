using TASKWAVE.DOMAIN.ENTITY;

namespace TASKWAVE.DOMAIN.Interfaces.Repositories
{
    public interface IHistoricoTarefaRepository
    {
        public Task InsertTaskHistory(HistoricoTarefa taskHistory);
        public Task UpdateTaskHistory(HistoricoTarefa taskToUpdate);
    }
}
