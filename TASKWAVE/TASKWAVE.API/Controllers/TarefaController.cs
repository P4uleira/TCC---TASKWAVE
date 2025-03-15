using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using TASKWAVE.API.Infrastructure.Model;
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
            var task = new Tarefa(taskRequest.nomeTarefa, taskRequest.descricaoTarefa, taskRequest.situacaoTarefa, taskRequest.prioridadeTarefa, taskRequest.dataCriacaoTarefa, taskRequest.projetoId);
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

            taskExist.NomeTarefa = taskRequest.nomeTarefa;
            taskExist.DescricaoTarefa = taskRequest.descricaoTarefa;
            taskExist.SituacaoTarefa = taskRequest.situacaoTarefa;
            taskExist.PrioridadeTarefa = taskRequest.prioridadeTarefa;

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
