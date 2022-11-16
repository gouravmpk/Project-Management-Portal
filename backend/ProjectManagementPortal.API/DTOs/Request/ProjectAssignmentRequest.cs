using System.ComponentModel.DataAnnotations;

namespace ProjectManagementPortal.API.DTOs.Request
{
    public class ProjectAssignmentRequest
    {
        [Required]
        public int UserId { get; set; }

    }
}
