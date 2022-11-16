using System.ComponentModel.DataAnnotations;

namespace ProjectManagementPortal.API.DTOs.Request
{
    public class TaskAssignmentRequest
    {
        [Required]
        public int UserId { get; set; }
    }
}
