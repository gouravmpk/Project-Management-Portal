using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementPortal.DL.Entities
{
    public class ProjectDetails
    {
      
        public int ProjectId { get; set; }
       
        public string? ProjectName { get; set; }
       
        public string? ProjectDescription { get; set; }
        
        public DateTime StartDate { get; set; }
      
        public DateTime EndDate { get; set; }
       
        public System.Nullable<int> ProjectMasterId { get; set; } = 1;
        public ProjectMaster? ProjectMaster { get; set; }
       
        public bool IsActive { get; set; }
      
        public DateTime CreateDate { get; set; }
        public System.Nullable<DateTime> UpdateDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public string? ProjectStatus { get; set; }
        public string? ClientName { get; set; }
        public string? GoalOfProject { get; set; }
        public string? TechnologiesUsed { get; set; }

    }
}
