using System.ComponentModel.DataAnnotations;

namespace ProjectManagementPortal.API.DTOs.Request
{
    public class RegisterUserRequest
    {
        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [EmailAddress]
        public string? EmailId { get; set; }    //emailId will be username

        [Required]
        public string? PhoneNumber { get; set; }

        [Required]
        public string? Location { get; set; }

        [Required]
        public int DesignationId { get; set; }
        
        [Required]
        public int DepartmentId { get; set; }
       
        [Required]
        public string? Password { get; set; }
    }
}
