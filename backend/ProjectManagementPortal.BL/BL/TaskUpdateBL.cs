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
    public class TaskUpdateBL
    {
        public int TaskId { get; set; }
        public string? TaskName { get; set; }
        public string? TaskDescription { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime DueDate { get; set; }
    }
}
