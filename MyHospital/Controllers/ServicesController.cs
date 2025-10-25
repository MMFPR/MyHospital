using majed_asp_mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using MyHospital.Data;
using MyHospital.Interfaces;
using MyHospital.Models;

namespace MyHospital.Controllers
{
    [SessionAuthorize]
    public class ServicesController : Controller
    {

        //private readonly ApplicationDbContext _context;
        //public ServicesController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        private readonly IRepository<Service> _repositoryService;
        public ServicesController(IRepository<Service> repositoryService)
        {
            _repositoryService = repositoryService;
        }


        //-----------------------------

        public IActionResult Index()
        {
            try
            {
                //IEnumerable<Service> services = _context.Services.ToList();
                IEnumerable<Service> services = _repositoryService.GetAll();


                ////تحديث Uid 
                //foreach (var item in services)
                //{
                //    item.Uid = Guid.NewGuid().ToString();
                //    _context.Services.Update(item);
                //    _context.SaveChanges();
                //}


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
        [ValidateAntiForgeryToken]
        public IActionResult Create(Service service)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(service);
                }

                //_context.Services.Add(service);
                //_context.SaveChanges();

                _repositoryService.Add(service);

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
            //var service = _context.Services.Find(Id);
            //var service = _context.Services.FirstOrDefault(e => e.Uid == Uid);
            var service = _repositoryService.GetByUId(Uid);
            return View(service);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Service service, string Uid)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(service);
                }

                //var s = _context.Services.FirstOrDefault(e => e.Uid == Uid);
                var s = _repositoryService.GetByUId(Uid);
                if (s != null)
                {
                    s.Name = service.Name;

                    //_context.Services.Update(s);
                    //_context.SaveChanges();

                    _repositoryService.Update(s);
                    return RedirectToAction("Index");
                }
                return View(service);
            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }


        [HttpGet]
        public IActionResult Delete(string Uid)
        {
            //var service = _context.Services.Find(Id);
            //var service = _context.Services.FirstOrDefault(e => e.Uid == Uid);
            var service = _repositoryService.GetByUId(Uid);
            return View(service);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Service service)
        {
            try
            {
                //var item = _context.Services.FirstOrDefault(e => e.Uid == service.Uid);
                var item = _repositoryService.GetByUId(service.Uid);
                if (item != null)
                {
                    //_context.Services.Remove(item);
                    //_context.SaveChanges();

                    _repositoryService.Delete(item.Uid);

                    return RedirectToAction("Index");
                }
                return View(service);
            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }















    }
}
