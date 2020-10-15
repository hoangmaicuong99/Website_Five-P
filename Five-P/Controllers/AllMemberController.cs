using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Five_P.Models;

namespace Five_P.Controllers
{
    public class AllMemberController : Controller
    {
        FivePEntities db = new FivePEntities();
        // GET: AllMember
        public ActionResult Index()
        {
            List<User> AllUser = db.Users.Where(n => n.user_role == 0 && n.user_activate == true && n.user_activate_admin == true).OrderByDescending(n=>n.user_popular).ToList();
            return View(AllUser);
        }
    }
}