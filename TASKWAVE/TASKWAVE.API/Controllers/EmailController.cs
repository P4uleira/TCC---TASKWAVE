using Microsoft.AspNetCore.Mvc;
using TASKWAVE.API.Responses;
using TASKWAVE.DOMAIN.Services;

namespace TASKWAVE.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly EmailService _emailService;

        public EmailController()
        {
            _emailService = new EmailService(); // Para TCC, não precisa injeção de dependência
        }

        [HttpPost("enviar")]
        public async Task<IActionResult> Enviar([FromBody] EmailResponse dto)
        {
            await _emailService.EnviarEmailAsync(dto.mailTO, dto.mailSubject, dto.mailBody);
            return Ok("Email enviado com sucesso!");
        }
    }
}
