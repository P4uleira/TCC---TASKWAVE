using Microsoft.AspNetCore.Mvc;
using TASKWAVE.DOMAIN.ENTITY;
using TASKWAVE.API.Requests;
using TASKWAVE.API.Responses;
using TASKWAVE.DOMAIN.Interfaces.Services;

namespace TASKWAVE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService _taskService;

        public TarefaController(ITarefaService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TarefaResponse>>> GetAll()
        {
            var tasks = await _taskService.GetAllTasks();
            var response = tasks.Select(task => new TarefaResponse(task.NomeTarefa, task.DescricaoTarefa, task.SituacaoTarefa, task.PrioridadeTarefa, task.DataCriacaoTarefa, task.ProjetoId));
            return Ok(response);
        }

        [HttpGet("{idTask}")]
        public async Task<ActionResult<TarefaResponse>> GetById(int idTask)
        {
            var task = await _taskService.GetTaskById(idTask);
            if (task == null)
                return NotFound();
            return Ok(new TarefaResponse(task.NomeTarefa, task.DescricaoTarefa, task.SituacaoTarefa, task.PrioridadeTarefa, task.DataCriacaoTarefa, task.ProjetoId));
        }
        [HttpPost]
        public async Task<ActionResult> Create(TarefaRequest taskRequest)
        {
            var task = new Tarefa(taskRequest.taskName, taskRequest.taskDescription, taskRequest.taskStatus, taskRequest.taskPriority, taskRequest.taskCreationDate, taskRequest.projectId);
            await _taskService.CreateTask(task);
            return CreatedAtAction(nameof(GetById), new { id = task.IdTarefa }, null);
        }
        [HttpPut("{idTask}")]
        public async Task<ActionResult> Update(int idTask, TarefaRequest taskRequest)
        {
            var taskExist = await _taskService.GetTaskById(idTask);
            if (taskExist == null)
            {
                return NotFound();
            }

            taskExist.NomeTarefa = taskRequest.taskName;
            taskExist.DescricaoTarefa = taskRequest.taskDescription;
            taskExist.SituacaoTarefa = taskRequest.taskStatus;
            taskExist.PrioridadeTarefa = taskRequest.taskPriority;

            await _taskService.UpdateTask(taskExist);
            return NoContent();
        }

        [HttpDelete("{idTask}")]
        public async Task<ActionResult> Delete(int idTask)
        {
            await _taskService.DeleteTask(idTask);
            return NoContent();
        }
    }
}
