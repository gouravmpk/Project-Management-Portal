namespace ProjectManagementPortal.API.DTOs.Request
{
    public class UpdateProjectRequest
    {
        public int ProjectId { get; set; }
        public string? ProjectName { get; set; }

        public string? ProjectDescription { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; }

        public System.Nullable<DateTime> UpdateDate { get; set; }

        public int UpdatedBy { get; set; }
    }
}
