﻿using TASKWAVE.DOMAIN.ENTITY;

namespace TASKWAVE.DOMAIN.Interfaces.Repositories
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        public Task CreateUserToEquip(Usuario usuario, int teamId);

        public Task<Usuario?> BuscarPorEmailAsync(string email);
    }
}
