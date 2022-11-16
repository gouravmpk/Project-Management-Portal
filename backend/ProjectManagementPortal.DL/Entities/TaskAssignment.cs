using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementPortal.DL.Entities
{
    public class TaskAssignment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskAssignmentId { get; set; }
        [ForeignKey("User")]
        [Required]
        public int UserId { get; set; }
        public User? User { get; set; }
        [Required]
        [ForeignKey("Task")]
        public int TaskId { get; set; }
        public Tasks? Tasks { get; set; }
    }
}
