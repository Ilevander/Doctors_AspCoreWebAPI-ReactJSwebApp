namespace Doctors.Models
{
    public class Fees
    {
        public int DoctorFeeId { get; set; }
        public int DoctorId { get; set; }
        public decimal Amount { get; set; }
        public decimal Total { get; set; }
        public string? Payment { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public object? DoctorFeeAmount { get; internal set; }
        public object? DoctorFeeTotal { get; internal set; }
        public object? DoctorFeePayment { get; internal set; }
        public object? DoctorFeeType { get; internal set; }
        public object? DoctorFeeDescription { get; internal set; }
        public object Name { get; internal set; }
    }
}
