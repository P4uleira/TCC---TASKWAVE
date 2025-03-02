namespace TASKWAVE.API.Infrastructure.Model
{
    public class HistoricoTarefa
    {
        public int IdHistoricoTarefa { get; set; }
        public DateTime DataMudancaTarefa { get; set; }
        public string SituacaoAtualTarefa { get; set; }
        public string SituacaoAnteriorTarefa { get; set; }
        public string PrioridadeAtualTarefa { get; set; }
        public string PrioridadeAnteriorTarefa { get; set; }
        public int TarefaID { get; set; }
        public Tarefa Tarefa { get; set; }
        public HistoricoTarefa()
        {
        }

        public HistoricoTarefa(int idHistoricoTarefa, DateTime dataMudancaTarefa, string situacaoAtualTarefa, string situacaoAnteriorTarefa, string prioridadeAtualTarefa, string prioridadeAnteriorTarefa)
        {
            IdHistoricoTarefa = idHistoricoTarefa;
            DataMudancaTarefa = dataMudancaTarefa;
            SituacaoAtualTarefa = situacaoAtualTarefa;
            SituacaoAnteriorTarefa = situacaoAnteriorTarefa;
            PrioridadeAtualTarefa = prioridadeAtualTarefa;
            PrioridadeAnteriorTarefa = prioridadeAnteriorTarefa;
        }
    }
}
