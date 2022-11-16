using ProjectManagementPortal.DL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementPortal.BL.BL
{
    public class UserBL
    {
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

        [Required]
        public DateTime CreateDate { get; set; }

        public int UserId { get; set; }

    }
}
