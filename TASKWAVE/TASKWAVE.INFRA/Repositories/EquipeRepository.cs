using Microsoft.EntityFrameworkCore;
using TASKWAVE.INFRA.Data;
using TASKWAVE.DOMAIN.ENTITY;
using TASKWAVE.DOMAIN.Interfaces.Repositories;


namespace TASKWAVE.INFRA.Repositories
{
    public class EquipeRepository : IEquipeRepository
    {
        private readonly TaskWaveContext _context;

        public EquipeRepository(TaskWaveContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Equipe entity)
        {
            await _context.Equipes.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task InsertProjectToEquip(int idProjeto, int idEquipe)
        {
            var equipe = await _context.Equipes
            .Include(e => e.Projetos) // Garante que a coleção Projetos seja carregada
            .FirstOrDefaultAsync(e => e.IdEquipe == idEquipe);

            var projeto = await _context.Projetos.FindAsync(idProjeto);

            if (equipe == null || projeto == null)
            {
                throw new Exception("Equipe ou Projeto não encontrados.");
            }

            // Verifica se já existe essa relação para evitar duplicatas
            if (!equipe.Projetos.Any(p => p.IdProjeto == idProjeto))
            {
                equipe.Projetos.Add(projeto); // Adiciona o projeto à equipe
                await _context.SaveChangesAsync(); // Salva as alterações no banco
            }
        }

        public async Task InsertUserToEquip(int idUsuario, int idEquipe)
        {
            var equipe = await _context.Equipes
            .Include(e => e.Usuarios) // Garante que a coleção Projetos seja carregada
            .FirstOrDefaultAsync(e => e.IdEquipe == idEquipe);

            var usuario = await _context.Usuarios.FindAsync(idUsuario);

            if (equipe == null || usuario == null)
            {
                throw new Exception("Equipe ou Usuario não encontrados.");
            }

            // Verifica se já existe essa relação para evitar duplicatas
            if (!equipe.Usuarios.Any(p => p.IdUsuario == idUsuario))
            {
                equipe.Usuarios.Add(usuario); // Adiciona o usuario à equipe
                await _context.SaveChangesAsync(); // Salva as alterações no banco
            }
        }

        public async Task DeleteAsync(int id)
        {
            var equipe = await _context.Equipes.FindAsync(id);
            if (equipe != null)
            {
                _context.Equipes.Remove(equipe);
                _context.SaveChanges();
            }
        }
        public async Task UpdateAsync(Equipe entity)
        {
            _context.Equipes.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Equipe>> GetAllAsync()
        {
            return await _context.Equipes.ToListAsync();
        }

        public async Task<Equipe> GetByIdAsync(int id)
        {
            return await _context.Equipes.FindAsync(id);
        }

    }
}

