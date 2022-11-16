using ProjectManagementPortal.BL.BL;
using ProjectManagementPortal.BL.Interface;
using ProjectManagementPortal.DL.Entities;
using ProjectManagementPortal.DL.Repositories.IRepo;
using ProjectManagementPortal.DL.Repositories.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace ProjectManagementPortal.BL.Implementation
{
    public class TaskServices : ITaskServices
    {
        private readonly ITaskRepo _taskRepo;
        private readonly IUserRepo _userRepo;

        public TaskServices(ITaskRepo taskRepo, IUserRepo userRepo)
        {
            _taskRepo = taskRepo;
            _userRepo = userRepo;
        }

        public Task<bool> CreateNewTask(TaskBL taskBL)
        {
            var result=new Tasks{ 
                TaskName=taskBL.TaskName,
                TaskDescription=taskBL.TaskDescription,
                ProjectId=taskBL.ProjectId,
                IsActive=taskBL.IsActive,
                DueDate=taskBL.DueDate,
            };
            return _taskRepo.CreateNewTask(result);
        }

        public IQueryable<TaskBL> GetAllTasks()
        {
            var result=_taskRepo.GetAllTasks();
            var taskList = new List<TaskBL>();
                foreach(var task in result)
                {
                taskList.Add(new TaskBL
                {
                    TaskId=task.TaskId,
                    TaskName = task.TaskName,
                    TaskDescription = task.TaskDescription,
                    TaskMasterId=(int)task.TaskMasterId,
                    DueDate = task.DueDate,
                    ProjectId = task.ProjectId,
                    IsActive = task.IsActive,
                    //TaskMasterId = task.TaskMasterId,
                    TaskStatus = task.TaskStatus,
                    TaskMembers = _taskRepo.GetMemberCountByTaskId(task.TaskId),
                    TaskMembersName=_taskRepo.GetMembersByTaskId(task.TaskId),
                    ProjectName = task.ProjectName,
                }); 
                }
            return taskList.AsQueryable();
        }



        public IQueryable<TaskBL> GetTasksByTaskId(int taskId)
        {
            var tasks= _taskRepo.GetTasksByTaskId(taskId);
            var taskList = new List<TaskBL>();
            foreach(var task in tasks)
            {
                taskList.Add(new TaskBL
                {
                    TaskId = task.TaskId,
                    TaskName = task.TaskName,
                    TaskDescription = task.TaskDescription,
                    TaskMasterId = (int)task.TaskMasterId,
                    DueDate = task.DueDate,
                    ProjectId = task.ProjectId,
                    IsActive = task.IsActive,
                    TaskStatus = task.TaskStatus,
                    TaskMembers = _taskRepo.GetMemberCountByTaskId(task.TaskId),
                    TaskMembersName = _taskRepo.GetMembersByTaskId(task.TaskId),
                    ProjectName=task.ProjectName,
                });
            }
            return taskList.AsQueryable();
        }

        public IQueryable<TaskBL> GetTasksByTaskName(string taskName)
        {
            var tasks = _taskRepo.GetTasksByTaskName(taskName);
            var taskList = new List<TaskBL>();
            foreach(var task in tasks)
            {
                taskList.Add(new TaskBL
                {
                    TaskName = task.TaskName,
                    TaskDescription = task.TaskDescription,
                    ProjectId = task.ProjectId,
                    //TaskMasterId = task.TaskMasterId,
                    IsActive = task.IsActive,
                    DueDate = task.DueDate
                });
            }
            return taskList.AsQueryable();
        }

        public IQueryable<TaskBL> GetAllTasksInOneProject(int projectId)
        {
            var tasks = _taskRepo.GetAllTasksInOneProject(projectId);
            var taskList = new List<TaskBL>();
            foreach (var task in tasks)
            {
                taskList.Add(new TaskBL
                {
                    TaskName = task.TaskName,
                    TaskDescription = task.TaskDescription,
                    ProjectId = task.ProjectId,
                    //TaskMasterId = task.TaskMasterId,
                    IsActive = task.IsActive,
                    DueDate = task.DueDate
                });
            }
            return taskList.AsQueryable();
        }

        public async Task<bool> DeleteTask(int taskId)
        {
            var result=await _taskRepo.DeleteTask(taskId);
            return result;
        }

        public async Task<bool> UpdateTask(TaskUpdateBL task)
        {
            int loggedInUserId = _userRepo.LoggedInUserId();
            var tasks = new Tasks
            {
                TaskId = task.TaskId,
                TaskName=task.TaskName,
                TaskDescription=task.TaskDescription,
                IsActive = task.IsActive,
                UpdateDate = DateTime.Now,
                UpdatedBy = loggedInUserId,
                DueDate= DateTime.Now
            };
            return await _taskRepo.UpdateTask(tasks);
        }

        public async Task<bool> TaskAssign(int userId, int taskId)
        {
            var x = new TaskAssignment { UserId = userId, TaskId = taskId };

            return await _taskRepo.AssignTask(x);
        }

        public async Task<bool> UpdateTaskStatus(int taskId, int task) {
            var tasks = new Tasks 
         {
            TaskMasterId = task, 
         }; 
            return await _taskRepo.UpdateTaskStatus(taskId, tasks); 
         }



    }
}
