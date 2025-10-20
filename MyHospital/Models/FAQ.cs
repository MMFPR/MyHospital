using System.ComponentModel.DataAnnotations;

namespace MyHospital.Models
{
    public class Faq
    {
        [Key]
        public int Id { get; set; }
        public string Uid { get; set; } = Guid.NewGuid().ToString();
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
