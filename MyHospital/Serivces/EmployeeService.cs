using MyHospital.Dtos;
using MyHospital.Interfaces;
using MyHospital.Interfaces.IServices;
using MyHospital.Models;

namespace MyHospital.Serivces
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(Employee employee)
        {
            _unitOfWork._repositoryEmployee.Add(employee);
            _unitOfWork.Save();
        }

        public void Update(Employee employee)
        {
            _unitOfWork._repositoryUser.Update(employee);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork._repositoryUser.Delete(id);
            _unitOfWork.Save();
        }

        public IEnumerable<Employee> GetAll()
        {
            return _unitOfWork._repositoryUser.GetAll();
        }

        //public User GetByEmailAndPassword(string email, string password)
        //{
        //    return _unitOfWork._repositoryUser.GetAll().FirstOrDefault(u => u.Email == email && u.Password == password);
        //}

        public Employee GetByEmailAndPassword(LoginRequestDto loginRequest)
        {
            return _unitOfWork._repositoryUser.GetAll().FirstOrDefault(u => u.Email == loginRequest.Email && u.Password == loginRequest.Password);
        }


        public Employee GetById(int id)
        {
            return _unitOfWork._repositoryUser.GetById(id);
        }

        public Employee? GetByUid(string uid)
        {
            return _unitOfWork._repositoryUser.GetByUId(uid);
        }


        public bool IsEmailExist(string email)
        {
            return _unitOfWork._repositoryUser.GetAll().Any(u => u.Email == email);
        }

    }
}
