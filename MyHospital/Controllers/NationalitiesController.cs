using majed_asp_mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using MyHospital.Data;
using MyHospital.Interfaces;
using MyHospital.Models;

namespace MyHospital.Controllers
{
    [SessionAuthorize]
    public class NationalitiesController : Controller
    {

        //private readonly ApplicationDbContext _context;
        //public NationalitiesController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        private readonly IRepository<Nationality> _repositoryNationality;
        public NationalitiesController(IRepository<Nationality> repositoryNationality)
        {
            _repositoryNationality = repositoryNationality;
        }



        //----------------------------------------------------

        public IActionResult Index()
        {
            try
            {
                //IEnumerable<Nationality> nationalities = _context.Nationalities.ToList();
                IEnumerable<Nationality> nationalities = _repositoryNationality.GetAll();

                ////تحديث Uid 
                //foreach (var item in nationalities)
                //{
                //    item.Uid = Guid.NewGuid().ToString();

                //    _context.Nationalities.Update(item);
                //    _context.SaveChanges();
                //}

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
        [ValidateAntiForgeryToken]
        public IActionResult Create(Nationality nationality)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(nationality);
                }

                //_context.Nationalities.Add(nationality);
                //_context.SaveChanges();

                _repositoryNationality.Add(nationality);
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
            //var nationality = _context.Nationalities.Find(Id);
            //var nationality = _context.Nationalities.FirstOrDefault(e => e.Uid == Uid);
            var nationality = _repositoryNationality.GetByUId(Uid);
            return View(nationality);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Nationality nationality, string Uid)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(nationality);
                }

                //var n = _context.Nationalities.FirstOrDefault(e => e.Uid == Uid);
                var n = _repositoryNationality.GetByUId(Uid);
                if (n != null)
                {
                    n.Name = nationality.Name;

                    //_context.Nationalities.Update(n);
                    //_context.SaveChanges();

                    _repositoryNationality.Update(n);

                    return RedirectToAction("Index");
                }
                return View(nationality);

            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }


        [HttpGet]
        public IActionResult Delete(string Uid)
        {
            //var nationality = _context.Nationalities.Find(Id);
            //var nationality = _context.Nationalities.FirstOrDefault(e => e.Uid == Uid);
            var nationality = _repositoryNationality.GetByUId(Uid);
            return View(nationality);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Nationality nationality)
        {
            try
            {
                //var item = _context.Nationalities.FirstOrDefault(e => e.Uid == nationality.Uid);
                var item = _repositoryNationality.GetByUId(nationality.Uid);
                if (item != null)
                {
                    //_context.Nationalities.Remove(item);
                    //_context.SaveChanges();
                    
                    _repositoryNationality.Delete(item.Uid);

                    return RedirectToAction("Index");
                }
                return View(nationality);
            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }









    }
}
