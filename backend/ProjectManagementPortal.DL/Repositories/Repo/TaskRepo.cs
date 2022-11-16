using Microsoft.EntityFrameworkCore;
using ProjectManagementPortal.DL.Entities;
using ProjectManagementPortal.DL.Repositories.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementPortal.DL.Repositories.Repo
{
    public class TaskRepo : ITaskRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public TaskRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<bool> CreateNewTask(Tasks task)
        {
            await _applicationDbContext.Tasks.AddAsync(task);
            var status = await _applicationDbContext.SaveChangesAsync();
            if (status == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<TaskDetails> GetAllTasks()
        {

            var taskList = _applicationDbContext.Tasks.ToList();
            var tasks = new List<TaskDetails>();
            foreach (var task in taskList)
            {
                var projectName=_applicationDbContext.Projects.FirstOrDefault(x=>x.ProjectId==task.ProjectId)?.ProjectName;
                var status = _applicationDbContext.TaskMasters.FirstOrDefault(t => t.TaskMasterId == task.TaskMasterId)?.TaskStatus;
                tasks.Add(new TaskDetails
                {
                    TaskMasterId = task.TaskMasterId,
                    TaskName = task.TaskName,
                    TaskDescription = task.TaskDescription,
                    CreateDate = task.CreateDate,
                    CreatedBy = task.CreatedBy,
                    DueDate = task.DueDate,
                    IsActive = task.IsActive,
                    ProjectId = task.ProjectId,
                    TaskId = task.TaskId,
                    TaskStatus = status,
                    ProjectName=projectName,
                });
            }
            return tasks;
        }
        public List<TaskDetails> GetTasksByTaskId(int taskId)
        {
            var tasks = _applicationDbContext.Tasks.Where(x => x.TaskId == taskId).ToList();
            var taskList= new List<TaskDetails>();
            foreach(var task in tasks)
            {
                var status = _applicationDbContext.TaskMasters.FirstOrDefault(t => t.TaskMasterId == task.TaskMasterId)?.TaskStatus;
                taskList.Add(new TaskDetails
                {
                    TaskMasterId = task.TaskMasterId,
                    TaskName = task.TaskName,
                    TaskDescription = task.TaskDescription,
                    CreateDate = task.CreateDate,
                    CreatedBy = task.CreatedBy,
                    DueDate = task.DueDate,
                    IsActive = task.IsActive,
                    ProjectId = task.ProjectId,
                    TaskId = task.TaskId,
                    TaskStatus = status
                });
            }
            return taskList;
        }



        public int GetMemberCountByTaskId(int taskId)
        {
            return _applicationDbContext.TaskAssignments.Count(x => x.TaskId == taskId);
        }

        public List<string> GetMembersByTaskId(int taskId)
        {
            var users= _applicationDbContext.TaskAssignments.Where(x => x.TaskId == taskId);
            return users.Select(x=>$"{x.User.FirstName} {x.User.LastName}" ).ToList();
        }

        public List<Tasks> GetTasksByTaskName(string taskName)
        {
            var tasks = _applicationDbContext.Tasks.Where(x => x.TaskName == taskName).ToList();
            return tasks;
        }

        public List<Tasks> GetAllTasksInOneProject(int projectId)
        {
            var tasks = _applicationDbContext.Tasks.Where(_x => _x.ProjectId == projectId).ToList();
            return tasks;
        }

        public async Task<bool> DeleteTask(int taskId)
        {
            var task = await _applicationDbContext.Tasks.FirstOrDefaultAsync(x => x.TaskId == taskId);
            if (task != null)
            {
                var status = _applicationDbContext.Remove(task);
                if (status != null)
                {
                    await _applicationDbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            return false;
        }

        public async Task<bool> UpdateTask(Tasks task)
        {
            var tasks = await _applicationDbContext.Tasks.FirstOrDefaultAsync(x => x.TaskId == task.TaskId);
            if (tasks != null)
            {
                tasks.TaskId = task.TaskId;
                tasks.TaskName = task.TaskName;
                tasks.TaskDescription = task.TaskDescription;
                tasks.UpdatedBy = task.UpdatedBy;
                tasks.UpdateDate = task.UpdateDate;
                tasks.DueDate = task.DueDate;
                tasks.IsActive = task.IsActive;

            }
            var result = await _applicationDbContext.SaveChangesAsync();
            return (result == 1) ? true : false;
        }

        public async Task<bool> AssignTask(TaskAssignment taskAssignments)
        {
            _applicationDbContext.TaskAssignments.Add(taskAssignments);




            var result = await _applicationDbContext.SaveChangesAsync();
            if (result > 0)
                return true;
            else
                return false;
        }

        public async Task<bool> UpdateTaskStatus(int taskId, Tasks task)
        {
            var tasks = await _applicationDbContext.Tasks.FirstOrDefaultAsync(x => x.TaskId == taskId);
            if (tasks != null)
            {
                tasks.TaskMasterId = task.TaskMasterId;
            }
            var result = await _applicationDbContext.SaveChangesAsync();
            return (result == 1) ? true : false;
        }

    }
}
