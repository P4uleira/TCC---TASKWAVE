namespace TASKWAVE.DTO.Responses
{
    public record MensagemResponse(string messageContent, DateTime messageSentDate, int taskId);
}
