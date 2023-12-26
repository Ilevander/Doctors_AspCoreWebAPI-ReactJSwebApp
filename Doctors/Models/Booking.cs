namespace Doctors.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public string? Title { get; set; }
        public string? Type { get; set; }
        public int AppointmentId { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
    }
}
