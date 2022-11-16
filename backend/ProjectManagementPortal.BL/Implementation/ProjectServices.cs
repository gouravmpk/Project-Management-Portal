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

namespace ProjectManagementPortal.BL.Implementation
{
    public class ProjectServices : IProjectServices
    {
        private readonly IProjectRepo _projectRepo;

        private readonly IUserRepo _userRepo;
        public ProjectServices(IProjectRepo projectRepo, IUserRepo userRepo)
        {
            _projectRepo = projectRepo;
            _userRepo = userRepo;
        }
        public async Task<bool> AddNewProject(ProjectBL project)
        {
            int loggedInUserId = _userRepo.LoggedInUserId();
            var result = new Project
            {
                ProjectName = project.ProjectName,
                ProjectDescription = project.ProjectDescription,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                IsActive = project.IsActive,
                CreatedBy = loggedInUserId,
                CreateDate=DateTime.Now
            };
            return await _projectRepo.AddNewProject(result);

        }


        public IQueryable<ProjectBL> GetAllProjects()
        {
            var result = _projectRepo.GetAllProjects();
            var projectList = new List<ProjectBL>();
            foreach (var project in result)
            {
                projectList.Add(new ProjectBL
                {
                    ProjectId = project.ProjectId,
                   ProjectName=project.ProjectName,
                   ProjectDescription=project.ProjectDescription,
                   StartDate=project.StartDate,
                   EndDate=project.EndDate,
                   IsActive=project.IsActive,
                   CreateDate = DateTime.Now,
                   ProjectStatus = project.ProjectStatus,
                   ProjectMembers = _projectRepo.GetMemberCountByProjectId(project.ProjectId),
                   ProjectMembersName = _projectRepo.GetMembersByProjectId(project.ProjectId),
                    ClientName = project.ClientName,
                    TechnologiesUsed = project.TechnologiesUsed,
                    GoalOfProject = project.GoalOfProject,

                });
            }
            return projectList.AsQueryable();
        }

        public IQueryable<ProjectBL> GetProjectByProjectId(int projectId)
        {
            var result = _projectRepo.GetProjectByProjectId(projectId);
            var projectList = new List<ProjectBL>();
            foreach (var project in result)
            {
                projectList.Add(new ProjectBL
                {
                    ProjectName = project.ProjectName,
                    ProjectDescription = project.ProjectDescription,
                    StartDate = project.StartDate,
                    EndDate = project.EndDate,
                    IsActive = project.IsActive,
                    CreateDate = DateTime.Now,
                    ProjectStatus = project.ProjectStatus,
                    ProjectMembers = _projectRepo.GetMemberCountByProjectId(project.ProjectId),
                    ProjectMembersName = _projectRepo.GetMembersByProjectId(project.ProjectId),
                    ClientName = project.ClientName,
                    TechnologiesUsed = project.TechnologiesUsed,
                    GoalOfProject = project.GoalOfProject,

                });
            }
            return projectList.AsQueryable();
        }

        public IQueryable<ProjectBL> GetProjectByProjectName(string projectName)
        {
            var result = _projectRepo.GetProjectByProjectName(projectName);
            var projectList = new List<ProjectBL>();
            foreach (var project in result)
            {
                projectList.Add(new ProjectBL
                {
                    ProjectName = project.ProjectName,
                    ProjectDescription = project.ProjectDescription,
                    StartDate = project.StartDate,
                    EndDate = project.EndDate,
                    IsActive = project.IsActive,
                    CreateDate = DateTime.Now,
                  
                });
            }
            return projectList.AsQueryable();
        }

        public async Task<bool> DeleteProject(int projectId)
        {
            var result= await _projectRepo.DeleteProject(projectId);
            return result;
        }

        public async Task<bool> UpdateProject(ProjectUpdateBL project)
        {
            int loggedInUserId = _userRepo.LoggedInUserId();
            var projects = new Project
            {
                ProjectId = project.ProjectId,
                ProjectName=project.ProjectName,
                ProjectDescription = project.ProjectDescription,
                EndDate=project.EndDate,
                UpdateDate = DateTime.Now,
                UpdatedBy=loggedInUserId
            };
            return await _projectRepo.UpdateProject(projects);
        }

        public async Task<bool> ProjectAssign(int userId, int projectId)
        {
            var x = new ProjectAssignment { UserId = userId, ProjectId = projectId };


            return await _projectRepo.AssignProject(x);
        }

        public async Task<bool> UpdateProjectStatus(int projectId,int project)
        {
            var projects = new Project
            {
                ProjectMasterId=project,
            };
            return await _projectRepo.UpdateProjectStatus(projectId,projects);
        }

        public List<GetUserBL> GetAllMembersInOneProject(int projectId)
        {
            var userQueryable = _projectRepo.GetAllMembersInOneProject(projectId);
            var userList = new List<GetUserBL>();
            foreach (var user in userQueryable)
            {
                userList.Add(new GetUserBL
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    DateOfBirth= user.DateOfBirth,
                    PhoneNumber = user.PhoneNumber,
                    EmailId = user.EmailId,
                    Location = user.Location,
                    UserId= user.UserId,
                }); 

            }
            return userList;
        }
    }
}
