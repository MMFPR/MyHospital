using majed_asp_mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using MyHospital.Data;
using MyHospital.Models;

namespace MyHospital.Controllers
{
    [SessionAuthorize]
    public class JobsController : Controller
    {

        private readonly ApplicationDbContext _context;
        public JobsController(ApplicationDbContext context)
        {
            _context = context;
        }


        //----------------------------------------------------


        public IActionResult Index()
        {
            try
            {
                IEnumerable<Job> jobs = _context.Jobs.ToList();

                ////تحديث Uid 
                //foreach (var item in jobs)
                //{
                //    item.Uid = Guid.NewGuid().ToString();
                //    _context.Jobs.Update(item);
                //    _context.SaveChanges();
                //}
                return View(jobs);
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
        public IActionResult Create(Job jobs)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(jobs);
                }

                _context.Jobs.Add(jobs);
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
            //var jobs = _context.Jobs.Find(Id);
            var jobs = _context.Jobs.FirstOrDefault(e => e.Uid == Uid);
            return View(jobs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Job jobs, string Uid)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(jobs);
                }

                var job = _context.Jobs.FirstOrDefault(e => e.Uid == Uid);
                if (job != null)
                {
                    job.Name = jobs.Name;

                    _context.Jobs.Update(job);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(jobs);
            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }


        [HttpGet]
        public IActionResult Delete(string Uid)
        {
            //var jobs = _context.Jobs.Find(Id);
            var jobs = _context.Jobs.FirstOrDefault(e => e.Uid == Uid);
            return View(jobs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Job jobs)
        {
            try
            {
                var item = _context.Jobs.FirstOrDefault(e => e.Uid == jobs.Uid);
                if (item != null)
                {
                    _context.Jobs.Remove(item);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(jobs);
            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }










    }
}
