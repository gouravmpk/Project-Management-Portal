using ProjectManagementPortal.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementPortal.DL.Repositories.IRepo
{
    public interface IProjectRepo
    {
        public Task<bool> AddNewProject(Project project);
        List<ProjectDetails> GetAllProjects();
        List<ProjectDetails> GetProjectByProjectId(int projectId);
        List<Project> GetProjectByProjectName(string projectName);
        Task<bool> UpdateProject(Project project);

        Task<bool> DeleteProject(int projectId);
        Task<bool> AssignProject(ProjectAssignment projectAssignments);
        Task<bool> UpdateProjectStatus(int projectId,Project project);
        List<User> GetAllMembersInOneProject(int projectId);
        int GetMemberCountByProjectId(int projectId);
        List<string> GetMembersByProjectId(int projectId);
        

    }
}
