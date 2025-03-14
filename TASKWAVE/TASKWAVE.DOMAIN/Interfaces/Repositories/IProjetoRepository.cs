﻿using TASKWAVE.API.Infrastructure.Model;

namespace TASKWAVE.DOMAIN.Interfaces.Repositories
{
    public interface IProjetoRepository : IBaseRepository<Projeto>
    {
        public Task CreateProjectToEquip(Projeto projeto, int idEquipe);
    }
}
