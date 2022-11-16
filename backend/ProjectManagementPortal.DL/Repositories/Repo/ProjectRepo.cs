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
    public class ProjectRepo : IProjectRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProjectRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<bool> AddNewProject(Project project)
        {
            await _applicationDbContext.Projects.AddAsync(project);
            var status=await _applicationDbContext.SaveChangesAsync();
            if(status==1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<ProjectDetails> GetAllProjects()
        {
            var projectList = _applicationDbContext.Projects.ToList();
            var projects = new List<ProjectDetails>();
            foreach (var project in projectList)
            {
                var status = _applicationDbContext.ProjectMasters.FirstOrDefault(t => t.ProjectMasterId == project.ProjectMasterId)?.ProjectStatus;
                projects.Add(new ProjectDetails
                {
                    ProjectId=project.ProjectId,
                    ProjectMasterId = project.ProjectMasterId,
                    ProjectName = project.ProjectName,
                    ProjectDescription = project.ProjectDescription,
                    StartDate = project.StartDate,
                    EndDate = project.EndDate,
                    CreateDate = project.CreateDate,
                    CreatedBy = project.CreatedBy,
                    IsActive = project.IsActive,
                    ProjectStatus = status,
                    ClientName = project.ClientName,
                    TechnologiesUsed = project.TechnologiesUsed,
                    GoalOfProject = project.GoalOfProject,
                });
            }
            return projects;
        }

        public List<ProjectDetails> GetProjectByProjectId(int projectId)
        {
            var projects = _applicationDbContext.Projects.Where(x => x.ProjectId == projectId).ToList();
            var projectList = new List<ProjectDetails>();
            foreach (var project in projects)
            {
                var status = _applicationDbContext.ProjectMasters.FirstOrDefault(t => t.ProjectMasterId == project.ProjectMasterId)?.ProjectStatus;
                projectList.Add(new ProjectDetails
                {
                    ProjectMasterId = project.ProjectMasterId,
                    ProjectName = project.ProjectName,
                    ProjectDescription = project.ProjectDescription,
                    StartDate = project.StartDate,
                    EndDate = project.EndDate,
                    CreateDate = project.CreateDate,
                    IsActive = project.IsActive,
                    CreatedBy = project.CreatedBy,
                    ProjectId = project.ProjectId,
                    ProjectStatus = status,
                    ClientName = project.ClientName,
                    TechnologiesUsed = project.TechnologiesUsed,
                    GoalOfProject = project.GoalOfProject,
                });
            }
            return projectList;
        }

        public List<Project> GetProjectByProjectName(string projectName)
        {
            var result = _applicationDbContext.Projects.Where(x => x.ProjectName == projectName).ToList();
            return result;
        }
        public async Task<bool> DeleteProject(int projectId)
        {
            var project = await _applicationDbContext.Projects.FirstOrDefaultAsync(x => x.ProjectId == projectId);
            if (project != null)
            {
                var status = _applicationDbContext.Remove(project);
                if (status != null)
                {
                    await _applicationDbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            return false;
        }

        public async Task<bool> UpdateProject(Project project)
        {
            var projects = await _applicationDbContext.Projects.FirstOrDefaultAsync(x => x.ProjectId==project.ProjectId);
            if (projects != null)
            {
                projects.ProjectId=project.ProjectId;
                projects.ProjectName = project.ProjectName;
                projects.ProjectDescription = project.ProjectDescription;
                projects.EndDate = project.EndDate;
                projects.UpdateDate = project.UpdateDate;
                projects.UpdatedBy=project.UpdatedBy;
               
            }
            var result = await _applicationDbContext.SaveChangesAsync();
            return (result == 1) ? true : false;
        }

        public async Task<bool> AssignProject(ProjectAssignment projectAssignments)
        {
            _applicationDbContext.ProjectAssigments.Add(projectAssignments);

            var result = await _applicationDbContext.SaveChangesAsync();
            if (result > 0)
                return true;
            else
                return false;
        }

        public async Task<bool> UpdateProjectStatus(int projectId,Project project)
        {
            var projects = await _applicationDbContext.Projects.FirstOrDefaultAsync(x => x.ProjectId == projectId);
            if (projects != null)
            {
                projects.ProjectMasterId = project.ProjectMasterId;
            }
            var result = await _applicationDbContext.SaveChangesAsync();
            return (result == 1) ? true : false;
        }

        public List<User> GetAllMembersInOneProject(int projectId)
        {
            var list = _applicationDbContext.ProjectAssigments.Where(x => x.ProjectId == projectId).ToList();
            var UserList = new List<User>();
            foreach (var assignment in list)
            {
                var user=_applicationDbContext.Users.FirstOrDefault(x=>x.UserId == assignment.UserId);
                UserList.Add(new User{
                    FirstName= user?.FirstName,
                    LastName= user?.LastName,
                    DateOfBirth=user.DateOfBirth,
                    EmailId=user?.EmailId,
                    Location=user?.Location,
                    PhoneNumber=user?.PhoneNumber,
                    UserId=user.UserId,
                });
            }
            return UserList;
        }

        public int GetMemberCountByProjectId(int projectId)
        {
            return _applicationDbContext.ProjectAssigments.Count(x => x.ProjectId == projectId);
        }

        public List<string> GetMembersByProjectId(int projectId)
        {
            var users = _applicationDbContext.ProjectAssigments.Where(x => x.ProjectId == projectId);
            return users.Select(x => $"{x.User.FirstName} {x.User.LastName}").ToList();
        }


    }
}
