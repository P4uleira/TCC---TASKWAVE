namespace TASKWAVE.DTO.Requests
{
    public record UsuarioRequest(string userName, string userEmail, string userPassword, DateTime userCreationDate);
}
