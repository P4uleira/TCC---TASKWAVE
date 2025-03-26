using Microsoft.EntityFrameworkCore;
using TASKWAVE.INFRA.Data;
using TASKWAVE.DOMAIN.ENTITY;
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
        public async Task AddAsync(Setor sector)
        {
            await _context.Setores.AddAsync(sector);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int idSector)
        {
            var sector = await _context.Setores.FindAsync(idSector);
            if (sector != null)
            {
                _context.Setores.Remove(sector);
                _context.SaveChanges();
            }
        }
        public async Task UpdateAsync(Setor sector)
        {
            _context.Setores.Update(sector);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Setor>> GetAllAsync()
        {
            return await _context.Setores.ToListAsync();
        }

        public async Task<Setor> GetByIdAsync(int idSector)
        {
            return await _context.Setores.FindAsync(idSector);
        }

    }
}

