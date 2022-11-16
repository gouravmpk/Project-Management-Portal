using ProjectManagementPortal.DL.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagementPortal.API.DTOs.Request
{
    public class TaskRequest
    {
        
        public string? TaskName { get; set; }   
        public string? TaskDescription { get; set; }         
        public int ProjectId { get; set; }     
        public bool IsActive { get; set; }     
        public DateTime DueDate { get; set; }


        
    }
}
