﻿using TASKWAVE.API.Infrastructure.Model;
using TASKWAVE.DOMAIN.Interfaces.Repositories;
using TASKWAVE.DOMAIN.Interfaces.Services;

namespace TASKWAVE.DOMAIN.Services
{
    public class EquipeService : IEquipeService
    {
        private readonly IEquipeRepository _equipeRepository;

        public EquipeService(IEquipeRepository equipeRepository)
        {
            _equipeRepository = equipeRepository;
        }

        public async Task CreateEquipe(Equipe equipe)
        {
            await _equipeRepository.AddAsync(equipe);
        }

        public async Task UpdateEquipe(Equipe equipe)
        {
            await _equipeRepository.UpdateAsync(equipe);
        }

        public async Task DeleteEquipe(int id)
        {
            await _equipeRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Equipe>> GetAllEquipes()
        {
            return await _equipeRepository.GetAllAsync();
        }

        public async Task<Equipe> GetEquipeById(int id)
        {
            return await _equipeRepository.GetByIdAsync(id);
        }
    }
}
