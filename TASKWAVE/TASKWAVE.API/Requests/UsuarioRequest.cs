namespace TASKWAVE.API.Requests
{
    public record UsuarioRequest(string nomeUsuario, string emailUsuario, string senhaUsuario, DateTime dataCriacaoUsuario);
}
