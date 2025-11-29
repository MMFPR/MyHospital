using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHospital.Models
{
    public class RoomAndBed
    {
        [Key]
        public int Id { get; set; }
        public string Uid { get; set; } = Guid.NewGuid().ToString();

        public string RoomNumber { get; set; }       // رقم الغرفة
        public string BedNumber { get; set; }        // رقم السرير داخل الغرفة

        public string RoomType { get; set; }         // نوع الغرفة (General, ICU, VIP, Isolation)
        public string Status { get; set; }           // Available, Occupied, Cleaning, Maintenance

        public string? Notes { get; set; }           // ملاحظات 

        // 🔵العلاقة مع المريض إذا كان السرير محجوزًا
        [ForeignKey("Patient")]
        public int? PatientId { get; set; }
        public Patient? Patient { get; set; }
    }
}
