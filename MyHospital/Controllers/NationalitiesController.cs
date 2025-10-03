using majed_asp_mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using MyHospital.Data;
using MyHospital.Models;

namespace MyHospital.Controllers
{
    [SessionAuthorize]
    public class NationalitiesController : Controller
    {

        private readonly ApplicationDbContext _context;
        public NationalitiesController(ApplicationDbContext context)
        {
            _context = context;
        }


        //----------------------------------------------------

        public IActionResult Index()
        {
            try
            {
                IEnumerable<Nationality> nationalities = _context.Nationalities.ToList();
                return View(nationalities);
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
        public IActionResult Create(Nationality nationality)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(nationality);
                }

                _context.Nationalities.Add(nationality);
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
            var nationality = _context.Nationalities.Find(Id);
            return View(nationality);
        }

        [HttpPost]
        public IActionResult Edit(Nationality nationality)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(nationality);
                }

                _context.Nationalities.Update(nationality);
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
            var nationality = _context.Nationalities.Find(Id);
            return View(nationality);
        }

        [HttpPost]
        public IActionResult Delete(Nationality nationality)
        {
            try
            {
                _context.Nationalities.Remove(nationality);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }









    }
}
