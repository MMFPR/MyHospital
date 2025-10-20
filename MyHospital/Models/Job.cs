using System.ComponentModel.DataAnnotations;

namespace MyHospital.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
        public string Uid { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public ICollection<Employee>? Employees { get; set; }
    }



}
