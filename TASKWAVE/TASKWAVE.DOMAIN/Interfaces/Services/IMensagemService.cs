using TASKWAVE.API.Infrastructure.Model;

namespace TASKWAVE.DOMAIN.Interfaces.Services
{
    public interface IMensagemService
    {
        Task CreateMessage(Mensagem Message);
        Task UpdateMessage(Mensagem Message);
        Task DeleteMessage(int idMessage);
        Task<IEnumerable<Mensagem>> GetAllMessages();
        Task<Mensagem> GetMessageById(int idMessage);
    }
}
