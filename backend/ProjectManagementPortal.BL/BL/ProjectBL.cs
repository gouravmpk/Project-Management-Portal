using ProjectManagementPortal.DL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementPortal.BL.BL
{
    public class ProjectBL
    {
        public string? ProjectName { get; set; }

        public string? ProjectDescription { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public int ? ProjectId { get; set; }
        public string? ProjectStatus { get; set; }

        public int ProjectMembers { get; set; }
        public int ProjectMasterId { get; set; }
        public List<string>? ProjectMembersName { get; set; }
        public string? ClientName { get; set; }
        public string? GoalOfProject { get; set; }
        public string? TechnologiesUsed { get; set; }

    }
}
