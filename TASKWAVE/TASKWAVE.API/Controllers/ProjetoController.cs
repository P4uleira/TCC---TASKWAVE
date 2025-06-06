using Microsoft.AspNetCore.Mvc;
using TASKWAVE.DOMAIN.ENTITY;
using TASKWAVE.DOMAIN.Interfaces.Services;
using TASKWAVE.DTO.Requests;
using TASKWAVE.DTO.Responses;

namespace TASKWAVE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoService _projectService;

        public ProjetoController(IProjetoService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjetoResponse>>> GetAll()
        {
            var projetos = await _projectService.GetAllProjects();
            var response = projetos.Select(project => new ProjetoResponse(project.NomeProjeto, project.DescricaoProjeto, project.DataCriacaoProjeto));
            return Ok(response);
        }

        [HttpGet("{idProject}")]
        public async Task<ActionResult<ProjetoResponse>> GetById(int idProject)
        {
            var project = await _projectService.GetProjectById(idProject);
            if (project == null)
                return NotFound();
            return Ok(new ProjetoResponse(project.NomeProjeto, project.DescricaoProjeto, project.DataCriacaoProjeto));
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProjetoRequest projectRequest)
        {
            var project = new Projeto(projectRequest.projectName, projectRequest.projectDescription, projectRequest.projectCreationDate);
            await _projectService.CreateProject(project);
            return CreatedAtAction(nameof(GetById), new { idProject = project.IdProjeto }, null);
        }

        [HttpPost("AddProjectInTeam")]
        public async Task CreateProjectToTeam(ProjetoRequest project, int teamId)
        {
            var newProject = new Projeto(project.projectName, project.projectDescription, project.projectCreationDate);
            await _projectService.CreateProjectToTeam(newProject, teamId);
        }

        [HttpPut("{idProject}")]
        public async Task<ActionResult> Update(int idProject, ProjetoRequest projectRequest)
        {

            var existingProject = await _projectService.GetProjectById(idProject);
            if (existingProject == null)
            {
                return NotFound();
            }

            existingProject.NomeProjeto = projectRequest.projectName;
            existingProject.DescricaoProjeto = projectRequest.projectDescription;

            await _projectService.UpdateProject(existingProject);
            return NoContent();
        }

        [HttpDelete("{idProject}")]
        public async Task<ActionResult> Delete(int idProject)
        {
            await _projectService.DeleteProject(idProject);
            return NoContent();
        }
    }
}
