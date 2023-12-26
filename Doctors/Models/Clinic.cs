namespace Doctors.Models
{
    public class Clinic
    {
        public int ClinicId { get; set; }
        public int DoctorId { get; set; }
        public string? Name { get; set; }
        public string? Place { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public object? ClinicName { get; internal set; }
        public object? ClinicPlace { get; internal set; }
        public object? ClinicType { get; internal set; }
        public object? ClinicDescription { get; internal set; }
    }
}
