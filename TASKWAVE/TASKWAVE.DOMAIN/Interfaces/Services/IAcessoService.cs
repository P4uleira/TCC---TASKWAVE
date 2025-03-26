﻿using TASKWAVE.DOMAIN.ENTITY;

namespace TASKWAVE.DOMAIN.Interfaces.Services
{
    public interface IAcessoService
    {
        Task CreateAccess(Acesso access);
        Task UpdateAccess(Acesso access);
        Task DeleteAccess(int id);
        Task<IEnumerable<Acesso>> GetAllAccesses();
        Task<Acesso> GetAccessById(int id);
        Task InsertAccessToUser(int idAccess, int idUser);
    }
}
