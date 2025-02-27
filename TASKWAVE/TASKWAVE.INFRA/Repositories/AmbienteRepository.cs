using TASKWAVE.API.Infrastructure.Data;
using TASKWAVE.API.Infrastructure.Model;
using TASKWAVE.DOMAIN.Interfaces.Repositories;


namespace TASKWAVE.INFRA.Repositories
{
    public class AmbienteRepository : BaseRepository<Ambiente>, IAmbienteRepository 
    {
        public AmbienteRepository(TaskWaveContext context) : base(context)
        {

        }
    }
}

