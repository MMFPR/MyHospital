using System.ComponentModel.DataAnnotations;

namespace MyHospital.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
