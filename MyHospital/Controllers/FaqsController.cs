using majed_asp_mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using MyHospital.Data;
using MyHospital.Interfaces;
using MyHospital.Models;

namespace MyHospital.Controllers
{
    [SessionAuthorize]
    public class FaqsController : Controller
    {

        //private readonly ApplicationDbContext _context;
        //public FaqsController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        private readonly IRepository<Faq> _repositoryFaq;
        public FaqsController(IRepository<Faq> repositoryFaq)
        {
            _repositoryFaq = repositoryFaq;
        }

        //----------------------------------------------------



        public IActionResult Index()
        {
            try
            {
                //IEnumerable<Faq> faq = _context.Faqs.ToList();
                IEnumerable<Faq> faq = _repositoryFaq.GetAll();

                //تحديث Uid 
                //foreach (var item in faq)
                //{
                //    item.Uid = Guid.NewGuid().ToString();

                //    _context.Faqs.Update(item);
                //    _context.SaveChanges();
                //}

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
        [ValidateAntiForgeryToken]
        public IActionResult Create(Faq faq)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(faq);
                }

                //_context.Faqs.Add(faq);
                //_context.SaveChanges();

                _repositoryFaq.Add(faq);
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
            //var faq = _context.Faqs.Find(Id);
            //var faq = _context.Faqs.FirstOrDefault(e => e.Uid == Uid);
            var faq = _repositoryFaq.GetByUId(Uid);
            return View(faq);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Faq faq, string Uid)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(faq);
                }

                //var f = _context.Faqs.FirstOrDefault(e => e.Uid == Uid);
                var f = _repositoryFaq.GetByUId(Uid);
                if (f != null)
                {
                    f.Question = faq.Question;
                    f.Answer = faq.Answer;

                    //_context.Faqs.Update(f);
                    //_context.SaveChanges();

                    _repositoryFaq.Update(f);
                    return RedirectToAction("Index");
                }
                return View(faq);
                
            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }


        [HttpGet]
        public IActionResult Delete(string Uid)
        {
            //var faq = _context.Faqs.Find(Id);
            //var faq = _context.Faqs.FirstOrDefault(e => e.Uid == Uid);
            var faq = _repositoryFaq.GetByUId(Uid);
            return View(faq);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Faq faq)
        {
            try
            {
                //var item = _context.Faqs.FirstOrDefault(e => e.Uid == faq.Uid);
                var item = _repositoryFaq.GetByUId(faq.Uid);
                if (item != null)
                {
                    //_context.Faqs.Remove(item);
                    //_context.SaveChanges();

                    _repositoryFaq.Delete(item.Uid);
                    return RedirectToAction("Index");
                }
                return View(faq);
            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }












    }
}
