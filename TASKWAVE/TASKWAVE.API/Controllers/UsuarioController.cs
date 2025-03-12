using Azure;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using TASKWAVE.API.Infrastructure.Model;
using TASKWAVE.API.Requests;
using TASKWAVE.API.Responses;
using TASKWAVE.DOMAIN.Interfaces.Services;

namespace TASKWAVE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioResponse>>> GetAll()
        {
            var usuarios = await _usuarioService.GetAllUsuarios();
            var response = usuarios.Select(usuario => new UsuarioResponse(usuario.NomeUsuario, usuario.EmailUsuario, usuario.SenhaUsuario, usuario.DataCriacaoUsuario));
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioResponse>> GetById(int id)
        {
            var usuario = await _usuarioService.GetUsuarioById(id);
            if (usuario == null)
                return NotFound();
            return Ok(new UsuarioResponse(usuario.NomeUsuario, usuario.EmailUsuario, usuario.SenhaUsuario, usuario.DataCriacaoUsuario));
        }

        [HttpPost]
        public async Task<ActionResult> Create(UsuarioRequest request)
        {
            var usuario = new Usuario(request.nomeUsuario, request.emailUsuario, request.senhaUsuario, request.dataCriacaoUsuario);
            await _usuarioService.CreateUsuario(usuario);
            return CreatedAtAction(nameof(GetById), new { id = usuario.IdUsuario }, null);
        }

        [HttpPost("AddUserInEquip")]
        public async Task CreateUserToEquip(UsuarioRequest usuario, int idEquipe)
        {
            var newUsuario = new Usuario(usuario.nomeUsuario, usuario.emailUsuario, usuario.senhaUsuario, usuario.dataCriacaoUsuario);
            await _usuarioService.CreateUserToEquip(newUsuario, idEquipe);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UsuarioRequest request)
        {

            var usuarioExistente = await _usuarioService.GetUsuarioById(id);
            if (usuarioExistente == null)
            {
                return NotFound();
            }

            usuarioExistente.NomeUsuario = request.nomeUsuario;
            usuarioExistente.EmailUsuario = request.emailUsuario;
            usuarioExistente.SenhaUsuario = request.senhaUsuario;

            await _usuarioService.UpdateUsuario(usuarioExistente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _usuarioService.DeleteUsuario(id);
            return NoContent();
        }
    }
}
