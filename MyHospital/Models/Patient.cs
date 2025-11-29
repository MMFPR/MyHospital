using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHospital.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        public string Uid { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string NationalId { get; set; }
        public string BloodType { get; set; }
        public string EmergencyContact { get; set; }


        [ForeignKey("Nationality")]
        public int? NationalityId { get; set; }
        public Nationality? Nationality { get; set; }


    }
}
