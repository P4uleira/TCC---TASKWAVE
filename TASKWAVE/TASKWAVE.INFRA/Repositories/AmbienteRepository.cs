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
        public async Task AddAsync(Ambiente environment)
        {
            await _context.Ambientes.AddAsync(environment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int idEnvironment)
        {
            var environment = await _context.Ambientes.FindAsync(idEnvironment);
            if (environment != null)
            {
                _context.Ambientes.Remove(environment);
                _context.SaveChanges();
            }
        }
        public async Task UpdateAsync(Ambiente environment)
        {
            _context.Ambientes.Update(environment);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Ambiente>> GetAllAsync()
        {
            return await _context.Ambientes.ToListAsync();
        }

        public async Task<Ambiente> GetByIdAsync(int idEnvironment)
        {
            return await _context.Ambientes.FindAsync(idEnvironment);
        }

    }
}

