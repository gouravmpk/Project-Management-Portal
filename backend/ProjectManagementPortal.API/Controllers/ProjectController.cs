using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementPortal.API.DTOs.Request;
using ProjectManagementPortal.API.DTOs.Response;
using ProjectManagementPortal.BL.BL;
using ProjectManagementPortal.BL.Implementation;
using ProjectManagementPortal.BL.Interface;
using ProjectManagementPortal.DL.Entities;
using System.Threading.Tasks;

namespace ProjectManagementPortal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        private readonly IProjectServices _projectServices;
        private readonly IMapper _mapper;

        public ProjectController(IProjectServices projectServices,IMapper mapper)
        {
            _projectServices = projectServices;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewProject([FromBody] ProjectRequest projectRequest)
        {
            var project= _mapper.Map<ProjectBL>(projectRequest);
            var status = await _projectServices.AddNewProject(project);
            if(status)
            {
                return StatusCode(StatusCodes.Status201Created, "Project Created Successfully!!!!");
            }
            else
            {
                return BadRequest("ERROR While Adding Project.Please Try Again!!!!");
            }
        }

        [HttpGet]
        public ActionResult<List<ProjectResponse>> GetAllProjects()
        {
            var project = _projectServices.GetAllProjects();
            return _mapper.Map<List<ProjectResponse>>(project);
        }

        [HttpGet("id")]
        public ActionResult<List<ProjectResponse>> GetProjectByProjectId(int projectId)
        {
            var project = _projectServices.GetProjectByProjectId(projectId);
            return _mapper.Map<List<ProjectResponse>>(project);
        }

        [HttpGet("Name")]
        public ActionResult<List<ProjectResponse>> GetProjectByProjectName(string projectName)
        {
            var project = _projectServices.GetProjectByProjectName(projectName);
            return _mapper.Map<List<ProjectResponse>>(project);
        }


        [HttpPut("Id")]
        public async Task<IActionResult> UpdateProject([FromBody] UpdateProjectRequest updateProjectRequest)
        {
            var project=_mapper.Map<ProjectUpdateBL>(updateProjectRequest);
            var result =await _projectServices.UpdateProject(project);
            if(result)
            {
                return StatusCode(StatusCodes.Status202Accepted, "Project Updated.");
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest,"ERROR Occured");
            }
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteProject(int projectId)
        {
            var status = await _projectServices.DeleteProject(projectId);
            if (status)
            {
                return StatusCode(StatusCodes.Status200OK, $"Project with ProjectID {projectId} is this deleted successfully!");
            }
            else
            {
                return BadRequest($"An error occurred while removing project with ProjectID {projectId}, Please check the ID and try again!!");
            }
        }

        [HttpPut("Status")]
        public async Task<IActionResult> UpdateProjectStatus(int projectId, int projectMasterId)
        {
            var result = await _projectServices.UpdateProjectStatus(projectId,projectMasterId);
            if (result)
            {
                return StatusCode(StatusCodes.Status202Accepted, "Project Status Updated.");
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "ERROR Occured");
            }
        }


        
    }
    
}
