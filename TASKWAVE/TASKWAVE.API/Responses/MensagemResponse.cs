namespace TASKWAVE.API.Responses
{
    public record MensagemResponse(string ConteudoMensagem, DateTime DataEnvioMensagem, int TarefaID);
}
