using Microsoft.EntityFrameworkCore;
using MyHospital.Models;

namespace MyHospital.Data
{




    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // ========== الجداول الإدارية ==========
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }

        // ========== الجداول العامة ==========
        public DbSet<Category> Categories { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Faq> Faqs { get; set; }

        // ========== المرضى ==========
        public DbSet<Patient> Patients { get; set; }

        // ========== الأطباء ==========
        public DbSet<Doctor> Doctors { get; set; }

        // ========== التمريض ==========
        public DbSet<Nurse> Nurses { get; set; }

        // ========== المواعيد ==========
        public DbSet<Appointment> Appointments { get; set; }

        // ========== التحاليل المختبرية ==========
        public DbSet<LabTest> LabTests { get; set; }

        // ========== الوصفات الطبية ==========
        public DbSet<Prescription> Prescriptions { get; set; }

        // ========== الغرف والأسرة ==========
        public DbSet<RoomAndBed> RoomsAndBeds { get; set; }

        // ========== الفواتير ==========
        public DbSet<Invoice> Invoices { get; set; }


    }

}
