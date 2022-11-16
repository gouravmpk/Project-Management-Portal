using AutoMapper;
using ProjectManagementPortal.API.DTOs.Request;
using ProjectManagementPortal.API.DTOs.Response;
using ProjectManagementPortal.BL.BL;
using ProjectManagementPortal.DL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ProjectManagementPortal.BL.Helper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProjectRequest, ProjectBL>().ReverseMap();
            CreateMap<RegisterUserRequest, UserBL>().ReverseMap();
            CreateMap<UserResponse,GetUserBL>().ReverseMap();
            CreateMap<UpdateUserRequest,UserUpdateBL>().ReverseMap();
            CreateMap<ProjectResponse,ProjectBL>().ReverseMap();
            CreateMap<UpdateProjectRequest, ProjectUpdateBL>().ReverseMap();
            CreateMap<TaskRequest, TaskBL>().ReverseMap();
            CreateMap<TaskResponse,TaskBL>().ReverseMap();
            CreateMap<UpdateTaskRequest,TaskUpdateBL>().ReverseMap();
            CreateMap<ProjectStatusRequest,ProjectStatusBL>().ReverseMap();
            CreateMap<TaskStatusRequest, TaskStatusBL>().ReverseMap();
        }
    }
}
