using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementPortal.DL.Entities
{
    public class ProjectMaster
    {
        [Key]
        public int ProjectMasterId { get; set; }
        [Required]
        public string? ProjectStatus { get; set; }
    }
}
