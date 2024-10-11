using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();

        public PartialViewResult PartialChartSkill()
        {
            var value = context.Skill.ToList();
            return PartialView(value);
        }
    }
}