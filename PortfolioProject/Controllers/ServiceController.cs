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
    public class ServiceController : Controller
    {
        // GET: Service
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();
        public ActionResult ServiceList(int page = 1)
        {
            var value = context.Service.ToList().ToPagedList(page,7);
            return View(value);
        }

        public ActionResult DeleteService(int id)
        {
            var value = context.Service.Find(id);
            context.Service.Remove(value);
            context.SaveChanges();
            return RedirectToAction("ServiceList");
        }

        public ActionResult UpdateService(int id)
        {
            var value = context.Service.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateService(Service service)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdateService");
            }
            var value = context.Service.Find(service.ServiceId);
            value.Title = service.Title;
            value.Description = service.Description;
            value.Icon = service.Icon;
            value.Experience1 = service.Experience1;
            value.Experience2 = service.Experience2;
            value.Experience3 = service.Experience3;
            context.SaveChanges();
            return RedirectToAction("ServiceList");
        }

        public ActionResult CreateService()
        { 
            return View();
        }

        [HttpPost]
        public ActionResult CreateService(Service service)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateService");
            }
            context.Service.Add(service);
            context.SaveChanges();
            return RedirectToAction("ServiceList");
            

        }
    }
}