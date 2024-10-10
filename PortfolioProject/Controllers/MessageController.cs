using PagedList;
using PagedList.Mvc;
using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class MessageController : Controller
    {
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();
        // GET: Message
        public ActionResult Inbox(int page = 1)
        {
            var values = context.Message
                        .OrderByDescending(m => m.MessageId)
                        .ToList()
                        .ToPagedList(page, 7);
            return View(values);
        }

        public ActionResult MessageDetails(int id)
        {
            var value = context.Message.Where(x => x.MessageId == id).FirstOrDefault();
            return View(value);
        }

        public ActionResult MessageStatusChangeToTrue(int id)
        {
            var value = context.Message.Where(x => x.MessageId == id).FirstOrDefault();
            value.IsRead = true;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }

        public ActionResult MessageStatusChangeToFalse(int id)
        {
            var value = context.Message.Where(x => x.MessageId == id).FirstOrDefault();
            value.IsRead = false;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }

        public ActionResult DeleteMessage(int id)
        {
            var value = context.Message.Find(id);
            context.Message.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }

    }
}