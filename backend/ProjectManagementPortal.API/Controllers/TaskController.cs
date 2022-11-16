using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ProjectManagementPortal.API.Auth;
using ProjectManagementPortal.API.DTOs.Request;
using ProjectManagementPortal.API.DTOs.Response;
using ProjectManagementPortal.BL.Implementation;
using ProjectManagementPortal.BL.Interface;
using ProjectManagementPortal.DL.Entities;
using System.Threading.Tasks;
using ProjectManagementPortal.BL.BL;

namespace ProjectManagementPortal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TaskController : Controller
    {
        private readonly ITaskServices _taskServices;
        private readonly IMapper _mapper;
        public TaskController(ITaskServices taskServices, IMapper mapper)
        {
            _taskServices = taskServices;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewTask([FromBody] TaskRequest taskRequest)
        {
            var task = _mapper.Map<TaskBL>(taskRequest);
            var status = await _taskServices.CreateNewTask(task);
            if (status)
            {
                return StatusCode(StatusCodes.Status201Created, "Task Added Successfully!!!!");
            }
            else
            {
                return BadRequest("ERROR While Adding Task.Please Try Again!!!!");
            }
        }

        [HttpGet]
        public  ActionResult<List<TaskResponse>> GetAllTasks()
        {
            var task = _taskServices.GetAllTasks();
            return _mapper.Map<List<TaskResponse>>(task);   
        }

        [HttpGet("Id")]
        public ActionResult<List<TaskResponse>> GetTaskByTaskId(int taskId)
        {
            var tasks=_taskServices.GetTasksByTaskId(taskId);
            return _mapper.Map<List<TaskResponse>>(tasks);
        }

        [HttpGet("Name")]
        public ActionResult<List<TaskResponse>> GetTaskByTaskName(string taskName)
        {
            var tasks = _taskServices.GetTasksByTaskName(taskName);
            return _mapper.Map<List<TaskResponse>>(tasks);
        }

        [HttpGet("ProjectId")]
        public ActionResult<List<TaskResponse>> GetAllTaskInOneProject(int projectId)
        {
            var tasks = _taskServices.GetAllTasksInOneProject(projectId);
            return _mapper.Map<List<TaskResponse>>(tasks);
        }

        [HttpPut("Id")]
        public async Task<IActionResult> UpdateTask([FromBody] UpdateTaskRequest updateTaskRequest)
        {
            var project = _mapper.Map<TaskUpdateBL>(updateTaskRequest);
            var result = await _taskServices.UpdateTask(project);
            if (result)
            {
                return StatusCode(StatusCodes.Status202Accepted, "Task Updated.");
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "ERROR Occured");
            }
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteTask(int taskId)
        {
            var status = await _taskServices.DeleteTask(taskId);
            if (status)
            {
                return StatusCode(StatusCodes.Status200OK, $"Task with TaskID {taskId} is this deleted successfully!");
            }
            else
            {
                return BadRequest($"An error occurred while removing task with TaskID {taskId}, Please check the ID and try again!!");
            }
        }

        [HttpPut("Status")]
        public async Task<IActionResult> UpdateTaskStatus(int taskId, int taskStatus)
        {
            var result = await _taskServices.UpdateTaskStatus(taskId, taskStatus);
            if (result)
            {
                return StatusCode(StatusCodes.Status202Accepted, "Task Status Updated.");
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "ERROR Occured");
            }
        }


    }
}
    

