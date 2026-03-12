namespace CSI402.ViewModels
{
    public class ProjectUserViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string Role { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

}