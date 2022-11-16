using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementPortal.DL.Entities
{
    public class User
    {
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
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
        [ForeignKey("Designation")]
        public int DesignationId { get; set; }
        public Designation? Designation { get; set; }
        [Required]
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        [Required]
        public string? Password { get; set; }

        [DefaultValue("true")]
        public bool IsActive { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }        
        public System.Nullable<DateTime> UpdateDate { get; set; }
              

    }
}
