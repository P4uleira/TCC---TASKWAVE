using TASKWAVE.DOMAIN.Enums;

namespace TASKWAVE.API.Responses
{
    public record TarefaResponse(string nomeTarefa, string descricaoTarefa, SituacaoTarefaEnum situacaoTarefa, PrioridadeTarefaEnum prioridadeTarefa, DateTime dataCriacaoTarefa, int projetoId);
}
