namespace TASKWAVE.API.Requests
{
    public record UsuarioRequest(string userName, string userEmail, string userPassword, DateTime userCreationDate);
}
