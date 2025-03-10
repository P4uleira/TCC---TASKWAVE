﻿using TASKWAVE.API.Infrastructure.Model;

namespace TASKWAVE.DOMAIN.Interfaces.Services
{
    public interface IEquipeService
    {
        Task CreateEquipe(Equipe equipe);
        Task UpdateEquipe(Equipe equipe);
        Task DeleteEquipe(int id);
        Task<IEnumerable<Equipe>> GetAllEquipes();
        Task<Equipe> GetEquipeById(int id);
    }
}
