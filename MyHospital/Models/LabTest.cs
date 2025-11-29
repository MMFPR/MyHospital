using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHospital.Models
{
    public class LabTest
    {
        [Key]
        public int Id { get; set; }
        public string Uid { get; set; } = Guid.NewGuid().ToString();

        public string TestName { get; set; }            // اسم التحليل (CBC, Glucose...)
        public string? Result { get; set; }             // النتيجة النصية
        public string? Notes { get; set; }              // ملاحظات المختبر

        // ⏱️ وقت سحب العينة
        public DateTime SampleCollectionTime { get; set; } = DateTime.Now;

        // ⏱️ وقت ظهور النتيجة
        public DateTime? ResultTime { get; set; }

        // 🔵 نوع التحليل داخلي أو خارجي
        public string TestType { get; set; }    // "Internal" أو "External"

        // 🔵 العلاقة مع المريض
        [ForeignKey("Patient")]
        public int? PatientId { get; set; }
        public Patient? Patient { get; set; }

        // 🔵 العلاقة مع الطبيب الذي طلب التحليل
        [ForeignKey("Doctor")]
        public int? DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
    }
}
