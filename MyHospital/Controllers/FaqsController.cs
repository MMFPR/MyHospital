using majed_asp_mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using MyHospital.Data;
using MyHospital.Models;

namespace MyHospital.Controllers
{
    [SessionAuthorize]
    public class FaqsController : Controller
    {

        private readonly ApplicationDbContext _context;
        public FaqsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //----------------------------------------------------



        public IActionResult Index()
        {
            try
            {
                IEnumerable<Faq> faq = _context.Faqs.ToList();
                return View(faq);
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
        public IActionResult Create(Faq faq)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(faq);
                }

                _context.Faqs.Add(faq);
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
            var faq = _context.Faqs.Find(Id);
            return View(faq);
        }

        [HttpPost]
        public IActionResult Edit(Faq faq)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(faq);
                }

                _context.Faqs.Update(faq);
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
            var faq = _context.Faqs.Find(Id);
            return View(faq);
        }

        [HttpPost]
        public IActionResult Delete(Faq faq)
        {
            try
            {
                _context.Faqs.Remove(faq);
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
