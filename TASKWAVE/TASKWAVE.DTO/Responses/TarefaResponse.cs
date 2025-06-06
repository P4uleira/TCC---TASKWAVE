using TASKWAVE.DOMAIN.Enums;

namespace TASKWAVE.API.Responses
{
    public record TarefaResponse(string taskName, string taskDescription, SituacaoTarefaEnum taskStatus, PrioridadeTarefaEnum taskPriority, DateTime taskCreationDate, int projectId);
}
