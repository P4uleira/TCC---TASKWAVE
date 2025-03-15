using TASKWAVE.DOMAIN.Enums;

namespace TASKWAVE.API.Infrastructure.Model
{
    public class Tarefa
    {
        public int IdTarefa { get; set; }
        public string NomeTarefa { get; set; }
        public string? DescricaoTarefa { get; set; }
        public SituacaoTarefaEnum SituacaoTarefa { get; set; }
        public PrioridadeTarefaEnum PrioridadeTarefa { get; set; }
        public DateTime DataCriacaoTarefa { get; set; }
        public DateTime? DataPrevistaTarefa { get; set; }
        public DateTime? DataFinalTarefa { get; set; }
        public int ProjetoId { get; set; }
        public Projeto Projeto { get; set; }
        public ICollection<Mensagem> Mensagems { get; set; }
        public ICollection<HistoricoTarefa> HistoricoTarefas { get; set; }

        public Tarefa()
        {
        }

        public Tarefa(string nomeTarefa, string? descricaoTarefa, SituacaoTarefaEnum situacaoTarefa, PrioridadeTarefaEnum prioridadeTarefa, DateTime dataCriacaoTarefa, int projetoId)
        {
            NomeTarefa = nomeTarefa;
            DescricaoTarefa = descricaoTarefa;
            SituacaoTarefa = situacaoTarefa;
            PrioridadeTarefa = prioridadeTarefa;
            DataCriacaoTarefa = dataCriacaoTarefa;
            ProjetoId = projetoId;
        }
    }
}
