using TASKWAVE.DOMAIN.Enums;

namespace TASKWAVE.DTO.Requests
{
    public record TarefaRequest(string taskName, string? taskDescription, SituacaoTarefaEnum taskStatus, PrioridadeTarefaEnum taskPriority, DateTime taskCreationDate, int projectId);
}
