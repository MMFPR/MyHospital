using majed_asp_mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using MyHospital.Data;
using MyHospital.Models;

namespace MyHospital.Controllers
{
    [SessionAuthorize]

    public class DepartmentsController : Controller
    {

        private readonly ApplicationDbContext _context;
        public DepartmentsController(ApplicationDbContext context)
        {
            _context = context;
        }


        //----------------------------------------------------


        public IActionResult Index()
        {
            try
            {
                IEnumerable<Department> depts = _context.Departments.ToList();

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

                _context.Departments.Add(dept);
                _context.SaveChanges();
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
            var dept = _context.Departments.FirstOrDefault(e => e.Uid == Uid);
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

                var department = _context.Departments.FirstOrDefault(e => e.Uid == Uid);
                if (department != null)
                {
                    department.Name = dept.Name;
                    _context.Departments.Update(department);
                    _context.SaveChanges();
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
            var dept = _context.Departments.FirstOrDefault(e => e.Uid == Uid);
            return View(dept);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Department dept)
        {
            try
            {
                var department = _context.Departments.FirstOrDefault(e => e.Uid == dept.Uid);
                if (department != null) 
                {
                    _context.Departments.Remove(department);
                    _context.SaveChanges();
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
