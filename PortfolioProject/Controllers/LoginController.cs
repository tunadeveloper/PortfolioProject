using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PortfolioProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {

            var value = context.Admin.FirstOrDefault(x => x.Username == admin.Username && x.Password == admin.Password);
            if (value != null)
            {
                FormsAuthentication.SetAuthCookie(value.Username, false);
                Session["Username"] = value.Username.ToString();
                return RedirectToAction("AboutList", "About");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        public ActionResult AdminSettings()
        {

            var admin = context.Admin.ToList();
            return View(admin);
        }

        [Authorize]
        public ActionResult UpdateAdmin()
        {
            int id = 1;
            var value = context.Admin.Find(id);
            return View(value);
        }

        [HttpPost, Authorize]
        public ActionResult UpdateAdmin(Admin admin)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdateAdmin");
            }
            int id = 1;
            var value = context.Admin.Find(id);
            value.Username = admin.Username;
            value.Password = admin.Password;
            context.SaveChanges();
            return RedirectToAction("AdminSettings");
        }
    }
}