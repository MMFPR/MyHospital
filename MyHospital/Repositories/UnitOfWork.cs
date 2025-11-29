using MyHospital.Data;
using MyHospital.Interfaces;
using MyHospital.Models;

namespace MyHospital.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            _repositoryEmployee = new MainRepository<Employee>(_context);

        }







        public void Save()
        {
            _context.SaveChanges();
        }




    }
}
