using ProjectManagementPortal.DL.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagementPortal.API.DTOs.Request
{
    public class ProjectRequest
    {
        [Required]
        public string? ProjectName { get; set; }
        [Required]
        public string? ProjectDescription { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
       
        [Required]
        public bool IsActive { get; set; }
        public string? ClientName { get; set; }
        public string? GoalOfProject { get; set; }
        public string? TechnologiesUsed { get; set; }

    }
}
