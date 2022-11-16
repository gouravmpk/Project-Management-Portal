using ProjectManagementPortal.DL.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagementPortal.API.DTOs.Response
{
    public class ProjectResponse
    {
       
        public string? ProjectName { get; set; }
        public string? ProjectDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public int ProjectId { get; set; }
        public int ProjectMembers { get; set; }
        public List<string>? ProjectMembersName { get; set; }
        public string? ClientName { get; set; }
        public string? GoalOfProject { get; set; }
        public string? TechnologiesUsed { get; set; }
        
        public string? ProjectStatus { get; set; }
        

    }
}
