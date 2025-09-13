using System.ComponentModel.DataAnnotations;

namespace MyHospital.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }              // المفتاح الأساسي (Primary Key)
        public string Name { get; set; }         // اسم التصنيف
        public string Description { get; set; }  // وصف التصنيف (اختياري)
    }
}
