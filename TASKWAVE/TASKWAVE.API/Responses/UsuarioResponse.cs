namespace TASKWAVE.API.Responses
{
    public record UsuarioResponse(string userName, string userEmail, string userPassword, DateTime userCreationDate);
}
