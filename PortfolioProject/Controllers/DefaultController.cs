using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();

        public ActionResult Index()
        {
            List<SelectListItem> values = (from x in context.Category
                                           where x.CategoryStatus == true
                                           select new SelectListItem
                                           {
                                               Text = x.CatagoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }

        [HttpPost]
        public ActionResult Index(Message message)
        {
            message.SendDate = DateTime.Parse(DateTime.Now.ToLongDateString());
            message.IsRead = false;
            context.Message.Add(message);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PartialHead()
        {
            ViewBag.PartialHeadTitle = context.Settings.Select(x => x.PartialHeadTitle).FirstOrDefault();
            ViewBag.PartialHeadKeywords = context.Settings.Select(x => x.PartialHeadKeywords).FirstOrDefault();
            ViewBag.PartialHeadDesription = context.Settings.Select(x => x.PartialHeadDescription).FirstOrDefault();

            return PartialView();
        }

        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }

        public PartialViewResult PartialHeader()
        {

            ViewBag.ProfileSideBarName = context.Settings.Select(x => x.ProfileSideBarName).FirstOrDefault();
            ViewBag.ProfileSideBarTitle = context.Settings.Select(x => x.ProfileSideBarTitle).FirstOrDefault();

            ViewBag.title = context.About.Select(x => x.Title).FirstOrDefault();
            ViewBag.detail = context.About.Select(x => x.Detail).FirstOrDefault();
            ViewBag.imageUrl = context.About.Select(x => x.ImageUrl).FirstOrDefault();

            ViewBag.address = context.Profile.Select(x => x.Address).FirstOrDefault();
            ViewBag.email = context.Profile.Select(x => x.Email).FirstOrDefault();
            ViewBag.phone = context.Profile.Select(x => x.PhoneNumber).FirstOrDefault();
            ViewBag.github = context.Profile.Select(x => x.Github).FirstOrDefault();

            var values = context.SocialMedia.Where(x => x.Status == true).ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialAbout()
        {
            ViewBag.AboutSideBarTitle = context.Settings.Select(x => x.AboutSideBarTitle).FirstOrDefault();

            ViewBag.title = context.Profile.Select(x => x.Title).FirstOrDefault();
            ViewBag.description = context.Profile.Select(x => x.Description).FirstOrDefault();
            ViewBag.phone = context.Profile.Select(x => x.PhoneNumber).FirstOrDefault();
            ViewBag.email = context.Profile.Select(x => x.Email).FirstOrDefault();
            ViewBag.imageUrl = context.Profile.Select(x => x.ImageUrl).FirstOrDefault();
            ViewBag.cv = context.Profile.Select(x => x.Cv).FirstOrDefault();

            return PartialView();
        }

        public PartialViewResult PartialEducation()
        {
            ViewBag.EducationSideBarTitle = context.Settings.Select(x => x.EducationSideBarTitle).FirstOrDefault();

            var values = context.Education.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialScript()
        {
            return PartialView();
        }

        public PartialViewResult PartialSkill()
        {
            ViewBag.SkillSideBarTitle = context.Settings.Select(x => x.SkillSideBarTitle).FirstOrDefault();

            var values = context.Skill.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialSocialMedia()
        {
            ViewBag.FooterNameSurname = context.Settings.Select(x => x.FooterNameSurname).FirstOrDefault();
            ViewBag.FooterTitle = context.Settings.Select(x => x.FooterTitle).FirstOrDefault();

            var values = context.SocialMedia.Where(x => x.Status == true).ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialExperience()
        {
            ViewBag.ExperienceSideBarTitle = context.Settings.Select(x => x.ExperienceSideBarTitle).FirstOrDefault();

            var values = context.Experience.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialMyProject()
        {
            ViewBag.WorkSideBarTitle = context.Settings.Select(x => x.WorkSideBarTitle).FirstOrDefault();

            var values = context.Work.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialTestimonial()
        {
            ViewBag.TestimonialSideBarTitle = context.Settings.Select(x => x.TestimonialSideBarTitle).FirstOrDefault();

            var values = context.Testimonial.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialService()
        {
            ViewBag.ServicesSidebarTitle = context.Settings.Select(x => x.ServicesSideBarTitle).FirstOrDefault();

            var values = context.Service.ToList();
            return PartialView(values);
        }

    }
}