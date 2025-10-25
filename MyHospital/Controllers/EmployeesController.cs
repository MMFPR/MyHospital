using majed_asp_mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyHospital.Data;
using MyHospital.Interfaces;
using MyHospital.Models;
using System;
using System.Security.Cryptography;


namespace MyHospital.Controllers
{
    [SessionAuthorize]
    public class EmployeesController : Controller
    {

        //private readonly ApplicationDbContext _context;
        //public EmployeesController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        private readonly IRepository<Employee> _repositoryEmployee;

        public EmployeesController(IRepository<Employee> repositoryEmployee)
        {
            _repositoryEmployee = repositoryEmployee;
        }


        //----------------------------------------------------


        public IActionResult Index()
        {
            try
            {
                //IEnumerable<Employee> emp = _context.Employees.Include(e => e.Department).Include(j => j.Job).Include(n => n.Nationality).ToList();
                IEnumerable<Employee> emp = _repositoryEmployee.GetAll();

                // //تحديث Uid 
                //foreach(var item in emp)
                //{
                //    //item.Uid = Guid.NewGuid().ToString();
                //    // تحديث التاريخ الانشاء
                //    item.CreatAccount = DateTime.Now;
                //    _context.Employees.Update(item);
                //    _context.SaveChanges();
                //}

                return View(emp);

            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }


        //---------------------------

        private void SetDeptViewBag()
        {
            //IEnumerable<Department> dapts = _context.Departments.ToList();
            IEnumerable<Department> dapts = _repositoryEmployee.GetAll()
                .Select(e => e.Department)
                .Distinct()
                .ToList();
            SelectList selectListItems = new SelectList(dapts, "Id", "Name");
            ViewBag.Departments = selectListItems;
        }

        private void SetNationalityViewBag()
        {
            //IEnumerable<Nationality> nationality = _context.Nationalities.ToList();
            IEnumerable<Nationality> nationality = _repositoryEmployee.GetAll()
                .Select(e => e.Nationality).Distinct().ToList();


            SelectList selectListItems = new SelectList(nationality, "Id", "Name");
            ViewBag.Nationalities = selectListItems;
        }

        private void SetJobViewBag()
        {
            //IEnumerable<Job> job = _context.Jobs.ToList();
            IEnumerable<Job> job = _repositoryEmployee.GetAll()
                .Select(e => e.Job).Distinct().ToList();
            SelectList selectListItems = new SelectList(job, "Id", "Name");
            ViewBag.Jobs = selectListItems;
        }


        //------------------------


        [HttpGet]
        public IActionResult Create()
        {
            SetNationalityViewBag();
            SetJobViewBag();
            SetDeptViewBag();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee emp)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(emp);
                }

                //_context.Employees.Add(emp);
                //_context.SaveChanges();

                _repositoryEmployee.Add(emp);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }

        [HttpGet]
        public IActionResult Edit(string Uid)
        {
            //var emp = _context.Employees.Find(Id);
            //var emp = _context.Employees.FirstOrDefault(e => e.Uid == Uid);
            var emp = _repositoryEmployee.GetByUId(Uid);

            SetNationalityViewBag();
            SetJobViewBag();
            SetDeptViewBag();
            return View(emp);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee emp, string Uid)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    SetNationalityViewBag();
                    SetJobViewBag();
                    SetDeptViewBag();
                    return View(emp);
                }

                //var employee = _context.Employees.FirstOrDefault(e => e.Uid == Uid);
                var employee = _repositoryEmployee.GetByUId(Uid);
                if (employee != null)
                {
                    employee.Name = emp.Name;
                    employee.Gender = emp.Gender;
                    employee.JobId = emp.JobId;
                    employee.NationalityId = emp.NationalityId;
                    employee.Email = emp.Email;
                    employee.Phone = emp.Phone;
                    employee.Address = emp.Address;
                    employee.Salary = emp.Salary;
                    employee.DepartmentId = emp.DepartmentId;

                    //_context.Employees.Update(employee);
                    //_context.SaveChanges();

                    _repositoryEmployee.Update(employee);

                    return RedirectToAction("Index");
                }
                return View(emp);
                //_context.Employees.Update(emp);
                //_context.SaveChanges();
                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }


        [HttpGet]
        public IActionResult Delete(string Uid)

        {
            //var emp = _context.Employees.Find(Id);
            //var emp = _context.Employees
            //            .Include(e => e.Department)
            //            .Include(e => e.Job)
            //            .Include(e => e.Nationality)
            //            .FirstOrDefault(e => e.Uid == Uid);
            var emp = _repositoryEmployee.GetByUId(Uid);
            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Employee emp)
        {
            try
            {
                //var employee = _context.Employees.FirstOrDefault(e => e.Uid == emp.Uid);
                var employee = _repositoryEmployee.GetByUId(emp.Uid);
                if (employee != null) 
                {
                    //_context.Employees.Remove(employee);
                    //_context.SaveChanges();

                    _repositoryEmployee.Delete(employee.Uid);
                    return RedirectToAction("Index");
                }
                return View(emp);

            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }








    }
}
