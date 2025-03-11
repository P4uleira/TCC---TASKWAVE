using Microsoft.EntityFrameworkCore;
using TASKWAVE.API.Infrastructure.Data;
using TASKWAVE.API.Infrastructure.Model;
using TASKWAVE.DOMAIN.Interfaces.Repositories;


namespace TASKWAVE.INFRA.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly TaskWaveContext _context;

        public ProjetoRepository(TaskWaveContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Projeto entity)
        {
            await _context.Projetos.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task CreateProjectToEquip(Projeto entity, int idEquipe)
        {
            await _context.Projetos.AddAsync(entity);
            await _context.SaveChangesAsync();

            var equipes = await _context.Equipes
            .Include(equipe => equipe.Projetos)
            .FirstOrDefaultAsync(equipe => equipe.IdEquipe == idEquipe);

            var projeto = await _context.Projetos.FindAsync(entity.IdProjeto);

            if (!equipes.Projetos.Contains(projeto))
            {
                equipes.Projetos.Add(projeto);
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var projeto = await _context.Projetos.FindAsync(id);
            if (projeto != null)
            {
                _context.Projetos.Remove(projeto);
                _context.SaveChanges();
            }
        }
        public async Task UpdateAsync(Projeto entity)
        {
            _context.Projetos.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Projeto>> GetAllAsync()
        {
            return await _context.Projetos.ToListAsync();
        }

        public async Task<Projeto> GetByIdAsync(int id)
        {
            return await _context.Projetos.FindAsync(id);
        }
    }
}

