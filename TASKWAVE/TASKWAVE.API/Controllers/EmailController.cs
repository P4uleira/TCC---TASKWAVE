using Microsoft.AspNetCore.Mvc;
using TASKWAVE.API.Responses;
using TASKWAVE.DOMAIN.Interfaces.Services;
using TASKWAVE.DOMAIN.Services;

namespace TASKWAVE.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("enviar")]
        public async Task<IActionResult> Enviar([FromBody] EmailResponse dto)
        {
            await _emailService.EnviarAsync(dto.mailTO, dto.mailSubject, dto.mailBody);
            return Ok("Email enviado com sucesso!");
        }
    }
}
