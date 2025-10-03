using Microsoft.EntityFrameworkCore;
using MyHospital.Models;

namespace MyHospital.Data
{




    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; } 
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        

    }

}
