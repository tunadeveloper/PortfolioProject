using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
namespace PortfolioProject.Controllers
{
    public class EducationController : Controller
    {
        // GET: Education
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();

        
        public ActionResult EducationList(int page = 1)
        {
            var value = context.Education.ToList().ToPagedList(page,3);
            return View(value);
        }

        public ActionResult CreateEducation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEducation(Education education)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateEducation");
            }
            var value = context.Education.Add(education);
            context.SaveChanges();
            return RedirectToAction("EducationList");
        }


        public ActionResult UpdateEducation(int id)
        {
            var value = context.Education.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateEducation(Education education)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdateEducation");
            }
            var value = context.Education.Find(education.EducationId);
            value.Title = education.Title;
            value.EducationDate = education.EducationDate;
            value.Subtitle = education.Subtitle;
            value.Description = education.Description;
            context.SaveChanges();
            return RedirectToAction("EducationList");
        }

        public ActionResult DeleteEducation(int id)
        {
            var value = context.Education.Find(id);
            context.Education.Remove(value);
            context.SaveChanges();
            return RedirectToAction("EducationList");
        }
    }
}