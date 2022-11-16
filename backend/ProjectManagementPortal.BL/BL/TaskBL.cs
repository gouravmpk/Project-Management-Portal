using ProjectManagementPortal.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementPortal.BL.BL
{
    public class TaskBL
    {
        public int TaskId { get; set; }
        public string? TaskName { get; set; }
        public string? TaskDescription { get; set; }

        public int ProjectId { get; set; }
        public bool IsActive { get; set; }
        public DateTime DueDate { get; set; }
        public string? TaskStatus { get; set; }
      
        public int TaskMembers { get; set; }
        public int TaskMasterId { get; set; }
        public List<string>? TaskMembersName { get; set; }
        public string? ProjectName { get; set; }
    }
}
