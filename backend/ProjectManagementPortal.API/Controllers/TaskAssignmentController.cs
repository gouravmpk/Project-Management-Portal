using Microsoft.AspNetCore.Mvc;
using ProjectManagementPortal.API.DTOs.Request;
using ProjectManagementPortal.BL.Interface;

namespace ProjectManagementPortal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TaskAssignmentController : Controller
    {
        private readonly ITaskServices _taskServices;

        public TaskAssignmentController(ITaskServices taskServices)
        {
            _taskServices = taskServices;
        }

        [HttpPost]
        public async Task<IActionResult> TaskAssign(int userId, int taskId)
        {
            return await _taskServices.TaskAssign(userId, taskId)
                ? StatusCode(StatusCodes.Status201Created, "Users assigned to the Task")
                : BadRequest("ERROR. Couldn't assign members to Task.");
        }

    }
}
