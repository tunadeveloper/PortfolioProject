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
    public class TestimonialController : Controller
    {
        // GET: Testimonial
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();
        public ActionResult TestimonialList(int page = 1)
        {
            var value = context.Testimonial.ToList().ToPagedList(page,3);
            return View(value);
        }

        public ActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTestimonial(Testimonial testimonial)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateTestimonial");
            }
            context.Testimonial.Add(testimonial);
            context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }

        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var value = context.Testimonial.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateTestimonial(Testimonial testimonial)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdateTestimonial");
            }
            var value = context.Testimonial.Find(testimonial.TestimonialId);
            value.NameSurname = testimonial.NameSurname;
            value.Title = testimonial.Title;
            value.Comment = testimonial.Comment;
            value.ImageUrl = testimonial.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }

        public ActionResult DeleteTestimonial(int id) {
            var value = context.Testimonial.Find(id);
            context.Testimonial.Remove(value);
            context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }


    }
}