namespace TASKWAVE.DTO.Responses
{
    public record UsuarioResponse(int userID, string userName, string userEmail, string userPassword, DateTime userCreationDate);
}
