using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();
        public ActionResult ServiceList()
        {
            var value = context.Service.ToList();
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
            context.Service.Add(service);
            context.SaveChanges();
            return RedirectToAction("ServiceList");
            

        }
    }
}