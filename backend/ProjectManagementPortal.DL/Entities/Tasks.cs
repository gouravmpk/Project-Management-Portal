using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementPortal.DL.Entities
{
    public class Tasks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskId { get; set; }
        [Required]
        public string? TaskName { get; set; }
        [Required]
        public string? TaskDescription { get; set; }

        [ForeignKey("TaskMaster")]
        public System.Nullable<int> TaskMasterId { get; set; } = 1;
        public TaskMaster? TaskMaster { get; set; }
        [Required]
        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public System.Nullable<DateTime> UpdateDate { get; set; }
        [Required]
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        
    }
}
