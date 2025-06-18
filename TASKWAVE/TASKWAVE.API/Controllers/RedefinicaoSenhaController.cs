using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using TASKWAVE.DOMAIN.ENTITY;
using TASKWAVE.DOMAIN.Interfaces.Services;
using TASKWAVE.INFRA.Data;

namespace TASKWAVE.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RedefinicaoSenhaController : ControllerBase
    {        
        private readonly TaskWaveContext _context;
        private readonly IEmailService _emailService;

        public RedefinicaoSenhaController(TaskWaveContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        [HttpPost("Solicitar")]
        public async Task<IActionResult> Solicitar([FromBody] SolicitarRedefinicaoSenhaDTO model)
        {
            if (string.IsNullOrWhiteSpace(model.Email))
                return BadRequest("E-mail é obrigatório.");

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.EmailUsuario == model.Email);
            if (usuario == null)
                return NotFound("Usuário não encontrado.");

            usuario.TokenRedefinicaoSenha = Guid.NewGuid().ToString();
            usuario.DataExpiracaoToken = DateTime.UtcNow.AddHours(1);

            await _context.SaveChangesAsync();

            var link = $"https://localhost:7175/TrocarSenha/t={usuario.TokenRedefinicaoSenha}";
            var corpo = $"<p>Olá,</p><p>Você solicitou a redefinição de senha. Clique no link abaixo:</p><p><a href='{link}'>Redefinir Senha</a></p><p>Este link expira em 1 hora.</p>";

            await _emailService.EnviarAsync(usuario.EmailUsuario, "Redefinição de Senha - TaskWave", corpo);

            return Ok("E-mail de redefinição enviado.");
        }

        [HttpPut("Trocar")]
        public async Task<IActionResult> Trocar([FromBody] TrocaSenhaDTO model)
        {
            if (model.NovaSenha != model.ConfirmarSenha)
                return BadRequest("As senhas não coincidem.");

            if (!SenhaForte(model.NovaSenha))
                return BadRequest("A senha deve conter pelo menos 8 caracteres, incluindo letras e números.");

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.TokenRedefinicaoSenha == model.Token);
            if (usuario == null || usuario.DataExpiracaoToken < DateTime.UtcNow)
                return BadRequest("Token inválido ou expirado.");

            var hasher = new PasswordHasher<Usuario>();
            usuario.SenhaUsuario = hasher.HashPassword(usuario, model.NovaSenha);
            usuario.TokenRedefinicaoSenha = "";
            usuario.DataExpiracaoToken = null;

            await _context.SaveChangesAsync();

            return Ok("Senha redefinida com sucesso.");
        }

        private bool SenhaForte(string senha)
        {
            return senha.Length >= 8 && senha.Any(char.IsDigit) && senha.Any(char.IsLetter);
        }
    }
}
