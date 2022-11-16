using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementPortal.DL.Entities
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectId { get; set; }
        [Required]
        public string? ProjectName { get; set; }
        [Required]
        public string? ProjectDescription { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [ForeignKey("ProjectMaster")]
        public System.Nullable<int> ProjectMasterId { get; set; } = 1;
        public ProjectMaster? ProjectMaster { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public System.Nullable<DateTime> UpdateDate { get; set; }
        [Required]
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public string? ClientName { get; set; }
        public string? GoalOfProject { get; set; }
        public string? TechnologiesUsed { get; set; }
    }
}
