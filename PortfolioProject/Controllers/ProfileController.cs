using PortfolioProject.Models;
using System.Linq;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class ProfileController : Controller
    {
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();

        public ActionResult UpdateProfile()
        {
            int id = 1; 
            var profile = context.Profile.Find(id);
            return View(profile);
        }

        [HttpPost]
        public ActionResult UpdateProfile(Profile profile)
        {
            if (!ModelState.IsValid)
            {
                return View(profile);
            }

            int id = 1;
            var value = context.Profile.Find(id);

            value.Title = profile.Title;
            value.Description = profile.Description;
            value.Address = profile.Address;
            value.PhoneNumber = profile.PhoneNumber;
            value.Email = profile.Email;
            value.Cv = profile.Cv;
            value.Github = profile.Github;
            value.ImageUrl = profile.ImageUrl;
            value.MapLocation = profile.MapLocation;

            context.SaveChanges();
            return View("UpdateProfile", value);
        }
        

    }
}
