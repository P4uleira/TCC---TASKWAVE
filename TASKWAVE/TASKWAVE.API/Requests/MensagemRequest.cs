namespace TASKWAVE.API.Requests
{
    public record MensagemRequest(string messageContent, DateTime messageSentDate, int taskId);

}
