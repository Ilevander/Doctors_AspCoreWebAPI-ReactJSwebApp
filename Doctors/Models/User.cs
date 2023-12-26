namespace Doctors.Models
{
    public class User
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateTime Date { get; set; }
        public string? Address { get; set; }
    }
}
