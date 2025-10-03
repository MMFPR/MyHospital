using majed_asp_mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using MyHospital.Data;
using MyHospital.Models;

namespace MyHospital.Controllers
{
    [SessionAuthorize]
    public class FAQController : Controller
    {

        private readonly ApplicationDbContext _context;
        public FAQController(ApplicationDbContext context)
        {
            _context = context;
        }

        //----------------------------------------------------



        public IActionResult Index()
        {
            try
            {
                IEnumerable<FAQ> faq = _context.FAQs.ToList();
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
        public IActionResult Create(FAQ faq)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(faq);
                }

                _context.FAQs.Add(faq);
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
            var faq = _context.FAQs.Find(Id);
            return View(faq);
        }

        [HttpPost]
        public IActionResult Edit(FAQ faq)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(faq);
                }

                _context.FAQs.Update(faq);
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
            var faq = _context.FAQs.Find(Id);
            return View(faq);
        }

        [HttpPost]
        public IActionResult Delete(FAQ faq)
        {
            try
            {
                _context.FAQs.Remove(faq);
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
