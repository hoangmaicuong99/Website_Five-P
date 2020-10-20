using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Five_P.Models;

namespace Five_P.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        FivePEntities db = new FivePEntities();
        // GET: Admin/Users
        public ActionResult Index()
        {
            List<User> user = db.Users.ToList();
            ViewBag.SumUser = user.Count();
            return View(user);
        }
    }
}