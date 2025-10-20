using majed_asp_mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using MyHospital.Data;
using MyHospital.Models;

namespace MyHospital.Controllers
{
    [SessionAuthorize]
    public class CategoriesController : Controller
    { 

        private readonly ApplicationDbContext _context;
        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        //----------------------------------------------------



        public IActionResult Index()
        {
            try
            {
                IEnumerable<Category> categories = _context.Categories.ToList();

                ////تحديث Uid 
                //foreach (var item in categories)
                //{
                //    item.Uid = Guid.NewGuid().ToString();
                //    _context.Categories.Update(item);
                //    _context.SaveChanges();
                //}

                return View(categories);
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
        public IActionResult Create(Category category)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(category);
                }

                _context.Categories.Add(category);
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
            var category = _context.Categories.Find(Id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(category);
                }

                _context.Categories.Update(category);
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
            var category = _context.Categories.Find(Id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(Category category)
        {
            try
            {
                _context.Categories.Remove(category);
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
                IEnumerable<Category> categories = _context.Categories.ToList();
                return View(categories);
            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }





    }
}
