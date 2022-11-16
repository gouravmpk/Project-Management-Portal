using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementPortal.API.DTOs.Request;
using ProjectManagementPortal.API.DTOs.Response;
using ProjectManagementPortal.BL.Implementation;
using ProjectManagementPortal.BL.Interface;
using ProjectManagementPortal.DL.Entities;

namespace ProjectManagementPortal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProjectAssignmentController : Controller
    {
        private readonly IProjectServices _projectServices;
        private readonly IUserServices _userServices;
        private IMapper _mapper;

        public ProjectAssignmentController(IProjectServices projectServices,IMapper mapper)
        {
            _projectServices = projectServices;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> ProjectAssign(int userId, int projectId)
        {
            return await _projectServices.ProjectAssign(userId, projectId)
                ? StatusCode(StatusCodes.Status201Created, "Users assigned to the Project")
                : BadRequest("ERROR. Couldn't assign members to project.");
        }

        [HttpGet("projectId")]
        public ActionResult<List<UserResponse>> GetAllMembersInOneProject(int projectId)
        {
            var users = _projectServices.GetAllMembersInOneProject(projectId);
            return _mapper.Map<List<UserResponse>>(users);
        }
    }
}
