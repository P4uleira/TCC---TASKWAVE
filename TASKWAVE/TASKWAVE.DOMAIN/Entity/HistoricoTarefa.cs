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

        public HistoricoTarefa(DateTime dataMudancaTarefa, SituacaoTarefaEnum situacaoAtualTarefa, SituacaoTarefaEnum? situacaoAnteriorTarefa, PrioridadeTarefaEnum prioridadeAtualTarefa, PrioridadeTarefaEnum? prioridadeAnteriorTarefa, int tarefaID)
        {
            DataMudancaTarefa = dataMudancaTarefa;
            SituacaoAtualTarefa = situacaoAtualTarefa;
            SituacaoAnteriorTarefa = situacaoAnteriorTarefa;
            PrioridadeAtualTarefa = prioridadeAtualTarefa;
            PrioridadeAnteriorTarefa = prioridadeAnteriorTarefa;
            TarefaID = tarefaID;
        }

        public HistoricoTarefa(DateTime dataMudancaTarefa, SituacaoTarefaEnum situacaoAtualTarefa, PrioridadeTarefaEnum prioridadeAtualTarefa, int tarefaID)
        {
            DataMudancaTarefa = dataMudancaTarefa;
            SituacaoAtualTarefa = situacaoAtualTarefa;
            PrioridadeAtualTarefa = prioridadeAtualTarefa;
            TarefaID = tarefaID;
        }
    }
}
