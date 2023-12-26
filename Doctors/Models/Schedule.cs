namespace Doctors.Models
{
    public class Schedule
    {
        public int DoctorScheduleId { get; set; }
        public DateTime Time { get; set; }
        public string? Type { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public object? DoctorScheduleTime { get; internal set; }
        public object? DoctorScheduleType { get; internal set; }
        public object? DoctorScheduleDate { get; internal set; }
        public object? DoctorScheduleDescription { get; internal set; }
    }
}
