using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHospital.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        public string Uid { get; set; } = Guid.NewGuid().ToString();

        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Status { get; set; }  // Pending, Confirmed, Cancelled, Completed
        public string? Notes { get; set; }

        // 🔵 العلاقة مع المريض
        [ForeignKey("Patient")]
        public int? PatientId { get; set; }
        public Patient? Patient { get; set; }

        // 🔵 العلاقة مع الطبيب
        [ForeignKey("Doctor")]
        public int? DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
    }
}
