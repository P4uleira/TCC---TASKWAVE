namespace TASKWAVE.API.Requests
{
    public record MensagemRequest(string ConteudoMensagem, DateTime DataEnvioMensagem, int TarefaID);

}
