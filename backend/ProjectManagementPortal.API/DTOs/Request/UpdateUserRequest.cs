using System.ComponentModel.DataAnnotations;

namespace ProjectManagementPortal.API.DTOs.Request
{
    public class UpdateUserRequest
    {    
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Location { get; set; }
    }
}
