using TASKWAVE.API.Infrastructure.Model;
using TASKWAVE.DOMAIN.Interfaces.Repositories;
using TASKWAVE.DOMAIN.Interfaces.Services;

namespace TASKWAVE.DOMAIN.Services
{
    public class HistoricoTarefaService : IHistoricoTarefaService
    {
        private readonly IHistoricoTarefaRepository _taskHistoryRepository;

        public HistoricoTarefaService(IHistoricoTarefaRepository taskHistoryRepository)
        {
            _taskHistoryRepository = taskHistoryRepository;
        }

        public async Task InsertTaskHistory(HistoricoTarefa taskHistory)
        {
            await _taskHistoryRepository.InsertTaskHistory(taskHistory);
        }

        public async Task UpdateTaskHistory(HistoricoTarefa taskUpdate)
        {
            await _taskHistoryRepository.UpdateTaskHistory(taskUpdate);
        }
    }
}
