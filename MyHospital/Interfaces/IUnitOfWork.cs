using MyHospital.Models;

namespace MyHospital.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Employee> _repositoryEmployee { get; }

    }
}
