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
    public class WorkController : Controller
    {
        // GET: Work
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();
        public ActionResult WorkList(int page = 1)
        {
            var value = context.Work.ToList().ToPagedList(page,3);
            return View(value);
        }

        public ActionResult CreateWork() { 
            return View();
        }

        [HttpPost]  
        public ActionResult CreateWork(Work work)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateWork");
            }
            context.Work.Add(work);
            context.SaveChanges();
            return RedirectToAction("WorkList");
        }

        public ActionResult DeleteWork(int id) {
            var value = context.Work.Find(id);
            context.Work.Remove(value);
            context.SaveChanges();
            return RedirectToAction("WorkList");
        }

        public ActionResult UpdateWork(int id) { 
            var value = context.Work.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateWork(Work work)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdateWork");
            }
            var value = context.Work.Find(work.WorkId);
            value.Title = work.Title;
            value.Description = work.Description;
            value.ImageUrl = work.ImageUrl;
            value.GithubUrl = work.GithubUrl;
            context.SaveChanges();
            return RedirectToAction("WorkList");
        }
    }
}