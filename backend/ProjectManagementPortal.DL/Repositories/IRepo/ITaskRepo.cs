using ProjectManagementPortal.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementPortal.DL.Repositories.IRepo
{
    public interface ITaskRepo
    {
        Task<bool> CreateNewTask(Tasks task);
        List<TaskDetails> GetAllTasks();
        List<TaskDetails> GetTasksByTaskId(int taskId);
        List<Tasks> GetTasksByTaskName(string taskName);
        List<Tasks> GetAllTasksInOneProject(int projectId);
        Task<bool> UpdateTask(Tasks task);
        Task<bool> DeleteTask(int taskId);
        Task<bool> AssignTask(TaskAssignment taskAssignments);
        Task<bool> UpdateTaskStatus(int taskId, Tasks task);
        int GetMemberCountByTaskId(int taskId);
        List<string> GetMembersByTaskId(int taskId);
    }
}
