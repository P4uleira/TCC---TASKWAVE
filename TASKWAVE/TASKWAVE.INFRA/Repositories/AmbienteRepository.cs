using Microsoft.EntityFrameworkCore;
using TASKWAVE.INFRA.Data;
using TASKWAVE.DOMAIN.ENTITY;
using TASKWAVE.DOMAIN.Interfaces.Repositories;


namespace TASKWAVE.INFRA.Repositories
{
    public class AmbienteRepository : IAmbienteRepository
    {
        private readonly TaskWaveContext _context;

        public AmbienteRepository(TaskWaveContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Ambiente entity)
        {
            await _context.Ambientes.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ambiente = await _context.Ambientes.FindAsync(id);
            if (ambiente != null)
            {
                _context.Ambientes.Remove(ambiente);
                _context.SaveChanges();
            }
        }
        public async Task UpdateAsync(Ambiente entity)
        {
            _context.Ambientes.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Ambiente>> GetAllAsync()
        {
            return await _context.Ambientes.ToListAsync();
        }

        public async Task<Ambiente> GetByIdAsync(int id)
        {
            return await _context.Ambientes.FindAsync(id);
        }

    }
}

