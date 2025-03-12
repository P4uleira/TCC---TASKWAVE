namespace TASKWAVE.API.Responses
{
    public record UsuarioResponse(string nomeUsuario, string emailUsuario, string senhaUsuario, DateTime dataCriacaoUsuario);
}
