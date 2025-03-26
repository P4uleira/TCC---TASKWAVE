namespace TASKWAVE.API.Responses
{
    public record MensagemResponse(string messageContent, DateTime messageSentDate, int taskId);
}
