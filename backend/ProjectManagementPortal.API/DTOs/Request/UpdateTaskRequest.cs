namespace ProjectManagementPortal.API.DTOs.Request
{
    public class UpdateTaskRequest
    {
        public int TaskId { get; set; }
        public string? TaskName { get; set; }
        public string? TaskDescription { get; set; }
        public bool IsActive { get; set; }
        public System.Nullable<DateTime> UpdateDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime DueDate { get; set; }
    }
}
