using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact

        MyPortfolioDbEntities context = new MyPortfolioDbEntities();
        public PartialViewResult PartialContactSideBar()
        {
            ViewBag.ContactSideBarTitle = context.Settings.Select(x => x.ContactSideBarTitle).FirstOrDefault();

            return PartialView();
        }

        public PartialViewResult PartialContactAddress()
        {
            ViewBag.description = context.Profile.Select(x => x.Description).FirstOrDefault();
            ViewBag.address = context.Profile.Select(x => x.Address).FirstOrDefault();
            ViewBag.email = context.Profile.Select(x => x.Email).FirstOrDefault();
            ViewBag.phone = context.Profile.Select(x => x.PhoneNumber).FirstOrDefault();
            return PartialView();
        }

        public PartialViewResult ContactLocation()
        {
            ViewBag.mapLocation = context.Profile.Select(x=>x.MapLocation).FirstOrDefault();
            return PartialView();
        }


    }
}