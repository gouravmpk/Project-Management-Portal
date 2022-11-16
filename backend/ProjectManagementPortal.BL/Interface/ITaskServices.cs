using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagementPortal.BL.BL;

namespace ProjectManagementPortal.BL.Interface
{
    public interface ITaskServices
    {
        Task<bool> CreateNewTask(TaskBL taskBL);
        IQueryable<TaskBL> GetAllTasks();
        IQueryable<TaskBL> GetTasksByTaskId(int taskId);
        IQueryable<TaskBL> GetTasksByTaskName(string taskName);
        IQueryable<TaskBL> GetAllTasksInOneProject(int projectId);
        Task<bool> UpdateTask(TaskUpdateBL task);
        Task<bool> DeleteTask(int taskId);
        Task<bool> UpdateTaskStatus(int taskId, int task);
        Task<bool> TaskAssign(int userId, int taskId);
    }
}
