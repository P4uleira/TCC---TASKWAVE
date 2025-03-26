using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using TASKWAVE.INFRA.Data;
using TASKWAVE.DOMAIN.ENTITY;
using TASKWAVE.DOMAIN.Enums;
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
                SituacaoTarefaEnum oldSituation = taskHistoryToUpdate.SituacaoAtualTarefa;
                PrioridadeTarefaEnum oldPriorit = taskHistoryToUpdate.PrioridadeAtualTarefa;

                bool updated = false;

                if (taskHistoryToUpdate.SituacaoAtualTarefa != taskToUpdate.SituacaoAtualTarefa)
                {
                    taskHistoryToUpdate.SituacaoAnteriorTarefa = oldSituation;
                    taskHistoryToUpdate.SituacaoAtualTarefa = taskToUpdate.SituacaoAtualTarefa;
                    taskHistoryToUpdate.DataMudancaTarefa = DateTime.Now;
                    updated = true;
                }

                if (taskHistoryToUpdate.PrioridadeAtualTarefa != taskToUpdate.PrioridadeAtualTarefa)
                {
                    taskHistoryToUpdate.PrioridadeAnteriorTarefa = oldPriorit;
                    taskHistoryToUpdate.PrioridadeAtualTarefa = taskToUpdate.PrioridadeAtualTarefa;
                    taskHistoryToUpdate.DataMudancaTarefa = DateTime.Now;
                    updated = true;
                }

                if (updated)
                {
                    _context.HistoricoTarefas.Update(taskHistoryToUpdate);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}

