using PortfolioProject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();
        public ActionResult AboutList()
        {
            var value = context.About.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var value = context.About.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdateAbout");
            }
            var value = context.About.Find(about.AboutId);
            value.Title = about.Title;
            value.Detail = about.Detail;
            value.ImageUrl = about.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("AboutList");
        }



    }
}