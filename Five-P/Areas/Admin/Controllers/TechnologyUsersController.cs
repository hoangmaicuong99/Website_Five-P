using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Five_P.Models;

namespace Five_P.Areas.Admin.Controllers
{
    public class TechnologyUsersController : Controller
    {
        // GET: Admin/TechnologyUsers
        FivePEntities db = new FivePEntities();
        public ActionResult Index()
        {
            List<Technology_Care> technology_Care = db.Technology_Care.OrderBy(n => n.User.user_nicename).ToList();
            return View(technology_Care);
        }
    }
}