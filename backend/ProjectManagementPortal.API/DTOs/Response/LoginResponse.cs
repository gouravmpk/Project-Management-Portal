namespace ProjectManagementPortal.API.DTOs.Response
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public DateTime Expiry { get; set; }
        public bool IsAdmin { get; set; }

    }
}
