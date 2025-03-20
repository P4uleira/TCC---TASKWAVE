using Microsoft.EntityFrameworkCore;
using TASKWAVE.API.Infrastructure.Data;
using TASKWAVE.API.Infrastructure.Model;
using TASKWAVE.DOMAIN.Interfaces.Repositories;


namespace TASKWAVE.INFRA.Repositories
{
    public class MensagemRepository : IMensagemRepository
    {
        private readonly TaskWaveContext _context;

        public MensagemRepository(TaskWaveContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Mensagem message)
        {
            await _context.Mensagens.AddAsync(message);
            await _context.SaveChangesAsync();
        }
        
        public async Task DeleteAsync(int idMessage)
        {
            var message = await _context.Mensagens.FindAsync(idMessage);
            if (message != null)
            {
                _context.Mensagens.Remove(message);
                _context.SaveChanges();
            }
        }
        public async Task UpdateAsync(Mensagem message)
        {
            _context.Mensagens.Update(message);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Mensagem>> GetAllAsync()
        {
            return await _context.Mensagens.ToListAsync();
        }

        public async Task<Mensagem> GetByIdAsync(int idMessage)
        {
            return await _context.Mensagens.FindAsync(idMessage);
        }

    }
}

