namespace MyHospital.Interfaces.IServices
{
    public interface IEmployeeRepo : IRepository<Employee>
    {
        IEnumerable<Employee>
    }
}
