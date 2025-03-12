using TASKWAVE.API.Infrastructure.Model;
using TASKWAVE.DOMAIN.Interfaces.Repositories;
using TASKWAVE.DOMAIN.Interfaces.Services;

namespace TASKWAVE.DOMAIN.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task CreateUsuario(Usuario usuario)
        {
            await _usuarioRepository.AddAsync(usuario);
        }

        public async Task CreateUserToEquip(Usuario usuario, int idEquipe)
        {
            await _usuarioRepository.CreateUserToEquip(usuario, idEquipe);
        }
        public async Task UpdateUsuario(Usuario usuario)
        {
            await _usuarioRepository.UpdateAsync(usuario);
        }

        public async Task DeleteUsuario(int id)
        {
            await _usuarioRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuarios()
        {
            return await _usuarioRepository.GetAllAsync();
        }

        public async Task<Usuario> GetUsuarioById(int id)
        {
            return await _usuarioRepository.GetByIdAsync(id);
        }
    }
}
