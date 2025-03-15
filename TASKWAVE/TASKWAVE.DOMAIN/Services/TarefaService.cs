using TASKWAVE.API.Infrastructure.Model;
using TASKWAVE.DOMAIN.Interfaces.Repositories;
using TASKWAVE.DOMAIN.Interfaces.Services;

namespace TASKWAVE.DOMAIN.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _taskRepository;

        public TarefaService(ITarefaRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task CreateTask(Tarefa task)
        {
            await _taskRepository.AddAsync(task);
        }
        public async Task UpdateTask(Tarefa task)
        {
            await _taskRepository.UpdateAsync(task);
        }

        public async Task DeleteTask(int idTask)
        {
            await _taskRepository.DeleteAsync(idTask);
        }

        public async Task<IEnumerable<Tarefa>> GetAllTasks()
        {
            return await _taskRepository.GetAllAsync();
        }

        public async Task<Tarefa> GetTaskById(int idTask)
        {
            return await _taskRepository.GetByIdAsync(idTask);
        }
    }
}
