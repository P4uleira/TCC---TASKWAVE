using Microsoft.EntityFrameworkCore;
using TASKWAVE.API.Infrastructure.Data;
using TASKWAVE.API.Infrastructure.Model;
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

