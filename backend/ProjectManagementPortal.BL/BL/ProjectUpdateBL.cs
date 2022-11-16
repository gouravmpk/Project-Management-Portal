using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementPortal.BL.BL
{
    public class ProjectUpdateBL
    {

        public int ProjectId { get; set; }
        public string? ProjectName { get; set; }

        public string? ProjectDescription { get; set; }

        public DateTime EndDate { get; set; }


        public bool IsActive { get; set; }

        public DateTime? UpdateDate { get; set; }

        public int UpdatedBy { get; set; }
    }
}
