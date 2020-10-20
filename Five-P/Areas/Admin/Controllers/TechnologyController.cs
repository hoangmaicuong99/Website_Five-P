using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Five_P.Models;

namespace Five_P.Areas.Admin.Controllers
{
    public class TechnologyController : Controller
    {
        // GET: Admin/Technology
        FivePEntities db = new FivePEntities();
        public ActionResult Index()
        {
            List<Technology> technologies = db.Technologies.OrderBy(n => n.technology_name).ToList();
            ViewBag.SumTechnologies = technologies.Count();
            return View(technologies);
        }
    }
}