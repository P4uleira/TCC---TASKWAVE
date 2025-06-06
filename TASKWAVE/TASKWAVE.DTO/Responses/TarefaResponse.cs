using TASKWAVE.DOMAIN.Enums;

namespace TASKWAVE.DTO.Responses
{
    public record TarefaResponse(string taskName, string taskDescription, SituacaoTarefaEnum taskStatus, PrioridadeTarefaEnum taskPriority, DateTime taskCreationDate, int projectId);
}
