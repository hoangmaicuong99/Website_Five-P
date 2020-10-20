using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Five_P.Models;

namespace Five_P.Areas.Admin.Controllers
{
    public class FriendsController : Controller
    {
        FivePEntities db = new FivePEntities();
        // GET: Admin/Friends
        public ActionResult Index()
        {
            List<Friend> friend = db.Friends.OrderBy(n => n.User.user_nicename).ToList();
            ViewBag.SumFriend = friend.Count();
            return View(friend);
        }
    }
}