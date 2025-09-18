using Microsoft.AspNetCore.Mvc;
using MyHospital.Data;
using MyHospital.Models;

namespace MyHospital.Controllers
{
    public class ServicesController : Controller
    {

        private readonly ApplicationDbContext _context;
        public ServicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        //-----------------------------

        public IActionResult Index()
        {
            try
            {
                IEnumerable<Service> services = _context.Services.ToList();
                return View(services);
            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }

        //-----------------------------


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Service service)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(service);
                }

                _context.Services.Add(service);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var service = _context.Services.Find(Id);
            return View(service);
        }

        [HttpPost]
        public IActionResult Edit(Service service)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(service);
                }

                _context.Services.Update(service);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }


        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var service = _context.Services.Find(Id);
            return View(service);
        }

        [HttpPost]
        public IActionResult Delete(Service service)
        {
            try
            {
                _context.Services.Remove(service);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }


        // صفحة الإدارة (قائمة جدوليّة لإدارة الفئات)
        [HttpGet]
        public IActionResult Manage()
        {
            try
            {
                IEnumerable<Service> service = _context.Services.ToList();
                return View(service);
            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }



    }
}
