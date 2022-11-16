using ProjectManagementPortal.DL.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagementPortal.API.DTOs.Response
{
    public class TaskResponse
    {
        
        public string? TaskName { get; set; }
        public string? TaskDescription { get; set; }

        public int ProjectId { get; set; }
        public bool IsActive { get; set; }
        
        public DateTime DueDate { get; set; }
        public string? TaskStatus { get; set; }

        public int TaskMembers { get; set; }
        public int TaskMasterId { get; set; }
        public int TaskId { get; set; }
        public List<string>? TaskMembersName { get; set; }
        public string? ProjectName { get; set; }

    }
}
