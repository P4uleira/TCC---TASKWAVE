using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TASKWAVE.API.Infrastructure.Model;

namespace TASKWAVE.DOMAIN.Interfaces.Services
{
    public interface IAmbienteService
    {
        Task CreateAmbiente(Ambiente ambiente);
        Task UpdateAmbiente(Ambiente ambiente);
        Task DeleteAmbiente(int id);
        Task<IEnumerable<Ambiente>> GetAllAmbientes();
        Task<Ambiente> GetAmbienteById(int id);
    }
}
