using TASKWAVE.DOMAIN.Enums;

namespace TASKWAVE.API.Requests
{
    public record TarefaRequest(string nomeTarefa, string? descricaoTarefa, SituacaoTarefaEnum situacaoTarefa, PrioridadeTarefaEnum prioridadeTarefa, DateTime dataCriacaoTarefa, int projetoId);
}
