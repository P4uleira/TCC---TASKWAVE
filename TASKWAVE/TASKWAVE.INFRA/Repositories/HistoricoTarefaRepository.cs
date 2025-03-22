using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using TASKWAVE.API.Infrastructure.Data;
using TASKWAVE.API.Infrastructure.Model;
using TASKWAVE.DOMAIN.Interfaces.Repositories;


namespace TASKWAVE.INFRA.Repositories
{
    public class HistoricoTarefaRepository : IHistoricoTarefaRepository
    {
        private readonly TaskWaveContext _context;

        public HistoricoTarefaRepository(TaskWaveContext context)
        {
            _context = context;
        }

        public async Task InsertTaskHistory(HistoricoTarefa taskHistory)
        {
            _context.HistoricoTarefas.Add(taskHistory);
            _context.SaveChanges();
        }

        public async Task UpdateTaskHistory(HistoricoTarefa taskToUpdate)
        {
            var task = await _context.Tarefas.FindAsync(taskToUpdate.TarefaID);

            var taskHistoryToUpdate = await _context.HistoricoTarefas
                .Where(h => h.TarefaID == taskToUpdate.TarefaID)
                .OrderByDescending(h => h.DataMudancaTarefa)
                .FirstOrDefaultAsync();

            if (taskHistoryToUpdate != null)
            {
                var oldSituation = taskHistoryToUpdate.SituacaoAtualTarefa;
                var oldPriorit = taskHistoryToUpdate.PrioridadeAtualTarefa;

                if(taskHistoryToUpdate.SituacaoAtualTarefa != oldSituation )
                {
                    taskHistoryToUpdate.SituacaoAnteriorTarefa = oldSituation;
                    taskHistoryToUpdate.SituacaoAtualTarefa = taskToUpdate.SituacaoAtualTarefa;
                    taskHistoryToUpdate.DataMudancaTarefa = DateTime.Now;
                    _context.HistoricoTarefas.Add(taskHistoryToUpdate);
                }

                if(taskHistoryToUpdate.PrioridadeAtualTarefa != oldPriorit)
                {
                    taskHistoryToUpdate.PrioridadeAnteriorTarefa = oldPriorit;
                    taskHistoryToUpdate.PrioridadeAtualTarefa = taskToUpdate.PrioridadeAtualTarefa;
                    taskHistoryToUpdate.DataMudancaTarefa = DateTime.Now;
                    _context.HistoricoTarefas.Add(taskHistoryToUpdate);
                }

                _context.SaveChanges();
            }
        }
    }
}

