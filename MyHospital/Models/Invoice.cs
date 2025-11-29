using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHospital.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        public string Uid { get; set; } = Guid.NewGuid().ToString();

        public DateTime Date { get; set; } = DateTime.Now;   // تاريخ الفاتورة

        public decimal TotalAmount { get; set; }             // مجموع الفاتورة
        public decimal PaidAmount { get; set; }              // المبلغ المدفوع
        public decimal RemainingAmount { get; set; }         // المتبقي

        public string PaymentMethod { get; set; }            // Cash, Card, Insurance
        public string Status { get; set; }                   // Paid, Unpaid, PartiallyPaid

        public string? Notes { get; set; }

        // 🔵 العلاقة مع المريض
        [ForeignKey("Patient")]
        public int? PatientId { get; set; }
        public Patient? Patient { get; set; }

        // 🔵 العلاقة مع الطبيب
        [ForeignKey("Doctor")]
        public int? DoctorId { get; set; }
        public Doctor? Doctor { get; set; }

        // 🔵 العلاقة مع الموظف الذي قام بتسجيل الفاتورة
        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}
