using TASKWAVE.DOMAIN.Enums;

namespace TASKWAVE.API.Requests
{
    public record TarefaRequest(string taskName, string? taskDescription, SituacaoTarefaEnum taskStatus, PrioridadeTarefaEnum taskPriority, DateTime taskCreationDate, int projectId);
}
