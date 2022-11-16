using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementPortal.BL.BL
{
    public class GetUserBL
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string? EmailId { get; set; }    //emailId will be username


        public string? PhoneNumber { get; set; }

        public string? Location { get; set; }
        public int? UserId { get; set; }



    }
}
