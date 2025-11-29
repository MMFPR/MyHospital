using MyHospital.Dtos;
using MyHospital.Models;

namespace MyHospital.Interfaces.IServices
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        Employee GetByUid(string uid);

        bool IsEmailExist(string email);
        void Create(Employee user);
        void Update(Employee user);
        void Delete(Employee id);

        Employee GetByEmailAndPassword(LoginRequestDto loginRequest);
    }
}
