namespace TASKWAVE.DTO.Requests
{
    public record MensagemRequest(string messageContent, DateTime messageSentDate, int taskId);

}
