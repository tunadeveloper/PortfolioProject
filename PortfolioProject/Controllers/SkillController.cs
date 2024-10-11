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

    public class SkillController : Controller
    {
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();
        // GET: Skill
        public ActionResult SkillList(int page = 1)
        {
            var values = context.Skill.ToList().ToPagedList(page, 5);
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateSkill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSkill(Skill skill)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateSkill");
            }
            context.Skill.Add(skill);
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }

        public ActionResult DeleteSkill(int id)
        {
            var value = context.Skill.Find(id);
            context.Skill.Remove(value);
            context.SaveChanges();
            return RedirectToAction("SkillList");

        }

        public ActionResult UpdateSkill(int id)
        {
            var value = context.Skill.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateSkill(Skill skill)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdateSkill");
            }
            var value = context.Skill.Find(skill.SkillId);
            value.Title = skill.Title;
            value.Icon = skill.Icon;
            value.Value = skill.Value;
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }
       
        public PartialViewResult SkillIcon()
        {
            return PartialView();
        }

    }
}