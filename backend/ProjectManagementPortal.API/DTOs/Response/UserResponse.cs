using System.ComponentModel.DataAnnotations;

namespace ProjectManagementPortal.API.DTOs.Response
{
    public class UserResponse
    {
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? EmailId { get; set; }    //emailId will be username
        public string? PhoneNumber { get; set; }
        public string? Location { get; set; }

    }
}
