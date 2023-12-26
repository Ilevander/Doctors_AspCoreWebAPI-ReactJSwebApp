namespace Doctors.Models
{
    public class Schedule
    {
        public int DoctorScheduleId { get; set; }
        public DateTime Time { get; set; }
        public string? Type { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public string? DoctorScheduleTime { get; internal set; }
        public string? DoctorScheduleType { get; internal set; }
        public DateTime? DoctorScheduleDate { get; internal set; }
        public string? DoctorScheduleDescription { get; internal set; }
    }
}
