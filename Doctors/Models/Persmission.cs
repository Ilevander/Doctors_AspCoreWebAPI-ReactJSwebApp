namespace Doctors.Models
{
    public class Permission
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string? Title { get; set; }
        public string? Module { get; set; }
        public string? Description { get; set; }
    }
}
