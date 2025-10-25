using majed_asp_mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using MyHospital.Data;
using MyHospital.Interfaces;
using MyHospital.Models;

namespace MyHospital.Controllers
{
    [SessionAuthorize]
    public class JobsController : Controller
    {

        //private readonly ApplicationDbContext _context;
        //public JobsController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        private readonly IRepository<Job> _repositoryJob;
        public JobsController(IRepository<Job> repositoryJob)
        {
            _repositoryJob = repositoryJob;
        }


        //----------------------------------------------------


        public IActionResult Index()
        {
            try
            {
                //IEnumerable<Job> jobs = _context.Jobs.ToList();
                IEnumerable<Job> jobs = _repositoryJob.GetAll();

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

                //_context.Jobs.Add(jobs);
                //_context.SaveChanges();

                _repositoryJob.Add(jobs);
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
            //var jobs = _context.Jobs.FirstOrDefault(e => e.Uid == Uid);
            var jobs = _repositoryJob.GetByUId(Uid);
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

                //var job = _context.Jobs.FirstOrDefault(e => e.Uid == Uid);
                var job = _repositoryJob.GetByUId(Uid);
                if (job != null)
                {
                    job.Name = jobs.Name;

                    //_context.Jobs.Update(job);
                    //_context.SaveChanges();

                    _repositoryJob.Update(job);

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
            //var jobs = _context.Jobs.FirstOrDefault(e => e.Uid == Uid);
            var jobs = _repositoryJob.GetByUId(Uid);
            return View(jobs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Job jobs)
        {
            try
            {
                //var item = _context.Jobs.FirstOrDefault(e => e.Uid == jobs.Uid);
                var item = _repositoryJob.GetByUId(jobs.Uid);
                if (item != null)
                {
                    //_context.Jobs.Remove(item);
                    //_context.SaveChanges();

                    _repositoryJob.Delete(item.Uid);

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
