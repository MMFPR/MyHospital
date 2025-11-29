using majed_asp_mvc.Filters;
using Microsoft.AspNetCore.Mvc;


namespace MyHospital.Controllers
{
    [SessionAuthorize]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public IActionResult Index()
        {
            var employees = _employeeService.GetAll();

            return View(employees);
        }
    }
}
