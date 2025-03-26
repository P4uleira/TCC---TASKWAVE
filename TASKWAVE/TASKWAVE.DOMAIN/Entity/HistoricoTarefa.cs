using TASKWAVE.DOMAIN.Enums;

namespace TASKWAVE.DOMAIN.ENTITY
{
    public class HistoricoTarefa
    {
        public int IdHistoricoTarefa { get; set; }
        public DateTime DataMudancaTarefa { get; set; }
        public SituacaoTarefaEnum SituacaoAtualTarefa { get; set; }
        public SituacaoTarefaEnum? SituacaoAnteriorTarefa { get; set; }
        public PrioridadeTarefaEnum PrioridadeAtualTarefa { get; set; }
        public PrioridadeTarefaEnum? PrioridadeAnteriorTarefa { get; set; }
        public int TarefaID { get; set; }
        public Tarefa Tarefa { get; set; }
        public HistoricoTarefa()
        {
        }

        public HistoricoTarefa(DateTime taskChangeDate, SituacaoTarefaEnum currentTaskStatus, SituacaoTarefaEnum? previousTaskStatus, PrioridadeTarefaEnum currentTaskPriority, PrioridadeTarefaEnum? previousTaskPriority, int taskId)
        {
            DataMudancaTarefa = taskChangeDate;
            SituacaoAtualTarefa = currentTaskStatus;
            SituacaoAnteriorTarefa = previousTaskStatus;
            PrioridadeAtualTarefa = currentTaskPriority;
            PrioridadeAnteriorTarefa = previousTaskPriority;
            TarefaID = taskId;
        }

        public HistoricoTarefa(DateTime taskChangeDate, SituacaoTarefaEnum currentTaskStatus, PrioridadeTarefaEnum currentTaskPriority, int taskId)
        {
            DataMudancaTarefa = taskChangeDate;
            SituacaoAtualTarefa = currentTaskStatus;
            PrioridadeAtualTarefa = currentTaskPriority;
            TarefaID = taskId;
        }
    }
}
