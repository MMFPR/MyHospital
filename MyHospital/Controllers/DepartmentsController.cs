using majed_asp_mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using MyHospital.Data;
using MyHospital.Interfaces;
using MyHospital.Models;

namespace MyHospital.Controllers
{
    [SessionAuthorize]

    public class DepartmentsController : Controller
    {

        //private readonly ApplicationDbContext _context;
        //public DepartmentsController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        private readonly IRepository<Department> _repositoryDepartment;

        public DepartmentsController(IRepository<Department> repositoryDepartment)
        {
            _repositoryDepartment = repositoryDepartment;
        }


        //----------------------------------------------------


        public IActionResult Index()
        {
            try
            {
                //IEnumerable<Department> depts = _context.Departments.ToList();
                IEnumerable<Department> depts = _repositoryDepartment.GetAll();

                ////تحديث Uid 
                //foreach (var item in depts)
                //{
                //    item.Uid = Guid.NewGuid().ToString();

                //    _context.Departments.Update(item);
                //    _context.SaveChanges();
                //}

                return View(depts);
            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }


        //---------------------------


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department dept)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(dept);
                }

                //_context.Departments.Add(dept);
                //_context.SaveChanges();

                _repositoryDepartment.Add(dept);

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
            //var dept = _context.Departments.Find(Id);
            //var dept = _context.Departments.FirstOrDefault(e => e.Uid == Uid);
            var dept = _repositoryDepartment.GetByUId(Uid);
            return View(dept);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Department dept, string Uid)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(dept);
                }

                //var department = _context.Departments.FirstOrDefault(e => e.Uid == Uid);
                var department = _repositoryDepartment.GetByUId(Uid);
                if (department != null)
                {
                    department.Name = dept.Name;
                    //_context.Departments.Update(department);
                    //_context.SaveChanges();

                    _repositoryDepartment.Update(department);
                    return RedirectToAction("Index");
                }
                return View(dept);

            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }


        [HttpGet]
        public IActionResult Delete(string Uid)
        {
            //var dept = _context.Departments.Find(Id);
            //var dept = _context.Departments.FirstOrDefault(e => e.Uid == Uid);
            var dept = _repositoryDepartment.GetByUId(Uid);
            return View(dept);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Department dept, string Uid)
        {
            try
            {
                //var department = _context.Departments.FirstOrDefault(e => e.Uid == dept.Uid);
                var department = _repositoryDepartment.GetByUId(Uid);
                if (department != null) 
                {
                    //_context.Departments.Remove(department);
                    //_context.SaveChanges();

                    _repositoryDepartment.Delete(dept.Uid);
                    return RedirectToAction("Index");
                }
                return View(dept);


            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }










    }
}
