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
    public class SocialMediaController : Controller
    {
        // GET: SocialMedia
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();
        public ActionResult SocialMediaList(int page = 1)
        {
            var value = context.SocialMedia.ToList().ToPagedList(page,5);
            return View(value);
        }
        public ActionResult ActiveSocialMedia(int id)
        {
            var value = context.SocialMedia.Where(x => x.SocialMediaId == id).FirstOrDefault();
            value.Status = true;
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

        public ActionResult PassiveSocialMedia(int id)
        {
            var value = context.SocialMedia.Where(x => x.SocialMediaId == id).FirstOrDefault();
            value.Status = false;
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

        public ActionResult CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSocialMedia(SocialMedia socialMedia)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateSocialMedia");
            }
            context.SocialMedia.Add(socialMedia);
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

        public ActionResult UpdateSocialMedia(int id)
        {
            var value = context.SocialMedia.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateSocialMedia(SocialMedia socialMedia)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdateSocialMedia");
            }
            var value = context.SocialMedia.Find(socialMedia.SocialMediaId);
            value.Title = socialMedia.Title;
            value.Icon = socialMedia.Icon;
            value.SocialMediaUrl = socialMedia.SocialMediaUrl;
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

        public PartialViewResult SocialMediaIcon()
        {
            return PartialView();
        }
       
    }
}