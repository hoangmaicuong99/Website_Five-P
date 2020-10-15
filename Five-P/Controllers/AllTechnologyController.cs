using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Five_P.Models;

namespace Five_P.Controllers
{
    public class AllTechnologyController : Controller
    {
        // GET: AllTechnology
        FivePEntities db = new FivePEntities();
        public ActionResult Index()
        {
            List<Technology> Technology = db.Technologies.ToList();
            return View(Technology);
        }
    }
}