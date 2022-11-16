using ProjectManagementPortal.BL.BL;
using ProjectManagementPortal.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementPortal.BL.Interface
{
    public interface IProjectServices
    {
        public Task<bool> AddNewProject(ProjectBL project);
        IQueryable<ProjectBL> GetAllProjects();
        IQueryable<ProjectBL> GetProjectByProjectId(int projectId);
        IQueryable<ProjectBL> GetProjectByProjectName(string projectName);
        Task<bool> UpdateProject(ProjectUpdateBL project);
        Task<bool> DeleteProject(int projectId);
        Task<bool> ProjectAssign(int userId, int projectId);
        Task<bool> UpdateProjectStatus(int projectId,int projectMasterId);
        List<GetUserBL> GetAllMembersInOneProject(int projectId);
    }
}
