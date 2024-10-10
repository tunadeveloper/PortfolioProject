using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
namespace PortfolioProject.Controllers
{

    public class CategoryController : Controller
    {
        // GET: Category
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();
        public ActionResult CategoryList(int page = 1)
        {
            var value = context.Category.ToList().ToPagedList(page, 5);
            return View(value);
        }

        public ActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateCategory");
            }
            context.Category.Add(category);
              context.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        public ActionResult UpdateCategory(int id)
        {
           var value = context.Category.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdateCategory");
            }
            var value = context.Category.Find(category.CategoryId);
            value.CatagoryName = category.CatagoryName;
            context.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        public ActionResult ActiveCategory(int id)
        {
            var value = context.Category.Where(x => x.CategoryId == id).FirstOrDefault();
            value.CategoryStatus = true;
            context.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        public ActionResult PassiveCategory(int id)
        {
            var value = context.Category.Where(x => x.CategoryId == id).FirstOrDefault();
            value.CategoryStatus = false;
            context.SaveChanges();
            return RedirectToAction("CategoryList");
        }

    }
}