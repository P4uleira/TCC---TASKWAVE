using Microsoft.EntityFrameworkCore;
using TASKWAVE.API.Infrastructure.Data;
using TASKWAVE.API.Infrastructure.Model;
using TASKWAVE.DOMAIN.Interfaces.Repositories;


namespace TASKWAVE.INFRA.Repositories
{
    public class SetorRepository : ISetorRepository
    {
        private readonly TaskWaveContext _context;

        public SetorRepository(TaskWaveContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Setor entity)
        {
            await _context.Setores.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ambiente = await _context.Setores.FindAsync(id);
            if (ambiente != null)
            {
                _context.Setores.Remove(ambiente);
                _context.SaveChanges();
            }
        }
        public async Task UpdateAsync(Setor entity)
        {
            _context.Setores.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Setor>> GetAllAsync()
        {
            return await _context.Setores.ToListAsync();
        }

        public async Task<Setor> GetByIdAsync(int id)
        {
            return await _context.Setores.FindAsync(id);
        }

    }
}

