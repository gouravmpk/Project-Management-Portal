using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementPortal.DL.Entities
{
   public class TaskDetails
    {
        public int TaskId { get; set; }
        
        public string? TaskName { get; set; }
       
        public string? TaskDescription { get; set; }

        
        public System.Nullable<int> TaskMasterId { get; set; } = 1;
        public TaskMaster? TaskMaster { get; set; }
      
        public int ProjectId { get; set; }
        public Project Project { get; set; }
       
        public bool IsActive { get; set; }
        public string? TaskStatus { get; set; }
        public DateTime CreateDate { get; set; }
        public System.Nullable<DateTime> UpdateDate { get; set; }
      
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
       
        public DateTime DueDate { get; set; }
        public string? ProjectName { get; set; }
    }
}
