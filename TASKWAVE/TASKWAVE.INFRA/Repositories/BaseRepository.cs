﻿using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TASKWAVE.INFRA.Data;
using TASKWAVE.DOMAIN.Interfaces.Repositories;

namespace TASKWAVE.INFRA.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly TaskWaveContext _context;

        public BaseRepository(TaskWaveContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
    }
}