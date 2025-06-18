using TASKWAVE.DOMAIN.ENTITY;

namespace TASKWAVE.DOMAIN.Interfaces.Services
{
    public interface IEmailService
    {
        Task EnviarAsync(string para, string assunto, string corpoHtml);
    }
}
