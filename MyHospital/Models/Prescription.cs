using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHospital.Models
{
    public class Prescription
    {
        [Key]
        public int Id { get; set; }
        public string Uid { get; set; } = Guid.NewGuid().ToString();

        public DateTime Date { get; set; } = DateTime.Now;   // تاريخ كتابة الوصفة

        public string MedicationName { get; set; }           // اسم الدواء
        public string Dosage { get; set; }                   // الجرعة مثال: 1 قرص مرتين يومياً
        public string Instructions { get; set; }             // تعليمات الاستخدام
        public int DurationDays { get; set; }               // مدة العلاج بالأيام 

        public string? Notes { get; set; }                   // ملاحظات إضافية

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
