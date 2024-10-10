using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class SettingsController : Controller
    {
        // GET: Settings
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();
        public ActionResult UpdateSettings()
        {
            int id = 1;
            var value = context.Settings.Find(id);
            return View(value); 
        }

        [HttpPost]
        public ActionResult UpdateSettings(Settings settings)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdateSettings");
            }
            int id = 1;
            var value = context.Settings.Find(id);

            value.ProfileSideBarName = settings.ProfileSideBarName;
            value.ProfileSideBarTitle = settings.ProfileSideBarTitle;
            value.AboutSideBarTitle = settings.AboutSideBarTitle;
            value.EducationSideBarTitle = settings.EducationSideBarTitle;
            value.ExperienceSideBarTitle = settings.ExperienceSideBarTitle;
            value.SkillSideBarTitle = settings.SkillSideBarTitle;
            value.ServicesSideBarTitle = settings.ServicesSideBarTitle;
            value.WorkSideBarTitle = settings.WorkSideBarTitle;
            value.TestimonialSideBarTitle = settings.TestimonialSideBarTitle;
            value.ContactSideBarTitle = settings.ContactSideBarTitle;
            value.FooterNameSurname = settings.FooterNameSurname;
            value.FooterTitle = settings.FooterTitle;
            value.PartialHeadTitle = settings.PartialHeadTitle;
            value.PartialHeadKeywords = settings.PartialHeadKeywords;
            value.PartialHeadDescription = settings.PartialHeadDescription;

            context.SaveChanges();
            return View(value);
        }
    }
}