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
        [ValidateAntiForgeryToken]
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
        public IActionResult Edit(string Uid)
        {
            //var category = _context.Categories.Find(Id);
            var category = _context.Categories.FirstOrDefault(e=>e.Uid == Uid);
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category, string Uid)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(category);
                }
                var cate= _context.Categories.FirstOrDefault(e => e.Uid == Uid);
                if (cate != null) 
                { 
                    cate.Name = category.Name;
                    cate.Description = category.Description;
                    _context.Categories.Update(cate);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(category);

            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }


        [HttpGet]
        public IActionResult Delete(string Uid)
        {
            //var category = _context.Categories.Find(Id);
            var category = _context.Categories.FirstOrDefault(e => e.Uid == Uid);
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category category)
        {
            try
            {
                var cate = _context.Categories.FirstOrDefault(e => e.Uid == category.Uid);
                if (cate != null) 
                {
                    _context.Categories.Remove(cate);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(category);

            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }





















    }
}
