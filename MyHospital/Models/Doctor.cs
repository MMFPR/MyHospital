using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHospital.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        public string Uid { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }
        public string NationalId { get; set; }

        public string Specialty { get; set; }   // التخصص الطبي
        public string LicenseNumber { get; set; } // رقم رخصة مزاولة المهنة

        // 🔵 العلاقة مع قسم المستشفى (Department)
        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }

        // 🔵 العلاقة مع الجنسيات (Nationality)
        [ForeignKey("Nationality")]
        public int? NationalityId { get; set; }
        public Nationality? Nationality { get; set; }
    }
}
